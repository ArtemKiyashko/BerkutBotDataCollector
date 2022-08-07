using System;
namespace BerkutBotDataCollector.DataAccess.Models
{
    public record Member(string FirstName, string LastName, string Username, bool IsBot) : BaseEntity;
}

