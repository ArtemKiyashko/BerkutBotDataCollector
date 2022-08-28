using System;
using Telegram.Bot.Types.Enums;

namespace BerkutBotDataCollector.ViewModels
{
	public class Announcement
	{
        public MessageType MessageType { get; set; }
        public string Text { get; set; }
        public Uri ContentUrl { get; set; }
    }
}

