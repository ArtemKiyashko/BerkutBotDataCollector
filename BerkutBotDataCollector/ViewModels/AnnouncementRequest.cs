using System;
using System.Collections.Generic;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace BerkutBotDataCollector.ViewModels
{
	public class AnnouncementRequest
	{
        public Announcement Announcement { get; set; }
        public bool SendToAll { get; set; }
        public IEnumerable<long> Chats { get; set; }
    }
}

