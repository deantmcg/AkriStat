using AkriStat.Models;
using AkriStat.ViewModels.Administrator;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AkriStat.Controllers
{
    // Ensures Administrator access only
    [Authorize(Roles = "Administrator")]
    public class AdministratorController : Controller
    {
        private readonly AkriStatDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AdministratorController(AkriStatDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        // Returns an Index view of all users
        [HttpGet, Route("Admin/Users")]
        public async Task<IActionResult> ManageUsers()
        {
            // Get all users
            var users = await _context.AspNetUsers
                .Include(x => x.AspNetUserRoles)
                .ThenInclude(x => x.Role)
                .Include(x => x.AspNetUserRoles)
                .ThenInclude(x => x.AspNetUserRoleTeams)
                .ThenInclude(x => x.Team)
                .OrderBy(x => x.AspNetUserRoles.First().Role.Name)
                .ToListAsync();

            var viewModels = _mapper.Map<List<UserIndexVM>>(users);

            ViewData["Title"] = "Manage Users";
            return View("Users/Index", viewModels);
        }

        // Gets the user matching supplied id and returns their Edit view
        [HttpGet, Route("Admin/Users/{id}")]
        public async Task<IActionResult> EditUser(string id)
        {
            // Get user record
            var user = await GetUser(id);

            var vm = _mapper.Map<UserEditVM>(user);
            await PopulateSelectLists(vm);

            // Get user role
            vm.RoleId = user.AspNetUserRoles.First().RoleId;

            // If user has team
            if (user.AspNetUserRoles.First().AspNetUserRoleTeams.FirstOrDefault() != null)
            {
                // Set user team
                vm.TeamId = user.AspNetUserRoles.First().AspNetUserRoleTeams.FirstOrDefault().TeamId;
            }

            ViewData["Title"] = user.FullName;
            return View("Users/Edit", vm);
        }

        // Posts changes to User from the Edit view
        [HttpPost, Route("Admin/Users/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(UserEditVM vm)
        {
            if (!ModelState.IsValid)
            {
                await PopulateSelectLists(vm);
                return View("Users/Edit", vm);
            }

            // Get existing user record
            var user = await GetUser(vm.Id);

            // Map changes to user record
            _mapper.Map(vm, user);

            /* Checks if User role has been changed
               Clears Role collection and re-populates */
            if (user.AspNetUserRoles.Count() > 0 && !user.AspNetUserRoles.First().RoleId.Equals(vm.RoleId))
            {
                user.AspNetUserRoles.Clear();
                user.AspNetUserRoles.Add(new AspNetUserRoles()
                {
                    UserId = vm.Id,
                    RoleId = vm.RoleId
                });
            }

            // Check if user can have team assigned based on their role
            if (UserCanHaveTeam(vm.RoleId))
            {
                // If team exists but it has been removed
                if (user.AspNetUserRoles.First().AspNetUserRoleTeams.Count() > 0 && !vm.TeamId.HasValue)
                {
                    user.AspNetUserRoles.First().AspNetUserRoleTeams.Clear();
                }
                // Check if team has been changed
                else if (user.AspNetUserRoles.First().AspNetUserRoleTeams.FirstOrDefault() != null && vm.TeamId.HasValue &&
                    user.AspNetUserRoles.First().AspNetUserRoleTeams.First().TeamId != vm.TeamId.Value)
                {
                    user.AspNetUserRoles.First().AspNetUserRoleTeams.Clear();
                    user.AspNetUserRoles.First().AspNetUserRoleTeams.Add(new AspNetUserRoleTeams
                    {
                        TeamId = vm.TeamId.Value
                    });
                }
                // If team is null and a new one has been selected
                else if (vm.TeamId.HasValue && user.AspNetUserRoles.First().AspNetUserRoleTeams.Count() == 0)
                {
                    user.AspNetUserRoles.First().AspNetUserRoleTeams.Add(new AspNetUserRoleTeams
                    {
                        TeamId = vm.TeamId.Value
                    });
                }
            }
            // If user cannot have team
            else
            {
                // If user has team - remove it
                if (user.AspNetUserRoles.First().AspNetUserRoleTeams.Count() > 0)
                {
                    user.AspNetUserRoles.First().AspNetUserRoleTeams.Clear();
                }
            }

            await _context.SaveChangesAsync();
            ViewBag.ChangesSaved = true;

            await PopulateSelectLists(vm);
            ViewData["Title"] = user.FullName;
            return View("Users/Edit", vm);
        }

        [Route("Admin/Tasks")]
        public IActionResult TasksIndex()
        {
            ViewData["Title"] = "Tasks";
            return View("Tasks/Index");
        }

        // Updates player season stat summaries
        [HttpGet, Route("Admin/UpdatePlayerMatchLogSummaries")]
        public async Task<IActionResult> UpdatePlayerMatchLogSummaries()
        {
            // Get the database connection string
            var conString = Environment.GetEnvironmentVariable("ConnectionStrings__DEV");
            //var conString = _configuration.GetConnectionString("DEV");

            using (SqlConnection conn = new SqlConnection(conString))
            {
                // Set stored procedure name
                string storedProcedureName = "[dbo].[update_player_matchlog_summaries]";

                // Create SQL command
                SqlCommand command = new SqlCommand(storedProcedureName, conn);

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandTimeout = (int)TimeSpan.FromMinutes(10).TotalSeconds;
                conn.Open();
                var result = command.ExecuteNonQuery();
                conn.Close();
            }

            return Ok();
        }

        [HttpGet, Route("Admin/UpdateTeamMatchLogSummaries")]
        public async Task<IActionResult> UpdateTeamMatchLogSummaries()
        {
            // Get the database connection string
            var conString = Environment.GetEnvironmentVariable("ConnectionStrings__DEV");
            //var conString = _configuration.GetConnectionString("DEV");

            using (SqlConnection conn = new SqlConnection(conString))
            {
                // Set stored procedure name
                string storedProcedureName = "[dbo].[update_team_matchlog_summaries]";

                // Create SQL command
                SqlCommand command = new SqlCommand(storedProcedureName, conn);

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandTimeout = (int)TimeSpan.FromMinutes(10).TotalSeconds;
                conn.Open();
                var result = command.ExecuteNonQuery();
                conn.Close();
            }

            return Ok();
        }

        #region Helper Methods
        // Gets user matching supplied id
        private async Task<AspNetUsers> GetUser(string id)
        {
            return await _context.AspNetUsers
                .Include(x => x.AspNetUserRoles)
                .ThenInclude(x => x.AspNetUserRoleTeams)
                .FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        // Populates select lists used on Edit view
        private async Task PopulateSelectLists(UserEditVM vm)
        {
            vm.RoleSelectList = await _context.AspNetRoles
                .Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id
                })
                .ToListAsync();

            vm.TeamsSelectList = await _context.Teams
                .OrderBy(x => x.Name)
                .Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.ID.ToString()
                })
                .ToListAsync();
        }

        /* Returns whether not a user is in a role that
           allows a team to be associated with them  */
        private bool UserCanHaveTeam(string roleId)
        {
            string[] acceptedRoles =
            {
                "65E60CAA-834F-4470-BC3D-11F8CAACAD73", // Chief Scout
                "B9D0EA79-74E3-4943-A342-494C61F9945C", // Analyst
                "D4F6C614-10F3-4A79-924B-0427F0FE46DD" // Scout
            };

            if (acceptedRoles.Contains(roleId))
                return true;
            else
                return false;
        }
        #endregion
    }
}
