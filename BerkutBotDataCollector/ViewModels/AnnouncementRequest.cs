using System.Collections.Generic;
using Newtonsoft.Json;

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

