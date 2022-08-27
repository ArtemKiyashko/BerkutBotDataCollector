using System;
using BerkutBotDataCollector.DataAccess.DataContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace BerkutBotDataCollector.DataAccess.DbDesignFactories
{
	public class ChatsContextFactory : IDesignTimeDbContextFactory<ChatsDbContext>
    {
        public ChatsDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddUserSecrets<ChatsDbContext>(true)
                .AddEnvironmentVariables()
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ChatsDbContext>();

            optionsBuilder.UseSqlServer(
                config.GetConnectionString("ChatsConnectionString"),
                settings =>
                {
                    settings.EnableRetryOnFailure();
                });

            return new ChatsDbContext(optionsBuilder.Options);
        }
    }
}

