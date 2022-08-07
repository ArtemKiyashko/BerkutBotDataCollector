using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types;

namespace BerkutBotDataCollector
{
    public class BerkutBotDataCollector
    {
        private readonly ILogger<BerkutBotDataCollector> _logger;

        public BerkutBotDataCollector(ILogger<BerkutBotDataCollector> log)
        {
            _logger = log;
        }

        [FunctionName("BerkutBotDataCollector")]
        public void Run([ServiceBusTrigger("tgincomemessages", "datacollector", Connection = "ServiceBusConnection")]Message tgMessage)
        {
             
        }
    }
}

