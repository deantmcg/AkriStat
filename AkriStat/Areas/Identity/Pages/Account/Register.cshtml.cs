using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using AkriStat.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using AkriStat.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AkriStat.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly AkriStatDbContext _context;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            AkriStatDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public List<SelectListItem> TeamsSelectList { get; set; }

        public class InputModel
        {
            [Required]
            [StringLength(150, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Required]
            [StringLength(150, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
            [Display(Name = "Surname")]
            public string Surname { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [Display(Name = "Favourite Team")]
            public int FavouriteTeamId { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;

            TeamsSelectList = _context.Teams
                .OrderBy(x => x.Name)
                .Select(x => new SelectListItem() { Value = x.ID.ToString(), Text = x.Name })
                .ToList();

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser 
                { 
                    FirstName = Input.FirstName,
                    Surname = Input.Surname,
                    FullName = $"{Input.FirstName} {Input.Surname}",
                    UserName = Input.Email, 
                    Email = Input.Email 
                };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    // Create new standard user
                    await PopulateNewUserData(user, Input.FavouriteTeamId);

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // Only reached if there was a failure
            return Page();
        }

        /*
         * Creates a new Standard User
         * Creates the 'Default' shortlist for new user
         */
        private async Task PopulateNewUserData(ApplicationUser user, int favouriteTeamId)
        {
            var role = new AspNetUserRoles()
            {
                RoleId = Constants.UserRoles.StandardUserId.ToString(),
                UserId = user.Id
            };

            _context.AspNetUserRoles.Add(role);
            var roleResult = await _context.SaveChangesAsync();
            if (roleResult == 1)
            {
                _logger.LogInformation("User role set to Standard");
            }
            else
            {
                _logger.LogInformation("User role create failed");
            }

            var dtNow = DateTime.Now;
            var shortlist = new Shortlists()
            {
                UserID = user.Id,
                Name = "Default",
                CreatedDate = dtNow,
                LastUpdatedDate = dtNow,
                IsActive = true,
                IsDefault = true
            };

            _context.Shortlists.Add(shortlist);
            var shortlistResult = await _context.SaveChangesAsync();

            if (shortlistResult == 1)
            {
                _logger.LogInformation("User default shortlist created");
            }
            else
            {
                _logger.LogInformation("User default shortlist create failed");
            }

            var fullNameClaim = new AspNetUserClaims()
            {
                ClaimType = "fullname",
                ClaimValue = user.FullName,
                UserId = user.Id
            };

            var favouriteTeamClaim = new AspNetUserClaims()
            {
                ClaimType = "favouriteteam",
                ClaimValue = favouriteTeamId.ToString(),
                UserId = user.Id
            };

            _context.AspNetUserClaims.Add(fullNameClaim);
            _context.AspNetUserClaims.Add(favouriteTeamClaim);
            var claimResult = await _context.SaveChangesAsync();

            if (claimResult == 1)
            {
                _logger.LogInformation("User claim created: Full Name");
                _logger.LogInformation("User claim created: Favourite Team");
            }
            else
            {
                _logger.LogInformation("User claim create failed: Full Name");
                _logger.LogInformation("User claim create failed: Favourite Team");
            }
        }
    }
}
