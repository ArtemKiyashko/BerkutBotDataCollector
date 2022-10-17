using System;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace BerkutBotDataCollector.Infrastructure
{
	public interface IDataStoreStep
	{
		IDataStoreStep SetNext(IDataStoreStep step);
		Task<Message> Run(Update tgUpdate);
	}
}

