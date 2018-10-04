using Microsoft.AspNetCore.Mvc;
using ReactChatApp.Models;
using ReactChatApp.Services;
using ReactChatApp.Services.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
public class ChatController : Controller
{
    private readonly IChatService _chatService;
    private readonly IUserTracker _userTracker;

    public ChatController(IChatService chatService, IUserTracker userTracker)
    {
        _chatService = chatService;
        _userTracker = userTracker;
    }

    // GET: api/<controller>
    [HttpGet("[action]")]
    public async Task<IEnumerable<UserDetails>> LoggedOnUsers()
    {
        return _userTracker.UsersOnline();
    }

    [HttpGet("[action]")]
    public async Task<IEnumerable<ChatMessage>> InitialMessages()
    {
        return await _chatService.GetAllInitially();
    }
}
