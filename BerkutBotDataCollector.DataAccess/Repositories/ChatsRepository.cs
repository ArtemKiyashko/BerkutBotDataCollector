using System;
using BerkutBotDataCollector.DataAccess.DataContexts;
using BerkutBotDataCollector.DataAccess.DbDesignFactories;
using BerkutBotDataCollector.DataAccess.Helpers;
using BerkutBotDataCollector.DataAccess.Interfaces;
using BerkutBotDataCollector.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace BerkutBotDataCollector.DataAccess.Repositories
{
	internal class ChatsRepository : IRepository<Chat>
	{
        private readonly ChatsDbContext _chatsDbContext;

        internal ChatsRepository()
		{
            var contextFactory = new ChatsContextFactory();
            _chatsDbContext = contextFactory.CreateDbContext(default);
        }

        public async Task<Guid> Add(Chat entity)
        {
            _chatsDbContext.Chats.Add(entity);
            return entity.Id;
        }

        public IQueryable<Chat> GetAll() => _chatsDbContext.Chats.AsQueryable();

        public async Task<Chat> GetById(Guid id) => await _chatsDbContext.Chats.FindAsync(id);

        public async Task<Chat> GetByTelegramId(long telegramId) => await _chatsDbContext.Chats.FirstOrDefaultAsync(c => c.TelegramId == telegramId);

        public async Task SaveChanges() => await _chatsDbContext.SaveChangesAsync();
    }
}

