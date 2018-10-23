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

        public HomeController(IUserTracker userTracker)
        {
            _userTracker = userTracker;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }
    }
}
