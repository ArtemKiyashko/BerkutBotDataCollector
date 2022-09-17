using System;
using Telegram.Bot.Types;

namespace BerkutBotDataCollector.Infrastructure
{
    public interface ITgFromFactory
    {
        public User GetUser(Update tgUpdate);
    }
}

