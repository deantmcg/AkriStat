using AkriStat.Areas.Identity.Data;
using AkriStat.Constants;
using AkriStat.Helpers;
using AkriStat.Models;
using AkriStat.ViewModels.Search;
using AkriStat.ViewModels.Team;
using AkriStat.ViewModels.Team.Summary;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkriStat.Controllers
{
    public class TeamController : Controller
    {
        private readonly AkriStatDbContext _context;
        private readonly IMapper _mapper;

        public TeamController(AkriStatDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [Route("Teams")]
        public async Task<IActionResult> Dashboard()
        {
            ViewData["Title"] = "Teams";

            return View();
        }

        // Gets the team matching supplied ID and returns their Details view
        [Route("Teams/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            // Get team
            var team = await _context.Teams
                .Include(x => x.Nation)
                .Include(x => x.CompetitionSeasonTeams)
                .ThenInclude(x => x.Competition)
                .Include(x => x.Players)
                .FirstOrDefaultAsync(x => x.ID == id);

            var viewModel = _mapper.Map<TeamDetailsVM>(team);

            ViewData["Title"] = team.Name;

            return View(viewModel);
        }

        /* Gets the team matching supplied id and returns their Edit view
           Only accessible by Administrators */
        [HttpGet, Route("Teams/{id}/Edit"), Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id)
        {
            // Get the team
            var team = await _context.Teams
                .FirstOrDefaultAsync(x => x.ID == id);

            var vm = _mapper.Map<TeamEditVM>(team);

            // Set display message if redirected from Edit POST method
            if (TempData["MessageToDisplay"] != null)
            {
                ViewBag.MessageToDisplay = TempData["MessageToDisplay"];
                TempData.Remove("MessageToDisplay");
                ViewBag.Success = TempData["Success"];
                TempData.Remove("Success");
            }

            ViewData["Title"] = "Edit Team";
            await PopulateSelectLists(vm);
            return View(vm);
        }

        // Takes Edit POST form and updates team record
        [HttpPost, Route("Teams/{id}/Edit"), Authorize(Roles = "Administrator")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TeamEditVM vm)
        {
            await PopulateSelectLists(vm);
            ViewData["Title"] = "Edit Team";

            // Validation
            if (!ModelState.IsValid)
                return View(vm);

            var team = await _context.Teams
                .FirstOrDefaultAsync(x => x.ID == vm.ID);

            // Map changes to team
            _mapper.Map(vm, team);

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

        // Returns league table partial view for team
        public async Task<IActionResult> GetLeagueTableSnapshot(int teamId)
        {
            // Get teams current league ID
            var currentLeagueID = _context.Teams
                .Include(x => x.CompetitionSeasonTeams)
                .FirstOrDefault(x => x.ID == teamId)
                .CompetitionSeasonTeams
                .FirstOrDefault(x => x.SeasonYear.Equals(SiteProperties.CurrentSeason))
                .CompetitionID;

            // Get league table lines for league ID
            var leagueTableLines = await _context.LeagueTableLines
                .Where(x => x.Season.Equals(SiteProperties.CurrentSeason)
                            && x.LeagueID == currentLeagueID)
                .OrderByDescending(x => x.Points)
                .ThenByDescending(x => x.GoalDifference)
                .ToListAsync();

            ViewBag.TeamID = teamId;

            return PartialView("Team/_LeagueTableSnapshot", leagueTableLines);
        }

        // Returns current squad partial view for team
        public async Task<IActionResult> GetCurrentSquad(int teamId)
        {
            // Get players who play for team
            var playerIds = await _context.Players
                .Where(x => x.CurrentTeamID == teamId)
                .OrderByDescending(x => x.Position.ListOrder)
                .Select(x => x.ID)
                .ToListAsync();

            // Get positions for ordering squad by
            var positions = await _context.Positions
                .OrderBy(x => x.ListOrder)
                .Select(x => x.Code)
                .ToListAsync();

            // Get player stat summaries for squad
            var playerSummaries = await _context.vwSummariesAdvancedSearch
                .Where(x => x.Season.Equals(SiteProperties.CurrentSeason)
                            && playerIds.Contains(x.ID.Value))
                .ToListAsync();

            // orders squad by position on pitch
            playerSummaries = playerSummaries.OrderBy(x => positions.IndexOf(x.Position)).ToList();

            var viewModels = _mapper.Map<List<AdvancedSearchResultVM>>(playerSummaries);

            return PartialView("Team/_CurrentSquad", viewModels);
        }

        // Returns matches partial view for team
        public async Task<IActionResult> GetMatchesPlayed(int teamId)
        {
            // Get matches played for team ID
            var matchTeamStats = await _context.MatchTeamStats
                .Where(x => (x.TeamOneID == teamId || x.TeamTwoID == teamId)
                            && x.Season.Equals(SiteProperties.CurrentSeason))
                .OrderBy(x => x.Date)
                .ToListAsync();

            ViewBag.TeamID = teamId;

            return PartialView("Team/_MatchesPlayed", matchTeamStats);
        }

        #region Visualisations
        // Returns Goals vs xG partial view
        public async Task<IActionResult> GetGoalsVsXg(int teamId)
        {
            var matchTeamStats = await _context.MatchTeamStats
                .Where(x => (x.TeamOneID == teamId || x.TeamTwoID == teamId)
                            && x.Season.Equals(SiteProperties.CurrentSeason))
                .OrderBy(x => x.Date)
                .Select(x => new GoalsVsXgVM()
                {
                    Round = x.Round,
                    Goals = x.TeamOneID == teamId ? x.TeamOneGoals.Value : x.TeamTwoGoals.Value,
                    Xg = x.TeamOneID == teamId ? x.TeamOneXG.Value : x.TeamTwoXG.Value
                })
                .ToListAsync();

            return PartialView("Team/_GoalsVsXg", matchTeamStats);
        }

        // Returns attacking stats radar chart partial view
        public async Task<IActionResult> GetAttackingSummary(int teamId)
        {
            var summary = await _context.vwSummaryTeamAttacking
                .FirstOrDefaultAsync(x => x.TeamID == teamId);

            var viewModel = _mapper.Map<TeamSummaryAttackingVM>(summary);

            return PartialView("Team/_AttackingSummary", viewModel);
        }

        // Returns defensive stats radar chart partial view
        public async Task<IActionResult> GetDefensiveSummary(int teamId)
        {
            var summary = await _context.vwSummaryTeamDefensive
                .FirstOrDefaultAsync(x => x.TeamID == teamId);

            var viewModel = _mapper.Map<TeamSummaryDefensiveVM>(summary);

            return PartialView("Team/_DefensiveSummary", viewModel);
        }

        // Returns player carries scatter plot partial view
        public async Task<IActionResult> GetPlayerCarriesGraph(int teamId)
        {
            var playerIds = await _context.Players
                .Where(x => x.CurrentTeamID == teamId)
                .Select(x => x.ID)
                .ToListAsync();

            var minimumMinutesPlayed = 400;

            var viewModels = await _context.vwPlayerCarries
                .Where(x => playerIds.Contains(x.PlayerID) &&
                            x.Season == SiteProperties.CurrentSeason &&
                            x.MinutesPlayed > minimumMinutesPlayed)
                .Select(x => new PlayerCarriesVM()
                {
                    PlayerID = x.PlayerID,
                    Name = x.Name,
                    CarriesPer90 = x.CarriesPer90,
                    YardsPerCarry = x.YardsPerCarry.Value
                })
                .ToListAsync();

            ViewBag.CurrentSeason = SiteProperties.CurrentSeason;
            ViewBag.MinimumMinutesPlayed = minimumMinutesPlayed;

            return PartialView("_CarriesGraph", viewModels);
        }
        #endregion

        #region Helper Methods
        // Generates drop down lists for Edit view
        private async Task PopulateSelectLists(TeamEditVM vm)
        {
            vm.NationSelectList = await _context.Countries
                .OrderBy(x => x.Name)
                .Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.ID.ToString()
                })
                .ToListAsync();

            vm.LeagueSelectList = await _context.Competitions
                .Where(x => x.CompetitionTypeID == 1)
                .Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.ID.ToString()
                })
                .ToListAsync();

            vm.TeamTypeSelectList = await _context.TeamTypes
                .Select(x => new SelectListItem()
                {
                    Text = x.Description,
                    Value = x.ID.ToString()
                })
                .ToListAsync();
        }
        #endregion
    }
}
