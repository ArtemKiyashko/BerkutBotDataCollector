using System;
using Telegram.Bot.Types;

namespace BerkutBotDataCollector.Infrastructure
{
    public class TgFromFactory : ITgFromFactory
    {
        private readonly ITgMessageFactory _tgMessageFactory;

        public TgFromFactory(ITgMessageFactory tgMessageFactory)
        {
            _tgMessageFactory = tgMessageFactory;
        }

        public User GetUser(Update tgUpdate) => tgUpdate?.Type switch
        {
            Telegram.Bot.Types.Enums.UpdateType.CallbackQuery => tgUpdate.CallbackQuery.From,
            _ => _tgMessageFactory.GetMessage(tgUpdate)?.From
        };
    }
}

