using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using BerkutBotDataCollector.Infrastructure;
using System.Threading.Tasks;

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
        public async Task Run([ServiceBusTrigger("alltgmessages", "datacollector", Connection = "ServiceBusOptions", IsSessionsEnabled = true)] Telegram.Bot.Types.Update tgUpdate, ILogger log)
        {
            await _dataStorePipeline.Run(tgUpdate);
        }
    }
}

