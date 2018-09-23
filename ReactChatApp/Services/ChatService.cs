using ReactChatApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReactChatApp.Services
{
    public class ChatService : IChatService
    {
        private readonly IChatMessageRepository _repository;

        public ChatService(IChatMessageRepository repository)
        {
            _repository = repository;
        }

        public async Task<ChatMessage> CreateNewMessage(string senderName, string message)
        {
            var chatMessage = new ChatMessage(Guid.NewGuid())
            {
                Sender = senderName,
                Message = message
            };
            await _repository.AddMessage(chatMessage);

            return chatMessage;
        }

        public Task<IEnumerable<ChatMessage>> GetAllInitially()
        {
            return _repository.GetTopMessages(100);
        }
    }
}
