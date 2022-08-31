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

        public MessageStep(IMapper mapper, IRepository<Dto.Message> repository, ILogger<MessageStep> logger)
		{
            _mapper = mapper;
            _repository = repository;
            _logger = logger;
        }

        public override Vm.Message Run(Vm.Message tgMessage)
        {
            try
            {
                _repository.Add(_mapper.Map<Dto.Message>(tgMessage));
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error saving entity");
            }
            return base.Run(tgMessage);
        }
    }
}

