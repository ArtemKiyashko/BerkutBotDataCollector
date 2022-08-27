using System;
using BerkutBotDataCollector.DataAccess.DataContexts;
using BerkutBotDataCollector.DataAccess.DbDesignFactories;
using BerkutBotDataCollector.DataAccess.Helpers;
using BerkutBotDataCollector.DataAccess.Interfaces;
using BerkutBotDataCollector.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace BerkutBotDataCollector.DataAccess.Repositories
{
	public class ChatsRepository : IRepository<Chat>
	{
        private readonly ChatsDbContext _chatsDbContext;

        public ChatsRepository()
		{
            var contextFactory = new ChatsContextFactory();
            _chatsDbContext = contextFactory.CreateDbContext(default);
        }

        public async Task<Guid> Add(Chat entity)
        {
            var existedChat = await GetByTelegramId(entity.TelegramId);

            if (existedChat is not null)
            {
                entity.CopyTo(existedChat);
                await _chatsDbContext.SaveChangesAsync();
                return existedChat.Id;
            }

            _chatsDbContext.Chats.Add(entity);
            await _chatsDbContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<Chat> Find(Func<Chat, bool> func) => await _chatsDbContext.Chats.FirstOrDefaultAsync(c => func(c));

        public async Task<Chat> GetById(Guid id) => await _chatsDbContext.Chats.FindAsync(id);

        public async Task<Chat> GetByTelegramId(long telegramId) => await _chatsDbContext.Chats.FirstOrDefaultAsync(c => c.TelegramId == telegramId);
    }
}

