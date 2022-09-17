using System;
using AutoMapper;
using BerkutBotDataCollector.DataAccess.Interfaces;
using Vm = Telegram.Bot.Types;
using Dto = BerkutBotDataCollector.DataAccess.Models;
using BerkutBotDataCollector.DataAccess.Repositories;
using Microsoft.Extensions.Logging;

namespace BerkutBotDataCollector.Infrastructure
{
	internal class MessageStep : BaseStep
	{
        private readonly IMapper _mapper;
        private readonly IRepository<Dto.Message> _repository;
        private readonly ILogger<MessageStep> _logger;
        private readonly ITgMessageFactory _tgMessageFactory;

        public MessageStep(IMapper mapper, IRepository<Dto.Message> repository, ILogger<MessageStep> logger, ITgMessageFactory tgMessageFactory)
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
                _repository.Add(_mapper.Map<Dto.Message>(tgMessage));
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error saving entity");
            }
            return base.Run(tgUpdate);
        }
    }
}

