using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ReactChatApp.Areas.Identity.Data;
using ReactChatApp.Services.Users;

namespace ReactChatApp.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<ReactChatAppUser> _signInManager;
        private readonly ILogger<LogoutModel> _logger;
        private readonly UserManager<ReactChatAppUser> _userManager;
        private readonly IUserTracker _userTracker;

        public LogoutModel(SignInManager<ReactChatAppUser> signInManager,
            ILogger<LogoutModel> logger,
            UserManager<ReactChatAppUser> userManager,
            IUserTracker userTracker)
        {
            _signInManager = signInManager;
            _logger = logger;
            _userManager = userManager;
            _userTracker = userTracker;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();

            _logger.LogInformation("User logged out.");
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return Page();
            }
        }
    }
}