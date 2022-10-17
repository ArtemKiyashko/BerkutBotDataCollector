using System;
using AutoMapper;
using BerkutBotDataCollector.DataAccess.Interfaces;
using Vm = Telegram.Bot.Types;
using Dto = BerkutBotDataCollector.DataAccess.Models;
using BerkutBotDataCollector.DataAccess.Repositories;
using Microsoft.Extensions.Logging;
using BerkutBotDataCollector.DataAccess.Managers;
using System.Threading.Tasks;

namespace BerkutBotDataCollector.Infrastructure
{
	internal class ChatStep : BaseStep
	{
        private readonly IMapper _mapper;
        private readonly IChatManager _chatManager;
        private readonly ILogger<ChatStep> _logger;
        private readonly ITgMessageFactory _tgMessageFactory;

        public ChatStep(IMapper mapper, IChatManager chatManager, ILogger<ChatStep> logger, ITgMessageFactory tgMessageFactory)
		{
            _mapper = mapper;
            _chatManager = chatManager;
            _logger = logger;
            _tgMessageFactory = tgMessageFactory;
        }

        public override async Task<Vm.Message> Run(Vm.Update tgUpdate)
        {
            var tgChat = _tgMessageFactory.GetChat(tgUpdate);
            try
            {
                var chatDto = _mapper.Map<Dto.Chat>(tgChat);

                //TODO: Move this assignment to Mapper
                chatDto.IsDeleted = tgUpdate?.MyChatMember?.NewChatMember?.Status == Vm.Enums.ChatMemberStatus.Kicked;

                await _chatManager.AddChat(chatDto);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error saving entity");
            }
            return await base.Run(tgUpdate);
        }
    }
}

