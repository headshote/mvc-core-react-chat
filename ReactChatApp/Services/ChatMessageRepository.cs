using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ReactChatApp.Models;

namespace ReactChatApp.Services
{
    public class ChatMessageRepository : IChatMessageRepository
    {
        private readonly string _tableName;
        private readonly IConfiguration _configuration;

        public ChatMessageRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task AddMessage(ChatMessage message)
        {
            return;
        }

        public async Task<IEnumerable<ChatMessage>> GetTopMessages(int number)
        {
            return new List<ChatMessage>();
        }
    }
}
