using AkriStat.Areas.Identity.Data;
using AkriStat.Helpers;
using AkriStat.Models;
using AkriStat.ViewModels.Search;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AkriStat.Controllers
{
    public class StandardSearchController : Controller
    {
        private readonly AkriStatDbContext _context;

        public StandardSearchController(AkriStatDbContext context)
        {
            _context = context;
        }

        // Takes a Search POST form and finds matching records
        [HttpPost, Route("Search")]
        [ValidateAntiForgeryToken]
        public IActionResult Search(StandardSearchContainerVM vm)
        {
            // Validation
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            // Converts accented characters in query to standard characters
            var query = Normalizer.NormalizeString(vm.Query).ToUpper();
            var viewModels = new List<StandardSearchResultVM>();

            // Get players whose name contains query
            vm.Players = _context.Players
                .Include(x => x.Nationality)
                .Include(x => x.Position)
                .Where(x => x.NormalizedName.Contains(query)
                            || x.NormalizedFullName.Contains(query))
                .OrderByDescending(x => x.Name)
                .Select(x => new StandardSearchResultVM()
                {
                    ID = x.ID,
                    Name = x.Name,
                    PictureUrl = x.FacePictureUrl,
                    Position = x.Position.Code,
                    NationalityFlagUrl = x.Nationality.FlagUrl
                })
                .ToList();

            // Get teams whose name contains query
            vm.Teams = _context.Teams
                .Include(x => x.CompetitionSeasonTeams)
                .Where(x => x.Name.ToUpper().Contains(query)
                            || x.NormalizedName.Contains(query)
                            || x.FullName.ToUpper().Contains(query)
                            || x.NormalizedFullName.Contains(query))
                .OrderByDescending(x => x.Name)
                .Select(x => new StandardSearchResultVM()
                {
                    ID = x.ID,
                    Name = x.Name
                })
                .ToList();

            // If 1 player found and 0 teams - navigate to that player
            if (vm.Players.Count() == 1 && vm.Teams.Count() == 0)
            {
                return RedirectToAction("Details", "Player", new { id = vm.Players.First().ID });
            }
            // If 1 team found and 0 players - navigate to that team
            if (vm.Teams.Count() == 1 && vm.Players.Count() == 0)
            {
                return RedirectToAction("Details", "Team", new { id = vm.Teams.First().ID });
            }

            ViewData["Title"] = $"Search Results ({vm.Players.Count + vm.Teams.Count})";
            return View(vm);
        }
    }
}
