using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Dto = BerkutBotDataCollector.DataAccess.Models;
using BerkutBotDataCollector.DataAccess.Interfaces;
using BerkutBotDataCollector.ViewModels;
using Azure.Messaging.ServiceBus;
using AutoMapper;
using BerkutBotDataCollector.Helpers;
using Microsoft.Extensions.Options;
using BerkutBotDataCollector.Options;
using System.Collections.Generic;
using System.Linq;
using BerkutBotDataCollector.DataAccess.Managers;

namespace BerkutBotDataCollector.Api
{
    public class Chats
    {
        private readonly IChatManager _chatManager;
        private readonly ServiceBusClient _serviceBusClient;
        private readonly IMapper _mapper;
        private readonly ServiceBusOptions _serviceBusOptions;

        public Chats(
            IChatManager chatManager,
            ServiceBusClient serviceBusClient,
            IMapper mapper,
            IOptions<ServiceBusOptions> serviceBusOptions)
        {
            _chatManager = chatManager;
            _serviceBusClient = serviceBusClient;
            _mapper = mapper;
            _serviceBusOptions = serviceBusOptions.Value;
        }

        [FunctionName("GetAllChats")]
        public async Task<IActionResult> GetAllChats(
            [HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req, ILogger log)
        {
            var allChats = await _chatManager.GetAllChats();
            return new OkObjectResult(allChats);
        }

        [FunctionName("GetActiveChats")]
        public async Task<IActionResult> GetActiveChats(
            [HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req, ILogger log)
        {
            var activeChats = await _chatManager.GetActiveChats();
            return new OkObjectResult(activeChats);
        }

        [FunctionName("SendAnnouncement")]
        public async Task<IActionResult> SendAnnouncement(
            [HttpTrigger(AuthorizationLevel.Function, "post")] AnnouncementRequest req, ILogger log)
        {
            await using ServiceBusSender sender = _serviceBusClient.CreateSender(_serviceBusOptions.AnnouncementsSchedulerTopic);
            ServiceBusMessage serviceBusMessage = new ServiceBusMessage(req.ToJson());
            await sender.SendMessageAsync(serviceBusMessage);
            return new OkResult();
        }
    }
}

