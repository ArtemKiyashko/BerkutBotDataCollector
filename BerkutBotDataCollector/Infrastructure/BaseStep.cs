using System;
using Telegram.Bot.Types;

namespace BerkutBotDataCollector.Infrastructure
{
	internal abstract class BaseStep : IDataStoreStep
	{
        private IDataStoreStep _next;

        public virtual Message Run(Update tgUpdate)
        {
            if (_next is null)
                return null;
            return _next.Run(tgUpdate);
        }

        public IDataStoreStep SetNext(IDataStoreStep step)
        {
            _next = step;
            return _next;
        }
    }
}

