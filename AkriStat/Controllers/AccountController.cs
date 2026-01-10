using AkriStat.Constants;
using AkriStat.Models;
using AkriStat.ViewModels.Account;
using AkriStat.ViewModels.Administrator;
using AkriStat.ViewModels.Shortlist;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AkriStat.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly AkriStatDbContext _context;
        private readonly IMapper _mapper;

        public AccountController(AkriStatDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            // Get logged in user
            AspNetUsers user = await GetUser();

            var viewModel = _mapper.Map<AccountDetailsVM>(user);

            await PopulateSelectLists(viewModel);
            ViewData["Title"] = "Edit Account";
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AccountDetailsVM viewModel)
        {
            await PopulateSelectLists(viewModel);
            ViewData["Title"] = "Edit Account";

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            // Get logged in user
            var user = await GetUser();

            // If user has changed their name
            if (!user.FullName.Equals(viewModel.FullName))
            {
                // Update fullname claim
                user.AspNetUserClaims.FirstOrDefault(x => x.ClaimType.Equals(ASClaimTypes.FullName))
                    .ClaimValue = viewModel.FullName;
            }

            // Map changes to database record
            _mapper.Map(viewModel, user);

            // If user has changed their favourite team
            if (viewModel.FavouriteTeamId != GetFavouriteTeamId())
            {
                SetFavouriteTeam(user, viewModel.FavouriteTeamId);
            }

            try
            {
                await _context.SaveChangesAsync();
                ViewBag.ChangesSaved = true;
            }
            catch (Exception e)
            {
                ViewBag.ChangesSaved = false;
                ViewBag.ErrorMessage = e.InnerException.Message;
            }

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> DeletedShortlists()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Get soft deleted shortlists for logged in user
            var shortlists = await _context.Shortlists
                .Include(x => x.ShortlistedPlayers)
                .Where(x => x.UserID.Equals(userId) && !x.IsActive)
                .ToListAsync();

            var viewModels = _mapper.Map<List<ShortlistIndexVM>>(shortlists);

            if (TempData["MessageToDisplay"] != null)
            {
                ViewBag.MessageToDisplay = TempData["MessageToDisplay"];
                TempData.Remove("MessageToDisplay");
            }

            ViewData["Title"] = "Deleted Shortlists";
            return View(viewModels);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateShortlist(string shortlistAction, int id)
        {
            // Get shortlist
            var shortlist = await _context.Shortlists.FirstOrDefaultAsync(x => x.ID == id);

            // If user chose to recover a shortist
            if (shortlistAction.Equals("recover"))
            {
                shortlist.IsActive = true;
                shortlist.LastUpdatedDate = DateTime.Now;
                await _context.SaveChangesAsync();
                TempData["MessageToDisplay"] = $"Shortlist: {shortlist.Name} recovered successfully.";
                return RedirectToAction("Edit", "Shortlist", new { id = shortlist.ID });
            }
            // If user chose to permanently delete a shortist
            else if (shortlistAction.Equals("delete"))
            {
                _context.Shortlists.Remove(shortlist);
                await _context.SaveChangesAsync();
                TempData["MessageToDisplay"] = $"Shortlist: {shortlist.Name} permanently deleted.";
                return RedirectToAction(nameof(DeletedShortlists));
            }

            return StatusCode(500);
        }

        [HttpGet, Route("MyStaff"), Authorize(Roles = "Chief Scout")]
        public async Task<IActionResult> StaffIndex()
        {
            // Get logged in user ID
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Get team user works for
            var team = _context.AspNetUserRoleTeams.Include(x => x.Team).FirstOrDefault(x => x.UserId.Equals(userId)).Team;

            // Get IDs of staff who work for same team as user
            var staffIds = _context.AspNetUserRoleTeams
                .Include(x => x.AspNetUserRoles)
                .ThenInclude(x => x.User)
                .Where(x => x.TeamId.Equals(team.ID) && !x.AspNetUserRoles.UserId.Equals(userId))
                .Select(x => x.AspNetUserRoles.User.Id)
                .ToList();

            ViewBag.RolesSelectList = await _context.AspNetRoles
                .Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id
                })
                .ToListAsync();

            // Get users who work for same team as logged in user
            var viewModels = _context.AspNetUsers
                .Include(x => x.AspNetUserRoles)
                .ThenInclude(x => x.AspNetUserRoleTeams)
                .Where(x => staffIds.Contains(x.Id))
                .ToList()
                .Select(x => new StaffDetailsVM()
                {
                    Id = x.Id,
                    FullName = $"{x.FirstName} {x.Surname}",
                    RoleId = x.AspNetUserRoles.First().RoleId,
                    TeamId = x.AspNetUserRoles.First().AspNetUserRoleTeams.First().TeamId
                })
            .ToList();

            // If user has just updated staff roles
            if (TempData["MessageToDisplay"] != null)
            {
                ViewBag.MessageToDisplay = TempData["MessageToDisplay"];
                TempData.Remove("MessageToDisplay");
                ViewBag.Success = TempData["Success"];
                TempData.Remove("Success");
            }

            ViewBag.TeamId = team.ID;
            ViewBag.TeamName = team.Name;
            return View("MyStaff", viewModels);
        }

        // Receives form submit from previous method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditMyStaff(List<StaffDetailsVM> viewModels)
        {
            // For each staff member on user's team
            foreach (var vm in viewModels)
            {
                // Get user record
                var user = await _context.AspNetUsers
                    .Include(x => x.AspNetUserRoles)
                    .ThenInclude(x => x.AspNetUserRoleTeams)
                    .FirstOrDefaultAsync(x => x.Id.Equals(vm.Id));

                // If user's role has chaned
                if (!user.AspNetUserRoles.First().RoleId.Equals(vm.RoleId))
                {
                    user.AspNetUserRoles.Clear();

                    // Add role
                    user.AspNetUserRoles.Add(new AspNetUserRoles()
                    {
                        RoleId = vm.RoleId
                    });

                    // Add team to role
                    user.AspNetUserRoles.First().AspNetUserRoleTeams.Add(new AspNetUserRoleTeams()
                    {
                        TeamId = vm.TeamId
                    });
                }
            }

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

            return RedirectToAction(nameof(StaffIndex));
        }

        #region Helper Methods
        // Get logged in user
        private async Task<AspNetUsers> GetUser()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return await _context.AspNetUsers
                .Include(x => x.AspNetUserClaims)
                .FirstOrDefaultAsync(x => x.Id.Equals(userId));
        }

        // Generate drop down lists
        private async Task PopulateSelectLists(AccountDetailsVM vm)
        {
            vm.TeamsSelectList = await _context.Teams
                .Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.ID.ToString()
                })
                .ToListAsync();
        }

        // Updates user favouriteteam claim
        private void SetFavouriteTeam(AspNetUsers user, int teamId)
        {
            user.AspNetUserClaims.FirstOrDefault(x => x.ClaimType.Equals(ASClaimTypes.FavouriteTeam))
                .ClaimValue = teamId.ToString();
        }

        // Gets value of user's favouriteteam claim
        private int GetFavouriteTeamId()
        {
            return Convert.ToInt32(User.Identities.First().Claims.FirstOrDefault(x => x.Type.Equals(ASClaimTypes.FavouriteTeam)).Value);
        }
        #endregion
    }
}
