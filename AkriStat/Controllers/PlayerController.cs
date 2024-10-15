using AkriStat.Constants;
using AkriStat.Models;
using AkriStat.SearchConditions;
using AkriStat.ViewModels.Player;
using AkriStat.ViewModels.Player.Dashboard;
using AkriStat.ViewModels.Player.Summary;
using AkriStat.ViewModels.Search;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SqlKata;
using SqlKata.Compilers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AkriStat.Controllers
{
    public class PlayerController : Controller
    {
        private readonly AkriStatDbContext _context;
        private readonly IMapper _mapper;

        public PlayerController(AkriStatDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Returns the player dashboard view
        [Route("Players")]
        public async Task<IActionResult> Dashboard()
        {
            ViewData["Title"] = "Players";
            var vm = new PlayerDashboardVM();

            /* Attacking pane shown by default
               Others loaded when user clicks them */
            vm.AttackingStatistics = await GetAttacking();

            return View(vm);
        }

        // Gets the player matching supplied ID and returns their Details view
        [Route("Players/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            // Get player
            var player = await _context.Players
               .Include(x => x.Position)
               .Include(x => x.Nationality)
               .Include(x => x.SecondNationality)
               .Include(x => x.CurrentTeam)
               .Include(x => x.ShortlistedPlayers)
               .ThenInclude(x => x.Shortlist)
               .Where(x => x.ID == id)
               .FirstOrDefaultAsync();

            if (player == null)
                return RedirectToAction("NotFoundError", "Home", new { page = SiteProperties.Page.Player });

            var viewModel = _mapper.Map<PlayerDetailsVM>(player);
            viewModel.Shortlists = await GetShortlists(id);

            // Get player summary stats for current season
            var seasonStats = await _context.PlayerMatchLogSummaries
                .FirstOrDefaultAsync(x => x.PlayerID == id && x.Season.Equals(SiteProperties.CurrentSeason));

            // Get some key stats for player details section
            if (seasonStats != null)
            {
                viewModel.GamesPlayed = seasonStats.GamesPlayed.Value;
                viewModel.Goals = seasonStats.Goals.Value;
                viewModel.Assists = seasonStats.Assists.Value;
            }

            ViewData["Title"] = player.Name;
            return View(viewModel);
        }

        /* Gets the player matching supplied id and returns their Edit view
           Only accessible by Administrators */
        [HttpGet, Route("Players/{id}/Edit"), Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id)
        {
            // Get the player
            var player = await _context.Players
                .FirstOrDefaultAsync(x => x.ID == id);

            var vm = _mapper.Map<PlayerEditVM>(player);

            // Set display message if redirected from Edit POST method
            if (TempData["MessageToDisplay"] != null)
            {
                ViewBag.MessageToDisplay = TempData["MessageToDisplay"];
                TempData.Remove("MessageToDisplay");
                ViewBag.Success = TempData["Success"];
                TempData.Remove("Success");
            }

            ViewData["Title"] = "Edit Player";
            await PopulateSelectLists(vm);
            return View(vm);
        }

        // Takes Edit POST form and updates player record
        [HttpPost, Route("Players/{id}/Edit"), Authorize(Roles = "Administrator")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PlayerEditVM vm)
        {
            await PopulateSelectLists(vm);
            ViewData["Title"] = "Edit Player";

            // Validation
            if (!ModelState.IsValid)
                return View(vm);

            var player = await _context.Players
                .FirstOrDefaultAsync(x => x.ID == vm.ID);

            // Map changes from View Model to Player
            _mapper.Map(vm, player);

            // Set display message
            try
            {
                await _context.SaveChangesAsync();
                TempData["MessageToDisplay"] = "Changes saved successfully!";
                TempData["Success"] = true;
            }
            catch (Exception)
            {
                TempData["MessageToDisplay"] = "Failed to save changes.";
                TempData["Success"] = false;
            }

            return RedirectToAction(nameof(Edit), new { id = vm.ID });
        }

        // Get Player Match Logs
        [Route("Players/{id}/MatchLogs")]
        public async Task<IActionResult> MatchLogs(int id)
        {
            return await GetCombinedMatchLogs(id, true);
        }

        // Gets the match logs for 
        public async Task<IActionResult> GetCombinedMatchLogs(int playerId, bool fullView)
        {
            if (fullView) // returns full match log view
            {
                var player = await _context.Players
                    .Include(x => x.Position)
                    .Include(x => x.PlayerMatchLogs)
                    .ThenInclude(x => x.Match)
                    .FirstOrDefaultAsync(x => x.ID == playerId);

                var viewModel = _mapper.Map<PlayerMatchLogFullVM>(player);
                // Gets current season matchlogs for player 
                viewModel.MatchLogs = _mapper.Map<List<PlayerMatchLogVM>>
                (
                    await _context.vwCombinedMatchLogs
                        .Where(x => x.PlayerID == playerId && x.Season.Equals(Constants.SiteProperties.CurrentSeason))
                        .OrderBy(x => x.Date.Value)
                        .ToListAsync()
                );

                ViewData["Title"] = $"{player.Name} Match Logs";
                return View("MatchLogs", viewModel);
            }
            else // returns match log partial view
            {
                // Gets current season matchlogs for player 
                var matchLogs = _mapper.Map<List<PlayerMatchLogVM>>
                (
                    await _context.vwCombinedMatchLogs
                        .Where(x => x.PlayerID == playerId && x.Season.Equals(Constants.SiteProperties.CurrentSeason))
                        .OrderBy(x => x.Date.Value)
                        .ToListAsync()
                );

                return PartialView("_MatchLogsTable", matchLogs);
            }
        }

        public async Task<IActionResult> GetSimilarPlayers(int playerId)
        {
            // Get selected player's season summary stats
            var player = await _context.PlayerMatchLogSummaries
                .FirstOrDefaultAsync(x => x.PlayerID == playerId && x.Season.Equals(SiteProperties.CurrentSeason));
            
            // Multiplier used to find similar player stats
            double rangeAllowance = 0.4;

            // Get selected player's position group
            var position = GetPositions(player.Position);

            // Create base query
            var query = new Query("PlayerMatchLogSummaries").WhereNot("PlayerID", playerId);

            if (position == PositionGroups.Goalkeepers)
            {
                query.WhereIn("Position", "GK");
                SetQueryBounadaries(query, rangeAllowance, "GkPostShotXGPer90", player.GkPostShotXGPer90);
                SetQueryBounadaries(query, rangeAllowance, "GkOpponentCrossesStoppedPercentage", player.GkOpponentCrossesStoppedPercentage);
                SetQueryBounadaries(query, rangeAllowance, "GkPassesAttemptedOver40YardsPercentage", player.GkPassesAttemptedOver40YardsPercentage);
                SetQueryBounadaries(query, rangeAllowance, "GkSavesPer90", player.GkSavesPer90);
                SetQueryBounadaries(query, rangeAllowance, "GkShotsOnTargetFacedPer90", player.GkShotsOnTargetFacedPer90);
            }
            else if (position == PositionGroups.FullBacksAndWingBacks)
            {
                
                query.WhereIn("Position", new string[] { "RB", "LB", "WB" });
                SetQueryBounadaries(query, rangeAllowance, "SuccessfulDribblesPer90", player.SuccessfulDribblesPer90);
                SetQueryBounadaries(query, rangeAllowance, "YardsProgressiveCarriesPer90", player.YardsProgressiveCarriesPer90);
                SetQueryBounadaries(query, rangeAllowance, "PassesCompletedPercentage", player.PassesCompletedPercentage);
                SetQueryBounadaries(query, rangeAllowance, "TacklesWonPercentage", player.TacklesWonPercentage);
                SetQueryBounadaries(query, rangeAllowance, "XgAssistedPer90", player.XGAssistedPer90);
            }
            else if (position == PositionGroups.CentralDefenders)
            {
                rangeAllowance = 0.5;
                query.WhereIn("Position", "CB");
                SetQueryBounadaries(query, rangeAllowance, "BlocksPer90", player.BlocksPer90);
                SetQueryBounadaries(query, rangeAllowance, "InterceptionsPer90", player.InterceptionsPer90);
                SetQueryBounadaries(query, rangeAllowance, "TacklesWonPer90", player.TacklesWonPer90);
                SetQueryBounadaries(query, rangeAllowance, "AerialDualsWonPercentage", player.AerialDualsWonPercentage);
                SetQueryBounadaries(query, rangeAllowance, "DribblersTackledPercentage", player.DribblersTackledPercentage);
            }
            else if (position == PositionGroups.CentralMidfielders)
            {

                query.WhereIn("Position", new string[] { "DM", "CM" });
                SetQueryBounadaries(query, rangeAllowance, "PassesIntoFinalThirdPer90", player.PassesIntoFinalThirdPer90);
                SetQueryBounadaries(query, rangeAllowance, "ChancesCreatedPer90", player.ChancesCreatedPer90);
                SetQueryBounadaries(query, rangeAllowance, "SuccessfulPressuresPer90", player.SuccessfulPressuresPer90);
                SetQueryBounadaries(query, rangeAllowance, "AerialDualsWonPercentage", player.AerialDualsWonPercentage);
                SetQueryBounadaries(query, rangeAllowance, "YardsProgressiveCarriesPer90", player.YardsProgressiveCarriesPer90);
            }
            else if (position == PositionGroups.AttackingMidAndWingers)
            {

                query.WhereIn("Position", new string[] { "AM", "LW", "RW", "RM", "LM" });
                SetQueryBounadaries(query, rangeAllowance, "XGAssistedPer90", player.XGAssistedPer90);
                SetQueryBounadaries(query, rangeAllowance, "ChancesCreatedPer90", player.ChancesCreatedPer90);
                SetQueryBounadaries(query, rangeAllowance, "SuccessfulDribblesPer90", player.SuccessfulDribblesPer90);
                SetQueryBounadaries(query, rangeAllowance, "PassesIntoFinalThirdPer90", player.PassesIntoFinalThirdPer90);
                SetQueryBounadaries(query, rangeAllowance, "PassesCompletedPer90", player.PassesCompletedPer90);
            }
            else if (position == PositionGroups.Forwards)
            {
                rangeAllowance = 0.5;
                query.WhereIn("Position", "FW");
                SetQueryBounadaries(query, rangeAllowance, "XGAssistedPer90", player.XGAssistedPer90);
                SetQueryBounadaries(query, rangeAllowance, "TouchesAttackingPenaltyAreaPer90", player.TouchesAttackingPenaltyAreaPer90);
                SetQueryBounadaries(query, rangeAllowance, "SuccessfulDribblesPer90", player.SuccessfulDribblesPer90);
                SetQueryBounadaries(query, rangeAllowance, "ShotsOnTargetPer90", player.ShotsOnTargetPer90);
                SetQueryBounadaries(query, rangeAllowance, "NonPenaltyXGPer90", player.NonPenaltyXGPer90);
            }
            else
            {
                return NotFound();
            }

            var compiler = new SqlServerCompiler();
            var result = compiler.Compile(query).ToString();

            // Executes generated query
            var playerIds = await _context.PlayerMatchLogSummaries
                .FromSqlRaw(result)
                .Select(x => x.PlayerID)
                .Distinct()
                .Take(30)
                .ToListAsync();

            // Gets player details for found similar player IDs
            var viewModels = _context.Players
                .Include(x => x.Nationality)
                .Include(x => x.Position)
                .Where(x => playerIds.Contains(x.ID))
                .Select(x => new StandardSearchResultVM()
                {
                    ID = x.ID,
                    Name = x.Name,
                    Position = x.Position.Code,
                    NationalityFlagUrl = x.Nationality.FlagUrl
                })
                .ToList();

            return PartialView("_SimilarPlayers", viewModels);
        }

        /* Takes range allowance and selected player's value for a stat
         * Multiplies value by range allowance to find upper and lower boundary 
         * Updates query with 'IS BETWEEN' {upper} and {lower}
         */
        private void SetQueryBounadaries(Query query, double rangeAllowance, string column, double value)
        {
            DoubleRange range = new DoubleRange();
            range.Min = value * (1 - rangeAllowance);
            range.Max = value * (1 + rangeAllowance);
            query.WhereBetween(column, range.Min, range.Max);
        }

        #region Summary Partials
        // Gets player summary stats for position: Goalkeeper
        public IActionResult GetSummaryKeeper(int playerId)
        {
            var summary = _context.vwSummaryKeepers
                .FromSqlRaw("KeeperSummary {0}", playerId.ToString())
                .ToList()
                .FirstOrDefault(x => x.PlayerID == playerId);

            var viewModel = _mapper.Map<SummaryKeeperVM>(summary);

            return PartialView("_KeeperSummary", viewModel);
        }

        // Gets player summary stats for position: Full Back / Wing Back
        public IActionResult GetSummaryFullBack(int playerId)
        {
            var summary = _context.vwSummaryFullBacks
                .FromSqlRaw("FullBackSummary {0}", playerId.ToString())
                .ToList()
                .FirstOrDefault(x => x.PlayerID == playerId);

            var viewModel = _mapper.Map<SummaryFullBackVM>(summary);

            return PartialView("_FullBackSummary", viewModel);
        }

        // Gets player summary stats for position: Central Defender
        public IActionResult GetSummaryCentreBack(int playerId)
        {
            var summary = _context.vwSummaryCentreBacks
                .FromSqlRaw("CentreBackSummary {0}", playerId.ToString())
                .ToList()
                .FirstOrDefault(x => x.PlayerID == playerId);

            var viewModel = _mapper.Map<SummaryCentreBackVM>(summary);

            return PartialView("_CentreBackSummary", viewModel);
        }

        // Gets player summary stats for position: Central Midfielder
        public IActionResult GetSummaryCentreMidfielder(int playerId)
        {
            var summary = _context.vwSummaryCentreMidfielders
                .FromSqlRaw("CentreMidfielderSummary {0}", playerId.ToString())
                .ToList()
                .FirstOrDefault(x => x.PlayerID == playerId);

            var viewModel = _mapper.Map<SummaryCentreMidfielderVM>(summary);

            return PartialView("_CentreMidfielderSummary", viewModel);
        }

        // Gets player summary stats for position: Attacking Midfielder / Winger
        public IActionResult GetSummaryAttackingMidAndWinger(int playerId)
        {
            var summary = _context.vwSummaryAttackingMidAndWingers
                .FromSqlRaw("AttackingMidAndWingerSummary {0}", playerId.ToString())
                .ToList()
                .FirstOrDefault(x => x.PlayerID == playerId);

            var viewModel = _mapper.Map<SummaryAttackingMidAndWingerVM>(summary);

            return PartialView("_AttackingMidAndWingerSummary", viewModel);
        }

        // Gets player summary stats for position: Forward
        public IActionResult GetSummaryStriker(int playerId)
        {
            var summary = _context.vwSummaryStriker
                .FromSqlRaw("StrikerSummary {0}", playerId.ToString())
                .ToList()
                .FirstOrDefault(x => x.PlayerID == playerId);

            var viewModel = _mapper.Map<SummaryStrikerVM>(summary);

            return PartialView("_StrikerSummary", viewModel);
        }

        // Gets player summary stats and returns partial view
        public IActionResult GetSummaryBars(int playerId)
        {
            var summary = _context.PlayerMatchLogSummaries
                .FirstOrDefault(x => x.PlayerID == playerId);

            var viewModel = _mapper.Map<BarsVM>(summary);

            // Return parital view based on players position
            if (summary.Position.Equals("GK"))
            {
                return PartialView("_KeeperBars", viewModel);
            }
            else if (summary.Position.Equals("CB"))
            {
                return PartialView("_CentreBackBars", viewModel);
            }
            else if (new string[] { "WB", "LB", "RB" }.Contains(summary.Position))
            {
                return PartialView("_FullBackBars", viewModel);
            }
            else if (new string[] { "DM", "CM" }.Contains(summary.Position))
            {
                return PartialView("_CentreMidfielderBars", viewModel);
            }
            else if (new string[] { "LW", "RW", "AM", "RM", "LM" }.Contains(summary.Position))
            {
                return PartialView("_AttackingMidAndWingerBars", viewModel);
            }
            else if (summary.Position.Equals("FW"))
            {
                return PartialView("_StrikerBars", viewModel);
            }
            else
            {
                return NotFound();
            }
        }
        #endregion

        #region Shortlist
        // Get all shortlists for current logged in user
        private Task<List<ShortlistedPlayerVM>> GetShortlists(int playerId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return _context.Shortlists
                .Where(x => x.IsActive && x.UserID.Equals(userId))
                .Include(x => x.ShortlistedPlayers)
                .Select(x => new ShortlistedPlayerVM()
                {
                    ID = x.ID,
                    Name = x.Name,
                    // if current player contained in the shortlist
                    PlayerIncluded = x.ShortlistedPlayers.Select(y => y.PlayerID).Contains(playerId)
                })
                .ToListAsync();
        }

        // Adds current player to desired shortlist
        [HttpGet]
        public async Task<IActionResult> AddToShortlist(int playerId, int shortlistId)
        {
            // Check supplied shortlistId exists
            if (!ShortlistExists(shortlistId))
            {
                return NotFound();
            }

            // Create shortlist entry for player
            var shortlistEntry = new ShortlistedPlayers()
            {
                ShortlistID = shortlistId,
                PlayerID = playerId,
                DateAdded = DateTime.Now
            };

            _context.ShortlistedPlayers.Add(shortlistEntry);

            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                var shortlist = _context.Shortlists.FirstOrDefault(x => x.ID == shortlistEntry.ShortlistID);
                shortlist.LastUpdatedDate = shortlistEntry.DateAdded;
                await _context.SaveChangesAsync();
                // return details of shortlist player was added to
                return Json(new
                {
                    shortlistName = shortlist.Name,
                    shortlistId = shortlistEntry.ShortlistID
                });
            }
            else
                return NotFound();
        }

        // Removes supplied player ids from supplied shortlist
        [HttpGet]
        public async Task<IActionResult> RemoveFromShortlist(int shortlistId, params int[] playerIds)
        {
            // Check supplied shortlistId exists
            if (!ShortlistExists(shortlistId))
            {
                return NotFound();
            }

            // remove each playerId from shortlist
            foreach (var id in playerIds)
            {
                var shortlistEntry = _context.ShortlistedPlayers
                .FirstOrDefault(x => x.PlayerID == id && x.ShortlistID == shortlistId);

                _context.ShortlistedPlayers.Remove(shortlistEntry);
            }

            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                var shortlist = _context.Shortlists.FirstOrDefault(x => x.ID == shortlistId);
                shortlist.LastUpdatedDate = DateTime.Now;
                await _context.SaveChangesAsync();
                // if only 1: return shortlist details and player name
                if (playerIds.Length == 1)
                {
                    return Json(new
                    {
                        shortlistName = shortlist.Name,
                        shortlistId = shortlistId,
                        playerRemoved = _context.Players.FirstOrDefault(x => x.ID == playerIds[0]).Name
                    });
                }
                // if more than 1: return shortlist details and player count
                else
                {
                    return Json(new
                    {
                        shortlistName = shortlist.Name,
                        shortlistId = shortlistId,
                        playerRemoved = playerIds.Length + " players"
                    });
                }
            }
            else
                return Ok();
        }
        #endregion

        #region Dashboard
        // Get top attacking stat summaries for current season
        public async Task<List<PlayerAttackingVM>> GetAttacking(int minutesPlayed = 850)
        {
            var viewModels = await _context.PlayerMatchLogSummaries
                .Where(x => x.MinutesPlayed > minutesPlayed
                            && x.GoalsPer90 > 0
                            && x.Season.Equals(Constants.SiteProperties.CurrentSeason))
                .OrderByDescending(x => x.Goals)
                .Take(30)
                .Select(x => new PlayerAttackingVM()
                {
                    ID = x.PlayerID,
                    Name = x.PlayerName,
                    Goals = x.Goals,
                    GoalsPer90 = x.GoalsPer90,
                    NonPenaltyXG = x.NonPenaltyXG,
                    NonPenaltyXGPer90 = x.NonPenaltyXGPer90,
                    GoalsPerShot = x.GoalsPerShot,
                    ShotsPer90 = x.ShotsPer90,
                    ChancesCreated = x.ChancesCreated,
                    ChancesCreatedPer90 = x.ChancesCreatedPer90,
                    TouchesAttackingPenaltyAreaPer90 = x.TouchesAttackingPenaltyAreaPer90
                })
                .ToListAsync();

            return viewModels;
        }

        // Return attacking stat summaries partial view
        public async Task<IActionResult> GetAttackingPartial(int minutesPlayed = 850)
        {
            var viewModels = await GetAttacking(minutesPlayed);
            return PartialView("PlayerDashboard/_AttackingTable", viewModels);
        }

        // Get top passing stat summaries for current season and return partial view
        public async Task<IActionResult> GetPassingPartial(int minutesPlayed = 850)
        {
            var viewModels = await _context.PlayerMatchLogSummaries
                .Where(x => x.MinutesPlayed > minutesPlayed
                            && x.GoalsPer90 > 0
                            && x.Season.Equals(Constants.SiteProperties.CurrentSeason))
                .OrderByDescending(x => x.Assists)
                .Take(30)
                .Select(x => new PlayerPassingVM()
                {
                    ID = x.PlayerID,
                    Name = x.PlayerName,
                    PassesAttemptedPer90 = x.PassesAttemptedPer90,
                    PassesCompletedPercentage = x.PassesCompletedPercentage,
                    ProgressivePassesPer90 = x.ProgressivePassesPer90,
                    AssistsPer90 = x.AssistsPer90,
                    XgAssistedPer90 = x.XGAssistedPer90,
                    KeyPassesPer90 = x.ShotsPer90,
                    ChancesCreatedPer90 = x.ChancesCreatedPer90,
                    PassesReceivedPercentage = x.PassesReceivedPercentage
                })
                .ToListAsync();

            return PartialView("PlayerDashboard/_PassingTable", viewModels);
        }

        // Get top possession stat summaries and return partial view
        public async Task<IActionResult> GetPossessionPartial(int minutesPlayed = 850)
        {
            var viewModels = await _context.PlayerMatchLogSummaries
                .Where(x => x.MinutesPlayed > minutesPlayed
                            && x.SuccessfulDribblesPercentage > 0
                            && x.Season.Equals(Constants.SiteProperties.CurrentSeason))
                .OrderByDescending(x => x.Assists)
                .Take(30)
                .Select(x => new PlayerPossessionVM()
                {
                    ID = x.PlayerID,
                    Name = x.PlayerName,
                    TouchesPer90 = x.TouchesPer90,
                    SuccessfulDribblesPercentage = x.SuccessfulDribblesPercentage,
                    PlayersDribbledPastPer90 = x.PlayersDribbledPastPer90,
                    CarriesPer90 = x.CarriesPer90,
                    YardsProgressiveCarriesPer90 = x.YardsProgressiveCarriesPer90,
                    PassesReceivedPercentage = x.PassesReceivedPercentage
                })
                .ToListAsync();

            return PartialView("PlayerDashboard/_PossessionTable", viewModels);
        }

        // Get top defensive stat summaries and return partial view
        public async Task<IActionResult> GetDefensivePartial(int minutesPlayed = 850)
        {
            var viewModels = await _context.PlayerMatchLogSummaries
                .Where(x => x.MinutesPlayed > minutesPlayed
                            && x.SuccessfulDribblesPercentage > 0
                            && x.Season.Equals(Constants.SiteProperties.CurrentSeason))
                .OrderByDescending(x => x.Assists)
                .Take(30)
                .Select(x => new PlayerDefensiveVM()
                {
                    ID = x.PlayerID,
                    Name = x.PlayerName,
                    TacklesWonPer90 = x.TacklesWonPer90,
                    DribblersTackledPercentage = x.DribblersTackledPercentage,
                    SuccessfulPressuresPer90 = x.SuccessfulPressuresPer90,
                    SuccessfulPressuresPercentage = x.SuccessfulPressuresPercentage,
                    BlocksPer90 = x.BlocksPer90,
                    InterceptionsPer90 = x.InterceptionsPer90,
                    ClearancesPer90 = x.ClearancesPer90
                })
                .ToListAsync();

            return PartialView("PlayerDashboard/_DefensiveTable", viewModels);
        }
        #endregion

        #region Helper Methods
        // Populates select lists used on Edit view
        private async Task PopulateSelectLists(PlayerEditVM vm)
        {
            vm.PositionSelectList = await _context.Positions
                .OrderBy(x => x.ListOrder)
                .Select(x => new SelectListItem()
                {
                    Text = x.Code,
                    Value = x.ID.ToString()
                })
                .ToListAsync();

            // insert null option as PositionID is nullable
            vm.PositionSelectList.Insert(0, new SelectListItem());

            vm.NationalitySelectList = await _context.Countries
                .OrderBy(x => x.Name)
                .Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.ID.ToString()
                })
                .ToListAsync();

            // insert null option as NationalityID is nullable
            vm.NationalitySelectList.Insert(0, new SelectListItem());
        }

        // Check that shortlist of supplied id exists
        private bool ShortlistExists(int id)
        {
            var shortlist = _context.Shortlists
                .FirstOrDefault(x => x.ID.Equals(id) && x.IsActive);

            if (shortlist != null)
            {
                return true;
            }
            return false;
        }

        /* Uses supplied playerId to return all seasons player has appeared in
           Called in view by jQuery */
        [HttpGet]
        public void GetPlayerSeasonsSelectList(PlayerMatchLogFullVM viewModel)
        {
            viewModel.SeasonsSelectList = _context.vwCombinedMatchLogs
                .Where(x => x.PlayerID == viewModel.ID).ToList()
                .Select(x => x.Season).Distinct()
                .Select(x => new SelectListItem() { Text = x })
                .OrderBy(x => Convert.ToInt32(x.Text[^2..]))
                .ToList();
        }

        private PositionGroups? GetPositions(string position)
        {
            if (position.Equals("GK"))
                return PositionGroups.Goalkeepers;
            else if (new string[] { "RB", "LB", "WB" }.Contains(position))
                return PositionGroups.FullBacksAndWingBacks;
            else if (position.Equals("CB"))
                return PositionGroups.CentralDefenders;
            else if (new string[] { "DM", "CM" }.Contains(position))
                return PositionGroups.CentralMidfielders;
            else if (new string[] { "RM", "LM", "AM", "RW", "LW" }.Contains(position))
                return PositionGroups.AttackingMidAndWingers;
            else if (position.Equals("FW"))
                return PositionGroups.Forwards;
            else
                return null;
        }
        #endregion
    }
}
