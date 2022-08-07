using System;
using BerkutBotDataCollector.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace BerkutBotDataCollector.DataAccess.DataContexts
{
    public class ChatsDbContext : DbContext
    {
        public DbSet<Chat> Chats { get; set; }
    }
}

