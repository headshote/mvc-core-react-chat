using Microsoft.AspNetCore.Mvc;
using ReactChatApp.Models;
using ReactChatApp.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]

public class ChatController : Controller
{
    private readonly IChatService _chatService;

    public ChatController(IChatService chatService)
    {
        _chatService = chatService;
    }

    // GET: api/<controller>
    [HttpGet("[action]")]
    public IEnumerable<UserDetails> LoggedOnUsers()
    {
        return new[]{
            new UserDetails { Id = 1, Name = "Joe" },
            new UserDetails { Id = 3, Name = "Mary" },
            new UserDetails { Id = 2, Name = "Pete" },
            new UserDetails { Id = 4, Name = "Moe" }
        };
    }

    [HttpGet("[action]")]
    public async Task<IEnumerable<ChatMessage>> InitialMessages()
    {
        return await _chatService.GetAllInitially();
    }
}
