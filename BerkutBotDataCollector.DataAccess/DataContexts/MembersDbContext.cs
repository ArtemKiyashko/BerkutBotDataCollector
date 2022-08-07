using System;
using BerkutBotDataCollector.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace BerkutBotDataCollector.DataAccess.DataContexts
{
    public class MembersDbContext : DbContext
    {
        public DbSet<Member> Members { get; set; }
    }
}

