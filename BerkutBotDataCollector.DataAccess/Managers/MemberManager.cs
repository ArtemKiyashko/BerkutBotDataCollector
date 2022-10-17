using System;
using BerkutBotDataCollector.DataAccess.DataContexts;
using BerkutBotDataCollector.DataAccess.Helpers;
using BerkutBotDataCollector.DataAccess.Interfaces;
using BerkutBotDataCollector.DataAccess.Models;

namespace BerkutBotDataCollector.DataAccess.Managers
{
    internal class MemberManager : IMemberManager
    {
        private readonly IRepository<Member> _repository;

        public MemberManager(IRepository<Member> repository)
        {
            _repository = repository;
        }

        public async Task<Guid> AddMember(Member member)
        {
            var existedMember = await _repository.GetByTelegramId(member.TelegramId);

            if (existedMember is null)
            {
                await _repository.Add(member);
                await _repository.SaveChanges();
            }
            else
            {
                member.CopyTo(existedMember);
                await _repository.SaveChanges();
            }

            return existedMember?.Id ?? member.Id;
        }
    }
}

