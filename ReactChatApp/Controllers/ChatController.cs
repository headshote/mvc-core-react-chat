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
    public async Task<IEnumerable<UserDetails>> LoggedOnUsers()
    {
        return new[]{
            new UserDetails { Id = 1, Name = "Joe Bee" },
            new UserDetails { Id = 3, Name = "Mary Glee" },
            new UserDetails { Id = 2, Name = "Pete Lee" },
            new UserDetails { Id = 4, Name = "Moe Joe" }
        };
    }

    [HttpGet("[action]")]
    public async Task<IEnumerable<ChatMessage>> InitialMessages()
    {
        return await _chatService.GetAllInitially();
    }
}
