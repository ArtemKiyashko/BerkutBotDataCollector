using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace BerkutBotDataCollector.ViewModels
{
	public class AnnouncementRequest
	{
        [JsonRequired]
        public Announcement Announcement { get; set; }
        public bool SendToAll { get; set; }
        public IEnumerable<long> Chats { get; set; }
    }
}

