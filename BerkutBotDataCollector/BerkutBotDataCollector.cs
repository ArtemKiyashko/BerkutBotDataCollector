using System;
using BerkutBotDataCollector.DataAccess.Interfaces;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types;
using BerkutBotDataCollector.DataAccess.Models;
using AutoMapper;
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
        public void Run([ServiceBusTrigger("tgincomemessages", "datacollector", Connection = "ServiceBusOptions", IsSessionsEnabled = true)] Telegram.Bot.Types.Message tgMessage, ILogger log)
        {
            _dataStorePipeline.Run(tgMessage);
        }
    }
}

