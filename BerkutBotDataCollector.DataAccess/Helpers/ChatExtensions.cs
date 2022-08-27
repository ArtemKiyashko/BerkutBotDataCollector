using System;
using BerkutBotDataCollector.DataAccess.Models;

namespace BerkutBotDataCollector.DataAccess.Helpers
{
	public static class ChatExtensions
	{
		public static Chat CopyTo(this Chat source, Chat destination)
		{
            destination.Title = source.Title;
			destination.UpdatedDateTime = source.UpdatedDateTime;
			return destination;
        }
	}
}

