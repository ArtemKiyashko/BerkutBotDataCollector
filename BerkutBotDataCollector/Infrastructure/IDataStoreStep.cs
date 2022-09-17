using System;
using Telegram.Bot.Types;

namespace BerkutBotDataCollector.Infrastructure
{
	public interface IDataStoreStep
	{
		IDataStoreStep SetNext(IDataStoreStep step);
		Message Run(Update tgUpdate);
	}
}

