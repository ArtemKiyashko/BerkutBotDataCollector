using System;
using BerkutBotDataCollector.DataAccess.DataContexts;
using BerkutBotDataCollector.DataAccess.DbDesignFactories;
using BerkutBotDataCollector.DataAccess.Helpers;
using BerkutBotDataCollector.DataAccess.Interfaces;
using BerkutBotDataCollector.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace BerkutBotDataCollector.DataAccess.Repositories
{
	internal class MembersRepository : IRepository<Member>
	{
        private readonly MembersDbContext _membersDbContext;

        public MembersRepository()
		{
            var contextFactory = new MembersContextFactory();
            _membersDbContext = contextFactory.CreateDbContext(default);
        }

        public async Task<Guid> Add(Member entity)
        {
            _membersDbContext.Members.Add(entity);
            return entity.Id;
        }

        public IQueryable<Member> GetAll() => _membersDbContext.Members.AsQueryable();

        public async Task<Member> GetById(Guid id) => await _membersDbContext.Members.FindAsync(id);

        public async Task<Member> GetByTelegramId(long telegramId) => await _membersDbContext.Members.FirstOrDefaultAsync(c => c.TelegramId == telegramId);

        public async Task SaveChanges() => await _membersDbContext.SaveChangesAsync();
    }
}

