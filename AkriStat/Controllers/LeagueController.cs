using AkriStat.Models;
using AkriStat.ViewModels.League;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkriStat.Controllers
{
    public class LeagueController : Controller
    {
        private static AkriStatDbContext _context;
        private static IMapper _mapper;

        public LeagueController(AkriStatDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Returns an Index view of all leagues
        public async Task<IActionResult> Index()
        {
            var leagues = await _context.Competitions
                .OrderBy(x => x.NationID)
                .ToListAsync();

            ViewData["Title"] = "Leagues";
            return View(leagues);
        }

        // Gets the league matching supplied id and returns their Details view
        [Route("Leagues/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var vm = new LeagueDetailsVM()
            {
                Id = id,
                Name = _context.Competitions
                    .FirstOrDefault(x => x.ID == id)
                    .Name
            };

            // Gets the league table
            var leagueTableLines = await _context.LeagueTableLines
                    .Where(x => x.LeagueID == id)
                    .OrderByDescending(x => x.Points.Value)
                    .ThenByDescending(x => x.GoalDifference.Value)
                    .ThenByDescending(x => x.GoalsScored.Value)
                    .ToListAsync();

            vm.LeagueTableLines = _mapper.Map<List<LeagueTableLineVM>>(leagueTableLines);

            // Gets all leagues matchweeks for current season
            vm.Matchweeks = _context.Matches
                .Where(x => x.CompetitionID == id && x.Season.Equals(Constants.SiteProperties.CurrentSeason))
                .Select(x => new SelectListItem() { Text = x.Round })
                .Distinct()
                .OrderBy(x => Convert.ToInt32(x.Text.Replace("Matchweek ", "")))
                .ToList();

            ViewData["Title"] = vm.Name;
            return View(vm);
        }

        // Returns partial view containing league matches for chosen matchweek
        public async Task<IActionResult> GetMatches(int competitionId, string matchweek)
        {
            return PartialView("_Matches", await _context.Matches
                .Include(x => x.TeamOne)
                .Include(x => x.TeamTwo)
                .Where(x => x.CompetitionID == competitionId)
                .Where(x => x.Round.ToUpper().Equals(matchweek.ToUpper().Replace("_", " ")))
                .OrderBy(x => Convert.ToInt32(x.Round.Replace("Matchweek ", "")))
                .ThenByDescending(x => x.Date)
                .ToListAsync());
        }
    }
}
