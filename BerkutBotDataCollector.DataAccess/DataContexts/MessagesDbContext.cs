using System;
using BerkutBotDataCollector.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace BerkutBotDataCollector.DataAccess.DataContexts
{
    public class MessagesDbContext : DbContext
    {
        public DbSet<Message> Messages { get; set; }
    }
}

