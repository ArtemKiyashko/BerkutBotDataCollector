using System;
using BerkutBotDataCollector.DataAccess.DataContexts;
using BerkutBotDataCollector.DataAccess.Interfaces;
using BerkutBotDataCollector.DataAccess.Models;

namespace BerkutBotDataCollector.DataAccess.Repositories
{
	public class ChatsRepository : IRepository<Chat>
	{
        private readonly ChatsDbContext _chatsDbContext;

        public ChatsRepository(ChatsDbContext chatsDbContext)
		{
            _chatsDbContext = chatsDbContext;
        }

        public async Task<Guid> Add(Chat entity)
        {
            _chatsDbContext.Chats.Add(entity);
            await _chatsDbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<Chat> Find(Func<Chat, bool> func) => _chatsDbContext.Chats.SingleOrDefault(func);

        public async Task<Chat> GetById(Guid id) => await _chatsDbContext.Chats.FindAsync(id);
    }
}

