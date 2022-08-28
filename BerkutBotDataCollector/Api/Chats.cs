using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Dto = BerkutBotDataCollector.DataAccess.Models;
using BerkutBotDataCollector.DataAccess.Interfaces;
using BerkutBotDataCollector.ViewModels;
using Azure.Messaging.ServiceBus;
using AutoMapper;
using Vm = Telegram.Bot.Types;
using BerkutBotDataCollector.Helpers;
using Microsoft.Extensions.Options;
using BerkutBotDataCollector.Options;
using System.Collections.Generic;
using System.Linq;

namespace BerkutBotDataCollector.Api
{
    public class Chats
    {
        private readonly IRepository<Dto.Chat> _repository;
        private readonly ServiceBusClient _serviceBusClient;
        private readonly IMapper _mapper;
        private readonly ServiceBusOptions _serviceBusOptions;

        public Chats(
            IRepository<Dto.Chat> repository,
            ServiceBusClient serviceBusClient,
            IMapper mapper,
            IOptions<ServiceBusOptions> serviceBusOptions)
        {
            _repository = repository;
            _serviceBusClient = serviceBusClient;
            _mapper = mapper;
            _serviceBusOptions = serviceBusOptions.Value;
        }

        [FunctionName("GetAllChats")]
        public async Task<IActionResult> GetAllChats(
            [HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req, ILogger log)
        {
            var allChats = await _repository.GetAll();
            return new OkObjectResult(allChats);
        }

        [FunctionName("SendAnnouncement")]
        public async Task<IActionResult> SendAnnouncement(
            [HttpTrigger(AuthorizationLevel.Function, "post")] AnnouncementRequest req, ILogger log)
        {
            var announcementMessage = _mapper.Map<AnnouncementMessage>(req.Announcement);
            await using ServiceBusSender sender = _serviceBusClient.CreateSender(_serviceBusOptions.AnnouncementsProcessorTopic);

            foreach (var chatId in await GetChatsToSend(req))
            {
                announcementMessage.ChatId = chatId;
                ServiceBusMessage serviceBusMessage = new ServiceBusMessage(announcementMessage.ToJson());
                await sender.SendMessageAsync(serviceBusMessage);
            }
            return new OkResult();
        }

        private async Task<IEnumerable<long>> GetChatsToSend(AnnouncementRequest announcementRequest)
            => announcementRequest.SendToAll ?
            (await _repository.GetAll()).Select(chat => chat.TelegramId)
            : announcementRequest.Chats;
    }
}

