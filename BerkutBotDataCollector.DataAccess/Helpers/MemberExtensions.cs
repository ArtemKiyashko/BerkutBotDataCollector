using System;
using BerkutBotDataCollector.DataAccess.Models;

namespace BerkutBotDataCollector.DataAccess.Helpers
{
	public static class MemberExtensions
	{
		public static Member CopyTo(this Member source, Member destination)
		{
			destination.FirstName = source.FirstName;
			destination.LastName = source.LastName;
			destination.IsBot = source.IsBot;
			destination.Username = source.Username;
			destination.LanguageCode = source.LanguageCode;
			destination.UpdatedDateTime = source.UpdatedDateTime;
			return destination;
        }
	}
}

