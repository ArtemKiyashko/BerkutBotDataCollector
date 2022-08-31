using System;
namespace BerkutBotDataCollector.DataAccess.Models
{
	public record FileBase
	{
        public Guid Id { get; init; } = Guid.NewGuid();
        public string TelegramFileId { get; set; }
        public string TelegramFileUniqueId { get; set; }
        public long? TelegramFileSize { get; set; }
    }
}

