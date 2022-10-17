using System;
using BerkutBotDataCollector.DataAccess.Models;

namespace BerkutBotDataCollector.DataAccess.Helpers
{
	public static class ChatExtensions
	{
		public static Chat CopyTo(this Chat source, Chat destination)
		{
            destination.Title = source.Title;
            destination.FirstName = source.FirstName;
            destination.LastName = source.LastName;
            destination.Username = source.Username;
            destination.UpdatedDateTime = source.UpdatedDateTime;
            destination.IsDeleted = source.IsDeleted;
			return destination;
        }
	}
}

