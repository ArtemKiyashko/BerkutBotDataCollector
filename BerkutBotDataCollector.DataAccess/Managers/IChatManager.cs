using System;
using BerkutBotDataCollector.DataAccess.Interfaces;
using BerkutBotDataCollector.DataAccess.Models;

namespace BerkutBotDataCollector.DataAccess.Managers
{
    public interface IChatManager
    {
        Task<IEnumerable<Chat>> GetAllChats();
        Task<IEnumerable<Chat>> GetActiveChats();
        Task<Guid> AddChat(Chat chat);
    }
}

