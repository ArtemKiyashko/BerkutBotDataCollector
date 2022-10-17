using System;
using BerkutBotDataCollector.DataAccess.Models;

namespace BerkutBotDataCollector.DataAccess.Managers
{
    public interface IMessageManager
    {
        Task<Guid> AddMessage(Message message);
    }
}

