using System;
using Newtonsoft.Json;
using Telegram.Bot.Types.Enums;

namespace BerkutBotDataCollector.ViewModels
{
	public class Announcement
	{
        [JsonRequired]
        public MessageType MessageType { get; set; }
        public string Text { get; set; }
        public Uri ContentUrl { get; set; }
    }
}

