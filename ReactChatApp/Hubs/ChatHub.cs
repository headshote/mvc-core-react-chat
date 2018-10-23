using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using ReactChatApp.Areas.Identity.Data;
using ReactChatApp.Models;
using ReactChatApp.Services;
using ReactChatApp.Services.Users;

namespace ReactChatApp.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IChatService _chatService;
        private readonly IUserTracker _userTracker;
        private readonly UserManager<ReactChatAppUser> _userManager;

        public ChatHub(IChatService chatService,
            IUserTracker userTracker,
            UserManager<ReactChatAppUser> userManager)
        {
            _chatService = chatService;
            _userTracker = userTracker;
            _userManager = userManager;
            _userTracker.UserJoined += OnUsersJoined;
            _userTracker.UserLeft += OnUsersLeft;
        }

        public override Task OnConnectedAsync()
        {
            var user = Context.User?.Identity as ClaimsIdentity;
            if (user != null && user.IsAuthenticated)
            {
                _userTracker.AddUser(_userManager.GetUserId(Context.User), user.Name);
            }

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            var user = Context.User?.Identity as ClaimsIdentity;
            if (user != null && user.IsAuthenticated)
            {
                _userTracker.RemoveUser(_userManager.GetUserId(Context.User));
            }

            return base.OnDisconnectedAsync(exception);
        }

        public async Task AddMessage(string message)
        {
            var username = Context.User.Identity.Name;
            var chatMessage = await _chatService.CreateNewMessage(username, message);

            await Clients.All.SendAsync("MessageAdded", chatMessage);
        }

        public async void OnUsersJoined(UserDetails user)
        {
            await Clients.All.SendAsync("UsersJoined", user);
        }

        public async void OnUsersLeft(UserDetails user)
        {
            await Clients.All.SendAsync("UsersLeft", user);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if(disposing)
            {
                _userTracker.UserJoined -= OnUsersJoined;
                _userTracker.UserLeft -= OnUsersLeft;
            }
        }
    }
}
