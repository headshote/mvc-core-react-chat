using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReactChatApp.Areas.Identity.Data;
using ReactChatApp.Services.Users;

namespace ReactChatApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserTracker _userTracker;
        private readonly UserManager<ReactChatAppUser> _userManager;

        public HomeController(IUserTracker userTracker,
            UserManager<ReactChatAppUser> userManager)
        {
            _userTracker = userTracker;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var user = HttpContext.User?.Identity as ClaimsIdentity;
            if (user != null && user.IsAuthenticated)
            {
                _userTracker.AddUser(_userManager.GetUserId(User), user.Name);
            }

            return View();
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }
    }
}
