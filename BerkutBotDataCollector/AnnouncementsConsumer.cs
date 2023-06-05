using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Azure.Messaging.ServiceBus;
using BerkutBotDataCollector.DataAccess.Managers;
using BerkutBotDataCollector.Helpers;
using BerkutBotDataCollector.Options;
using BerkutBotDataCollector.ViewModels;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BerkutBotDataCollector
{
	public class AnnouncementsConsumer
	{
        private readonly IChatManager _chatManager;
        private readonly IMapper _mapper;
        private readonly ServiceBusClient _serviceBusClient;
        private readonly ServiceBusOptions _serviceBusOptions;

        public AnnouncementsConsumer(
            IChatManager chatManager,
            IOptions<ServiceBusOptions> serviceBusOptions,
            IMapper mapper,
            ServiceBusClient serviceBusClient)
		{
            _chatManager = chatManager;
            _mapper = mapper;
            _serviceBusClient = serviceBusClient;
            _serviceBusOptions = serviceBusOptions.Value;
        }

        [FunctionName("AnnouncementsConsumer")]
        public async Task Run([ServiceBusTrigger("announcementsscheduler", "datacollector", Connection = "ServiceBusOptions")] AnnouncementRequest req, ILogger log)
        {
            var announcementMessage = _mapper.Map<AnnouncementMessage>(req.Announcement);
            await using ServiceBusSender sender = _serviceBusClient.CreateSender(_serviceBusOptions.AnnouncementsProcessorTopic);

            foreach (var chatId in await GetChatsToSend(req))
            {
                announcementMessage.ChatId = chatId;
                ServiceBusMessage serviceBusMessage = new ServiceBusMessage(announcementMessage.ToJson());
                await sender.SendMessageAsync(serviceBusMessage);
            }
        }

        private async Task<IEnumerable<long>> GetChatsToSend(AnnouncementRequest announcementRequest)
            => announcementRequest.SendToAll ?
            (await _chatManager.GetActiveChats()).Select(chat => chat.TelegramId)
            : announcementRequest.Chats;
    }
}

