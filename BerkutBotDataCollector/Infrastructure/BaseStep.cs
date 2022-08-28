using System;
using Telegram.Bot.Types;

namespace BerkutBotDataCollector.Infrastructure
{
	internal abstract class BaseStep : IDataStoreStep
	{
        private IDataStoreStep _next;

        public virtual Message Run(Message tgMessage)
        {
            if (_next is null)
                return null;
            return _next.Run(tgMessage);
        }

        public IDataStoreStep SetNext(IDataStoreStep step)
        {
            _next = step;
            return _next;
        }
    }
}

