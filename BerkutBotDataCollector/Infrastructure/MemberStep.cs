using System;
using AutoMapper;
using BerkutBotDataCollector.DataAccess.Interfaces;
using Vm = Telegram.Bot.Types;
using Dto = BerkutBotDataCollector.DataAccess.Models;
using BerkutBotDataCollector.DataAccess.Repositories;
using Microsoft.Extensions.Logging;

namespace BerkutBotDataCollector.Infrastructure
{
	internal class MemberStep : BaseStep
	{
        private readonly IMapper _mapper;
        private readonly IRepository<Dto.Member> _repository;
        private readonly ILogger<MemberStep> _logger;

        public MemberStep(IMapper mapper, IRepository<Dto.Member> repository, ILogger<MemberStep> logger)
		{
            _mapper = mapper;
            _repository = repository;
            _logger = logger;
        }

        public override Vm.Message Run(Vm.Message tgMessage)
        {
            try
            {
                _repository.Add(_mapper.Map<Dto.Member>(tgMessage.From));
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error saving entity");
            }
            return base.Run(tgMessage);
        }
    }
}

