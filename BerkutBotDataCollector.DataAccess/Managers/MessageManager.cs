using System;
using BerkutBotDataCollector.DataAccess.Interfaces;
using BerkutBotDataCollector.DataAccess.Models;

namespace BerkutBotDataCollector.DataAccess.Managers
{
    internal class MessageManager : IMessageManager
    {
        private readonly IRepository<Message> _repository;

        public MessageManager(IRepository<Message> repository)
        {
            _repository = repository;
        }

        public async Task<Guid> AddMessage(Message message)
        {
            await _repository.Add(message);
            await _repository.SaveChanges();
            return message.Id;
        }
    }
}

