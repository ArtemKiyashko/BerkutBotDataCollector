using System;
using AutoMapper;
using BerkutBotDataCollector.DataAccess.Interfaces;
using Vm = Telegram.Bot.Types;
using Dto = BerkutBotDataCollector.DataAccess.Models;
using BerkutBotDataCollector.DataAccess.Repositories;
using Microsoft.Extensions.Logging;

namespace BerkutBotDataCollector.Infrastructure
{
	internal class ChatStep : BaseStep
	{
        private readonly IMapper _mapper;
        private readonly IRepository<Dto.Chat> _repository;
        private readonly ILogger<ChatStep> _logger;
        private readonly ITgMessageFactory _tgMessageFactory;

        public ChatStep(IMapper mapper, IRepository<Dto.Chat> repository, ILogger<ChatStep> logger, ITgMessageFactory tgMessageFactory)
		{
            _mapper = mapper;
            _repository = repository;
            _logger = logger;
            _tgMessageFactory = tgMessageFactory;
        }

        public override Vm.Message Run(Vm.Update tgUpdate)
        {
            var tgMessage = _tgMessageFactory.GetMessage(tgUpdate);
            try
            {
                _repository.Add(_mapper.Map<Dto.Chat>(tgMessage.Chat));
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error saving entity");
            }
            return base.Run(tgUpdate);
        }
    }
}

