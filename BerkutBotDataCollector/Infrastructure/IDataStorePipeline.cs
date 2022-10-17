using System;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace BerkutBotDataCollector.Infrastructure
{
	public interface IDataStorePipeline
	{
		IDataStorePipeline AddStep(IDataStoreStep dataStoreStep);
		Task Run(Update tgUpdate);
	}
}

