using System;
using System.Threading.Tasks;
using BerkutBotDataCollector.ViewModels;
using Telegram.Bot.Types;

namespace BerkutBotDataCollector.Proxies
{
	public interface ITelegramBotMessageProxy
	{
		Task<Message> SendAnnouncement(AnnouncementMessage announcementRequest);
	}
}

