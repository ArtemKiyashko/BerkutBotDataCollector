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
                .ForMember(destination => destination.Id, opt => opt.Ignore())
                .ForMember(destination => destination.TelegramChatId, opt => opt.MapFrom(source => source.Chat.Id))
                .ForMember(destination => destination.TelegramFromId, opt => opt.MapFrom(source => source.From.Id))
                .ForMember(destination => destination.SentDateTime, opt => opt.MapFrom(source => source.Date));
            CreateMap<Vm.PhotoSize, Dto.Photo>()
                .ForMember(destination => destination.TelegramFileId, opt => opt.MapFrom(source => source.FileId))
                .ForMember(destination => destination.TelegramFileUniqueId, opt => opt.MapFrom(source => source.FileUniqueId))
                .ForMember(destination => destination.TelegramFileSize, opt => opt.MapFrom(source => source.FileSize));
            CreateMap<Vm.Location, Dto.Location>();
            CreateMap<Vm.User, Dto.Member>()
                .ConstructUsing(source => new Dto.Member(source.Id))
                .ForMember(destination => destination.TelegramId, opt => opt.MapFrom(source => source.Id))
                .ForMember(destination => destination.Id, opt => opt.Ignore());
            CreateMap<Announcement, AnnouncementMessage>();
        }
	}
}

