using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using FlightManager.Common;
using FlightManager.Data.Entities;
using FlightManager.Services.Mappings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace HotelManager.Areas.Identity.Pages.Account
{
    [Authorize(Roles = GlobalConstants.Roles.Administrator)]
    public class RegisterModel : PageModel
    {
        private const string EmailConfirmationUrl = "/Account/ConfirmEmail";

        private readonly UserManager<User> userManager;
        private readonly ILogger<RegisterModel> logger;
        private readonly IEmailSender emailSender;

        public RegisterModel(
            UserManager<User> userManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            this.userManager = userManager;
            this.logger = logger;
            this.emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl = null) => ReturnUrl = returnUrl;

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            if (await userManager.FindByEmailAsync(Input.Email) != null)
            {
                ModelState.AddModelError(nameof(Input.Email), "User with the same email already exists!");
            }

            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = Input.To<User>();

                IdentityResult result = await userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    logger.LogInformation("User created a new account with password.");

                    await userManager.AddToRoleAsync(user, GlobalConstants.Roles.Employee);
                    return LocalRedirect(returnUrl);
                }

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return Page();
        }

        public class InputModel
        {
            public string Name { get; set; }

            public string Surname { get; set; }
            [StringLength(10,MinimumLength =10)]
            public string PersonalNumber { get; set; }

            public string Address { get; set; }

            [Required]
            public string Username { get; set; }

            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Compare(nameof(Password))]
            public string ConfirmPassword { get; set; }
        }
    }
}
