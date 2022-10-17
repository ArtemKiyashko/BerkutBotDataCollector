using System;
using BerkutBotDataCollector.DataAccess.Models;

namespace BerkutBotDataCollector.DataAccess.Managers
{
    public interface IMemberManager
    {
        Task<Guid> AddMember(Member member);
    }
}

