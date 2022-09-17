using System;
using Telegram.Bot.Types;

namespace BerkutBotDataCollector.Infrastructure
{
	public interface IDataStorePipeline
	{
		IDataStorePipeline AddStep(IDataStoreStep dataStoreStep);
		void Run(Update tgUpdate);
	}
}

