using System;
using BerkutBotDataCollector.DataAccess.DataContexts;
using BerkutBotDataCollector.DataAccess.Helpers;
using BerkutBotDataCollector.DataAccess.Interfaces;
using BerkutBotDataCollector.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace BerkutBotDataCollector.DataAccess.Managers
{
    internal class ChatManager : IChatManager
    {
        private readonly IRepository<Chat> _repository;

        public ChatManager(IRepository<Chat> repository)
        {
            _repository = repository;
        }

        public async Task<Guid> AddChat(Chat chat)
        {
            var existedChat = await _repository.GetByTelegramId(chat.TelegramId);

            if (existedChat is not null)
            {
                chat.CopyTo(existedChat);
                await _repository.SaveChanges();
                return existedChat.Id;
            }

            await _repository.Add(chat);
            await _repository.SaveChanges();

            return chat.Id;
        }

        public async Task<IEnumerable<Chat>> GetActiveChats() => await _repository.GetAll().Where(chat => !chat.IsDeleted).ToListAsync();

        public async Task<IEnumerable<Chat>> GetAllChats() => await _repository.GetAll().ToListAsync();
    }
}

