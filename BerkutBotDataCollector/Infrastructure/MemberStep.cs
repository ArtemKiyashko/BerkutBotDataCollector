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
        private readonly ITgFromFactory _tgFromFactory;

        public MemberStep(IMapper mapper, IRepository<Dto.Member> repository, ILogger<MemberStep> logger, ITgFromFactory tgFromFactory)
		{
            _mapper = mapper;
            _repository = repository;
            _logger = logger;
            _tgFromFactory = tgFromFactory;
        }

        public override Vm.Message Run(Vm.Update tgUpdate)
        {
            var tgUserFrom = _tgFromFactory.GetUser(tgUpdate);
            try
            {
                _repository.Add(_mapper.Map<Dto.Member>(tgUserFrom));
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error saving entity");
            }
            return base.Run(tgUpdate);
        }
    }
}

