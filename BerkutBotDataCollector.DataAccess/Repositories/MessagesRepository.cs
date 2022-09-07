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

        public MessagesRepository(MessagesDbContext messagesDbContext)
		{
            _messagesDbContext = messagesDbContext;
        }

        public async Task<Guid> Add(Message entity)
        {
            try
            {
                _messagesDbContext.Add(entity);
                await _messagesDbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {

            }

            return entity.Id;
        }

        public async Task<ICollection<Message>> GetAll() => await _messagesDbContext.Messages.ToListAsync();

        public async Task<Message> GetById(Guid id) => await _messagesDbContext.Messages.FindAsync(id);

        public async Task<Message> GetByTelegramId(long telegramId) => await _messagesDbContext.Messages.FirstOrDefaultAsync(c => c.TelegramId == telegramId);
    }
}

