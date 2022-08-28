using System;
using System.Threading.Tasks;
using BerkutBotDataCollector.DataAccess.Interfaces;
using BerkutBotDataCollector.DataAccess.Models;
using BerkutBotDataCollector.Proxies;
using BerkutBotDataCollector.ViewModels;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Telegram.Bot;

namespace BerkutBotDataCollector.ServiceBusProcessors
{
    public class AnnouncementProcessor
    {
        private readonly ILogger<AnnouncementProcessor> _logger;
        private readonly ITelegramBotMessageProxy _telegramBotMessageProxy;

        public AnnouncementProcessor(
            ILogger<AnnouncementProcessor> log,
            ITelegramBotMessageProxy telegramBotMessageProxy)
        {
            _logger = log;
            _telegramBotMessageProxy = telegramBotMessageProxy;
        }

        [FunctionName("ProcessAnnouncement")]
        public async Task Run([ServiceBusTrigger("announcements", "announcementprocessor", Connection = "ServiceBusOptions")] AnnouncementMessage announcement)
        {
            await _telegramBotMessageProxy.SendAnnouncement(announcement);
        }
    }
}

