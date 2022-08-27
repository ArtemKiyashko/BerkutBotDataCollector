using System;
using BerkutBotDataCollector.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace BerkutBotDataCollector.DataAccess.DataContexts
{
    internal class ChatsDbContext : DbContext
    {
        public ChatsDbContext(DbContextOptions<ChatsDbContext> options)
            : base(options) {}

        public DbSet<Chat> Chats { get; set; }
    }
}

