using ReactChatApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactChatApp.Services
{
    public interface IChatMessageRepository
    {
        Task AddMessage(ChatMessage message);
        Task<IEnumerable<ChatMessage>> GetTopMessages(int number);
    }
}
