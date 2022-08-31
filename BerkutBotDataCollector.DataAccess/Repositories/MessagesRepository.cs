using System;
using BerkutBotDataCollector.DataAccess.DataContexts;
using BerkutBotDataCollector.DataAccess.DbDesignFactories;
using BerkutBotDataCollector.DataAccess.Helpers;
using BerkutBotDataCollector.DataAccess.Interfaces;
using BerkutBotDataCollector.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace BerkutBotDataCollector.DataAccess.Repositories
{
	public class MessagesRepository : IRepository<Message>
	{
        private readonly MessagesDbContext _messagesDbContext;

        public MessagesRepository()
		{
            var contextFactory = new MessagesContextFactory();
            _messagesDbContext = contextFactory.CreateDbContext(default);
        }

        public async Task<Guid> Add(Message entity)
        {
            _messagesDbContext.Messages.Add(entity);
            await _messagesDbContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<ICollection<Message>> GetAll() => await _messagesDbContext.Messages.ToListAsync();

        public async Task<Message> GetById(Guid id) => await _messagesDbContext.Messages.FindAsync(id);

        public async Task<Message> GetByTelegramId(long telegramId) => await _messagesDbContext.Messages.FirstOrDefaultAsync(c => c.TelegramId == telegramId);
    }
}

