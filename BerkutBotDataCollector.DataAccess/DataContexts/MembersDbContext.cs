﻿using System;
using BerkutBotDataCollector.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace BerkutBotDataCollector.DataAccess.DataContexts
{
    internal class MembersDbContext : DbContext
    {
        public MembersDbContext(DbContextOptions<MembersDbContext> options)
            : base(options) {}

        public DbSet<Member> Members { get; set; }
    }
}

