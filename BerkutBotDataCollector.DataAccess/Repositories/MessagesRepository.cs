using System;
using BerkutBotDataCollector.DataAccess.DataContexts;
using BerkutBotDataCollector.DataAccess.DbDesignFactories;
using BerkutBotDataCollector.DataAccess.Helpers;
using BerkutBotDataCollector.DataAccess.Interfaces;
using BerkutBotDataCollector.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace BerkutBotDataCollector.DataAccess.Repositories
{
	internal class MessagesRepository : IRepository<Message>
	{
        private readonly MessagesDbContext _messagesDbContext;

        internal MessagesRepository()
		{
            var contextFactory = new MessagesContextFactory();
            _messagesDbContext = contextFactory.CreateDbContext(default);
        }

        public async Task<Guid> Add(Message entity)
        {
            _messagesDbContext.Messages.Add(entity);
            return entity.Id;
        }

        public IQueryable<Message> GetAll() => _messagesDbContext.Messages.AsQueryable();

        public async Task<Message> GetById(Guid id) => await _messagesDbContext.Messages.FindAsync(id);

        public async Task<Message> GetByTelegramId(long telegramId) => await _messagesDbContext.Messages.FirstOrDefaultAsync(c => c.TelegramId == telegramId);

        public async Task SaveChanges() => await _messagesDbContext.SaveChangesAsync();
    }
}

