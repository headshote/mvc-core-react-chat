using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using ReactChatApp.Services;

namespace ReactChatApp.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IChatService _chatService;

        public ChatHub(IChatService chatService)
        {
            _chatService = chatService;
        }

        public void AddMessage(string message)
        {
            var username = Context.User.Identity.Name;
            var chatMessage = _chatService.CreateNewMessage(username, message);
            // Call the MessageAdded method to update clients.
            //Clients.All.InvokeAsync("MessageAdded", chatMessage);
        }

    }
}
