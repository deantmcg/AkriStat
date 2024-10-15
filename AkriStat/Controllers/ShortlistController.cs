using AkriStat.Constants;
using AkriStat.Models;
using AkriStat.ViewModels.Shortlist;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AkriStat.Controllers
{
    [Authorize]
    public class ShortlistController : Controller
    {
        private static AkriStatDbContext _context;
        private static IMapper _mapper;

        public ShortlistController(AkriStatDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Returns an Index view of all shortlists for logged in user
        [Route("Shortlists")]
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ASClaimTypes.NameIdentifier);

            // Get all shortlists for user
            var shortlists = await _context.Shortlists
                .Include(x => x.ShortlistedPlayers)
                .Where(x => x.UserID.Equals(userId)
                            && x.IsActive)
                .OrderBy(x => x.CreatedDate)
                .ToListAsync();

            var viewModels = _mapper.Map<List<ShortlistIndexVM>>(shortlists);

            ViewData["Title"] = "My Shortlists";
            return View(viewModels);
        }

        // Returns the Create Shortlist view
        [HttpGet, Route("Shortlists/Create")]
        public IActionResult Create(string returnUrl)
        {
            var viewModel = new ShortlistCreateVM();
            TempData["ReturnUrl"] = returnUrl ?? "/Shortlists";

            ViewData["Title"] = "Create Shortlist";
            return View(viewModel);
        }

        // Taks POST form and creates Shortlist
        [HttpPost, Route("Shortlists/Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ShortlistCreateVM viewModel)
        {
            // Validation
            if (!ModelState.IsValid)
                return View(viewModel);

            // Creates new shortlist
            var shortlist = new Shortlists()
            {
                UserID = User.FindFirstValue(ASClaimTypes.NameIdentifier),
                Name = viewModel.Name,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                IsActive = true,
                IsDefault = false
            };

            _context.Shortlists.Add(shortlist);
            await _context.SaveChangesAsync();

            string returnUrl = TempData["ReturnUrl"].ToString();

            return Redirect(returnUrl);
        }

        // Returns the Edit Shortlist view
        [HttpGet, Route("Shortlists/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            // Get shortlist for supplied ID
            var shortlist = await _context.Shortlists
                .Include(x => x.ShortlistedPlayers)
                .FirstOrDefaultAsync(x => x.ID == id && x.IsActive);

            var viewModel = _mapper.Map<ShortlistDetailsVM>(shortlist);

            // If user has just saved changes
            if (TempData["MessageToDisplay"] != null)
            {
                ViewBag.MessageToDisplay = TempData["MessageToDisplay"];
                TempData.Remove("MessageToDisplay");
            }

            ViewData["Title"] = $"Shortlist ({shortlist.Name})";
            return View("Details", viewModel);
        }

        // Takes POST form and updates a shortlist
        [HttpPost, Route("Shortlists/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ShortlistDetailsVM viewModel)
        {
            // Validation
            if (!ModelState.IsValid)
            {
                ViewBag.ChangesSaved = TempData["ChangesSaved"];
                return View("Details", viewModel);
            }

            // Get current shortlist record
            var shortlist = await _context.Shortlists
                .FirstOrDefaultAsync(x => x.ID == viewModel.ID);

            shortlist.Name = viewModel.Name;
            shortlist.LastUpdatedDate = DateTime.Now;
            await _context.SaveChangesAsync();

            // Set display message
            TempData["MessageToDisplay"] = $"Shortlist: {shortlist.Name} changes saved successfully.";
            return RedirectToAction(nameof(Edit), new { id = viewModel.ID });
        }

        // Soft-deletes a shortlist for supplied ID
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            // Get shortlist
            var shortlist = await _context.Shortlists
                .FirstOrDefaultAsync(x => x.ID == id);

            if (shortlist == null)
                return RedirectToAction("NotFoundError", "Home", new { page = SiteProperties.Page.Shortlist });

            // Set to inactive instead of delete (reversible)
            shortlist.IsActive = false;
            shortlist.LastUpdatedDate = DateTime.Now;

            await _context.SaveChangesAsync();

            // Set display message
            TempData["MessageToDisplay"] = $"Shortlist: {shortlist.Name} deleted successfully.";
            return RedirectToAction(nameof(Index));
        }

        // Gets a shortlist record matching supplied ID
        public async Task<IActionResult> GetShortlist(int id)
        {
            var players = await _context.ShortlistedPlayers
                .Include(x => x.Player)
                .Where(x => x.ShortlistID == id)
                .Select(x => x.Player)
                .ToListAsync();

            var viewModel = _mapper.Map<List<ShortlistedPlayerLineVM>>(players);

            return PartialView("_ShortlistPlayersTable", viewModel);
        }
    }
}
