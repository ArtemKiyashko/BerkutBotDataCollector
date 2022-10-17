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
	internal class MemberStep : BaseStep
	{
        private readonly IMapper _mapper;
        private readonly IMemberManager _memberManager;
        private readonly ILogger<MemberStep> _logger;
        private readonly ITgFromFactory _tgFromFactory;

        public MemberStep(IMapper mapper, IMemberManager memberManager, ILogger<MemberStep> logger, ITgFromFactory tgFromFactory)
		{
            _mapper = mapper;
            _memberManager = memberManager;
            _logger = logger;
            _tgFromFactory = tgFromFactory;
        }

        public override async Task<Vm.Message> Run(Vm.Update tgUpdate)
        {
            var tgUserFrom = _tgFromFactory.GetUser(tgUpdate);
            try
            {
                await _memberManager.AddMember(_mapper.Map<Dto.Member>(tgUserFrom));
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error saving entity");
            }
            return await base.Run(tgUpdate);
        }
    }
}

