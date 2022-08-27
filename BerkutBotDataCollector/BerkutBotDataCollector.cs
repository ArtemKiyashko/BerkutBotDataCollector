using System;
using BerkutBotDataCollector.DataAccess.Interfaces;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types;
using BerkutBotDataCollector.DataAccess.Models;

namespace BerkutBotDataCollector
{
    public class BerkutBotDataCollector
    {
        private readonly ILogger<BerkutBotDataCollector> _logger;
        private readonly IRepository<DataAccess.Models.Chat> _chatsRepository;

        public BerkutBotDataCollector(ILogger<BerkutBotDataCollector> log, IRepository<DataAccess.Models.Chat> chatsRepository)
        {
            _logger = log;
            _chatsRepository = chatsRepository;
        }

        [FunctionName("BerkutBotDataCollector")]
        public void Run([ServiceBusTrigger("tgincomemessages", "datacollector", Connection = "ServiceBusConnection")] Telegram.Bot.Types.Message tgMessage, ILogger log)
        {
            _chatsRepository.Add(new DataAccess.Models.Chat(tgMessage.Chat.Id)
            {
                Title = tgMessage.Chat.Title,
                FirstName = tgMessage.Chat.FirstName,
                LastName = tgMessage.Chat.LastName,
                Username = tgMessage.Chat.Username
            });
        }
    }
}

