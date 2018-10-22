using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using ReactChatApp.Models;
using ReactChatApp.Services;
using ReactChatApp.Services.Users;

namespace ReactChatApp.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IChatService _chatService;
        private readonly IUserTracker _userTracker;

        public ChatHub(IChatService chatService, IUserTracker userTracker)
        {
            _chatService = chatService;
            _userTracker = userTracker;
            _userTracker.UserJoined += OnUsersJoined;
            _userTracker.UserLeft += OnUsersLeft;
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
