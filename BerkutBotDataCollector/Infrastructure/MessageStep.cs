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
	internal class MessageStep : BaseStep
	{
        private readonly IMapper _mapper;
        private readonly IMessageManager _messageManager;
        private readonly ILogger<MessageStep> _logger;
        private readonly ITgMessageFactory _tgMessageFactory;

        public MessageStep(IMapper mapper, IMessageManager messageManager, ILogger<MessageStep> logger, ITgMessageFactory tgMessageFactory)
		{
            _mapper = mapper;
            _messageManager = messageManager;
            _logger = logger;
            _tgMessageFactory = tgMessageFactory;
        }

        public override async Task<Vm.Message> Run(Vm.Update tgUpdate)
        {
            var tgMessage = _tgMessageFactory.GetMessage(tgUpdate);
            try
            {
                await _messageManager.AddMessage(_mapper.Map<Dto.Message>(tgMessage));
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error saving entity");
            }
            return await base.Run(tgUpdate);
        }
    }
}

