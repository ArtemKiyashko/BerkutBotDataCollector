using System;
namespace BerkutBotDataCollector.Options
{
	public class ServiceBusOptions
	{
        public string AnnouncementsProcessorTopic { get; set; }
        public string FullyQualifiedNamespace { get; set; }
        public string ConnectionString { get; set; }
    }
}

