using System;
using BerkutBotDataCollector.DataAccess.DataContexts;
using BerkutBotDataCollector.DataAccess.DbDesignFactories;
using BerkutBotDataCollector.DataAccess.Helpers;
using BerkutBotDataCollector.DataAccess.Interfaces;
using BerkutBotDataCollector.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace BerkutBotDataCollector.DataAccess.Repositories
{
	public class MembersRepository : IRepository<Member>
	{
        private readonly MembersDbContext _membersDbContext;
        private object _lockObject;

        public MembersRepository()
		{
            var contextFactory = new MembersContextFactory();
            _membersDbContext = contextFactory.CreateDbContext(default);
        }

        public async Task<Guid> Add(Member entity)
        {
            var existedMember = await GetByTelegramId(entity.TelegramId);

            if (existedMember is null)
            {
                _membersDbContext.Members.Add(entity);
                await _membersDbContext.SaveChangesAsync();
            }
            else
            {
                entity.CopyTo(existedMember);
                _membersDbContext.Members.Update(existedMember);
                await _membersDbContext.SaveChangesAsync();
            }

            return existedMember?.Id ?? entity.Id;
        }

        public async Task<ICollection<Member>> GetAll() => await _membersDbContext.Members.ToListAsync();

        public async Task<Member> GetById(Guid id) => await _membersDbContext.Members.FindAsync(id);

        public async Task<Member> GetByTelegramId(long telegramId) => await _membersDbContext.Members.FirstOrDefaultAsync(c => c.TelegramId == telegramId);
    }
}

