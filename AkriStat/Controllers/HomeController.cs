using AkriStat.Constants;
using AkriStat.Models;
using AkriStat.ViewModels.Dashboard;
using AkriStat.ViewModels.Shortlist;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SqlKata;
using SqlKata.Compilers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AkriStat.Controllers
{
    public class HomeController : Controller
    {
        private readonly AkriStatDbContext _context;
        private readonly IMapper _mapper;

        public HomeController(AkriStatDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(Dashboard));
        }

        public async Task<IActionResult> Dashboard()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.FindFirstValue(ASClaimTypes.NameIdentifier);

                ViewBag.ShortlistsSelectList = await _context.Shortlists
                .Where(x => x.UserID.Equals(userId)
                            && x.IsActive)
                .Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.ID.ToString()
                })
                .ToListAsync();

                Teams myTeam;

                if (User.IsInRole("Chief Scout"))
                {
                    myTeam = _context.AspNetUserRoleTeams
                        .Include(x => x.Team)
                        .FirstOrDefault(x => x.UserId.Equals(userId))
                        .Team;

                    ViewBag.StaffActivity = GetStaffActivity(myTeam.ID);
                }
                else
                {
                    var favouriteTeamId = GetFavouriteTeamId();
                    myTeam = _context.Teams
                        .FirstOrDefault(x => x.ID == favouriteTeamId);
                }

                ViewBag.MyTeamID = myTeam.ID;
                ViewBag.MyTeamName = myTeam.Name;
                ViewBag.MyTeamColour1 = myTeam.ColourCode1;
                ViewBag.MyTeamColour2 = myTeam.ColourCode2;

            }

            ViewBag.LeaguesSelectList = await _context.Competitions
                .Where(x => x.CompetitionTypeID == 1)
                .OrderBy(x => x.Name)
                .Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.ID.ToString()
                })
                .ToListAsync();

            ViewBag.PlayersSelectList = await _context.Players
                .OrderBy(x => x.Name)
                .Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.ID.ToString()
                })
                .ToListAsync();

            return View();
        }

        private ExpandoObject GetStaffActivity(int teamId)
        {
            dynamic staffActivity = new ExpandoObject();
            var names = new List<string>();
            var shortlistedInLastWeek = new List<int>();
            var shortlistedInLastMonth = new List<int>();
            var shortlistedInLast3Months = new List<int>();

            var staff = new List<dynamic>();
            var userId = User.FindFirstValue(ASClaimTypes.NameIdentifier);

            var staffShortlists = _context.AspNetUserRoleTeams
                .Include(x => x.AspNetUserRoles)
                .ThenInclude(x => x.User)
                .ThenInclude(x => x.Shortlists)
                .ThenInclude(x => x.ShortlistedPlayers)
                .Where(x => x.TeamId == teamId && !x.UserId.Equals(userId))
                .ToList();

            foreach (var person in staffShortlists.Select(x => x.AspNetUserRoles.User).ToList())
            {
                names.Add(person.FullName);

                int lastWeek = person.Shortlists.Select(x => x.ShortlistedPlayers
                        .Where(x => x.DateAdded > DateTime.Today.AddDays(-7))
                        .Count()).Sum();

                shortlistedInLastWeek.Add(lastWeek);

                int lastMonth = person.Shortlists.Select(x => x.ShortlistedPlayers
                        .Where(x => x.DateAdded > DateTime.Today.AddMonths(-1))
                        .Count()).Sum() - lastWeek;

                shortlistedInLastMonth.Add(lastMonth);

                int last3Months = person.Shortlists.Select(x => x.ShortlistedPlayers
                        .Where(x => x.DateAdded > DateTime.Today.AddMonths(-3))
                        .Count()).Sum() - lastMonth;

                shortlistedInLast3Months.Add(last3Months);
            }

            staffActivity.Names = names.ToArray();
            staffActivity.ShortlistedInLastWeek = shortlistedInLastWeek.ToArray();
            staffActivity.ShortlistedInLastMonth = shortlistedInLastMonth.ToArray();
            staffActivity.ShortlistedInLast3Months = shortlistedInLastMonth.ToArray();

            return staffActivity;
        }

        [Route("About")]
        public IActionResult About()
        {
            ViewData["Title"] = "About";
            return View();
        }

        #region Error Handling
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult NotFoundError(SiteProperties.Page page)
        {
            return View("Error", new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                Message = $"{page} Not Found."
            });
        }
        #endregion

        public async Task<IActionResult> GetTopPerformersPartial(string metric, string focus)
        {
            if (String.IsNullOrEmpty(focus) || String.IsNullOrEmpty(metric))
            {
                return StatusCode(500);
            }

            if (focus.Equals("team") && metric.Contains("Per90"))
            {
                metric = metric.Replace("Per90", "PerGame");
            }

            var query = new Query(focus + "MatchLogSummaries")
                .Where("Season", SiteProperties.CurrentSeason)
                .Where("MinutesPlayed", ">", 850)
                .Where(metric, ">", "0")
                .Take(10);

            if (metric.Equals("GkPostShotXgPer90") || metric.Equals("GkPostShotXgPerGame"))
            {
                query.OrderBy(metric);
            }
            else
            {
                query.OrderByDesc(metric);
            }

            var compiler = new SqlServerCompiler();
            var queryString = compiler.Compile(query).ToString();

            List<TopPerformersVM> viewModels;

            if (focus.Equals("player"))
            {
                var players = await _context.PlayerMatchLogSummaries
                    .FromSqlRaw(queryString)

                    .ToListAsync();

                viewModels = _mapper.Map<List<TopPerformersVM>>(players);
            }
            else
            {
                var teams = await _context.TeamMatchLogSummaries
                    .FromSqlRaw(queryString)
                    .ToListAsync();

                viewModels = _mapper.Map<List<TopPerformersVM>>(teams);
            }

            ViewBag.Focus = focus;
            ViewBag.Metric = metric;
            return PartialView("Dashboard/_TopPerformersTable", viewModels);
        }

        public async Task<IActionResult> GetMatchesPartial(string date)
        {
            var dateArr = date.Split("-").Select(x => Convert.ToInt32(x)).ToArray();
            var dt = new DateTime(dateArr[0], dateArr[1], dateArr[2]);

            var matches = await _context.MatchTeamStats
                .Where(x => x.Date.Date == dt)
                .OrderBy(x => x.CompetitionID)
                .ToListAsync();

            return PartialView("Dashboard/_Matches", matches);
        }

        public async Task<IActionResult> GetShortlistPartial(int id)
        {
            var players = await _context.ShortlistedPlayers
                .Include(x => x.Player)
                .ThenInclude(x => x.Position)
                .Where(x => x.ShortlistID == id)
                .OrderByDescending(x => x.DateAdded)
                .Select(x => x.Player)
                .ToListAsync();

            var viewModels = _mapper.Map<List<ShortlistedPlayerLineVM>>(players);

            return PartialView("Dashboard/_ShortlistTable", viewModels);
        }

        public async Task<IActionResult> GetLeagueTablePartial(int id)
        {
            // Get league table lines for league ID
            var leagueTableLines = await _context.LeagueTableLines
                .Where(x => x.Season.Equals(SiteProperties.CurrentSeason)
                            && x.LeagueID == id)
                .OrderByDescending(x => x.Points)
                .ThenByDescending(x => x.GoalDifference)
                .ToListAsync();

            return PartialView("_LeagueTable", leagueTableLines);
        }

        #region Helper Methods
        private int GetFavouriteTeamId()
        {
            return Convert.ToInt32(User.Identities.First().Claims.FirstOrDefault(x => x.Type.Equals(ASClaimTypes.FavouriteTeam)).Value);
        }
        #endregion
    }
}
