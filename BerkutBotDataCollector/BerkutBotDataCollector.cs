using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using BerkutBotDataCollector.Infrastructure;

namespace BerkutBotDataCollector
{
    public class BerkutBotDataCollector
    {
        private readonly IDataStorePipeline _dataStorePipeline;

        public BerkutBotDataCollector(
            IDataStorePipeline dataStorePipeline)
        {
            _dataStorePipeline = dataStorePipeline;
        }

        [FunctionName("BerkutBotDataCollector")]
        public void Run([ServiceBusTrigger("alltgmessages", "datacollector", Connection = "ServiceBusOptions", IsSessionsEnabled = true)] Telegram.Bot.Types.Update tgUpdate, ILogger log)
        {
            _dataStorePipeline.Run(tgUpdate);
        }
    }
}

