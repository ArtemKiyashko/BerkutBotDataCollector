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
        private readonly ILogger<BerkutBotDataCollector> _logger;
        private readonly IDataStorePipeline _dataStorePipeline;
        private readonly IMapper _mapper;

        public BerkutBotDataCollector(
            ILogger<BerkutBotDataCollector> log,
            IDataStorePipeline dataStorePipeline,
            IMapper mapper)
        {
            _logger = log;
            _dataStorePipeline = dataStorePipeline;
            _mapper = mapper;
        }

        [FunctionName("BerkutBotDataCollector")]
        public void Run([ServiceBusTrigger("tgincomemessages", "datacollector", Connection = "ServiceBusConnection", IsSessionsEnabled = true)] Telegram.Bot.Types.Message tgMessage, ILogger log)
        {
            _dataStorePipeline.Run(tgMessage);
        }
    }
}

