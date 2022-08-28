using System;
using AutoMapper;
using BerkutBotDataCollector.ViewModels;
using Dto = BerkutBotDataCollector.DataAccess.Models;
using Vm = Telegram.Bot.Types;

namespace BerkutBotDataCollector
{
	public class MapperProfile : Profile
	{
		public MapperProfile()
		{
			CreateMap<Vm.Chat, Dto.Chat>()
				.ConstructUsing(source => new Dto.Chat(source.Id))
				.ForMember(destination => destination.TelegramId, opt => opt.MapFrom(source => source.Id))
				.ForMember(destination => destination.Id, opt => opt.Ignore());
            CreateMap<Vm.Message, Dto.Message>()
                .ConstructUsing(source => new Dto.Message(source.MessageId))
                .ForMember(destination => destination.TelegramId, opt => opt.MapFrom(source => source.MessageId))
                .ForMember(destination => destination.Id, opt => opt.Ignore());
            CreateMap<Vm.User, Dto.Member>()
                .ConstructUsing(source => new Dto.Member(source.Id))
                .ForMember(destination => destination.TelegramId, opt => opt.MapFrom(source => source.Id))
                .ForMember(destination => destination.Id, opt => opt.Ignore());
            CreateMap<Announcement, AnnouncementMessage>();
        }
	}
}

