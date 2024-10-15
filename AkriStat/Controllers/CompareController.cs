using AkriStat.Models;
using AkriStat.ViewModels.Compare;
using AkriStat.ViewModels.Search;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace AkriStat.Controllers
{
    public class CompareController : Controller
    {
        private readonly AkriStatDbContext _context;
        private readonly IMapper _mapper;

        public CompareController(AkriStatDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Returns Compare Create view
        [Route("Compare")]
        public IActionResult GetCompare(params int[] playerIds)
        {
            // if players have been sent in to compare
            if (playerIds != null && playerIds.Count() > 0)
            {
                ViewBag.ComparePlayers = playerIds;
            }

            var vm = new ComparePlayerVM();
            GetPlayerSelectList(vm);

            ViewData["Title"] = "Compare Players";
            return View("Compare", vm);
        }

        // Posts Compare criteria and returns results
        [Route("CompareResults")]
        public IActionResult PostCompare(ComparePlayerVM vm)
        {
            GetPlayerSelectList(vm);

            // eliminates any null values
            vm.ChosenPlayerSeasons = vm.ChosenPlayerSeasons.Where(x => x.ID != null && x.Season != null).ToList();

            /* minimum 2 players required to compare
               if less than 2, return Compare Create view */
            if (vm.ChosenPlayerSeasons.Count() < 2)
            {
                return View("Compare", vm);
            }

            foreach (var player in vm.ChosenPlayerSeasons.Where(x => x.ID != null && !string.IsNullOrEmpty(x.Season)))
            {
                // get players summary stats for chosen season
                var result = _context.vwSummariesAdvancedSearch
                    .FirstOrDefault(x => x.ID == player.ID.Value && x.Season == player.Season);

                vm.Results.Add(_mapper.Map<AdvancedSearchResultVM>(result));
            }

            ViewData["Title"] = $"Compare Players ({vm.Results.Count()})";
            return View("CompareResults", vm);
        }

        // Populates player select list
        private void GetPlayerSelectList(ComparePlayerVM vm)
        {
            vm.PlayerSelectList = _context.Players
                .OrderBy(x => x.Name)
                .Select(x => new SelectListItem()
                {
                    Value = x.ID.ToString(),
                    Text = x.Name
                })
                .ToList();
        }

        /* Uses supplied playerId to return all seasons player has appeared in
           Called in view by jQuery */
        [HttpGet]
        public string[] GetPlayerSeasons(int playerId)
        {
            return _context.PlayerMatchLogSummaries
                .Where(x => x.PlayerID == playerId)
                .Select(x => x.Season)
                .ToArray();
        }
    }
}
