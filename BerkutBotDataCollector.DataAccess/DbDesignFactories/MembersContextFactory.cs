using System;
using BerkutBotDataCollector.DataAccess.DataContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace BerkutBotDataCollector.DataAccess.DbDesignFactories
{
	internal class MembersContextFactory : IDesignTimeDbContextFactory<MembersDbContext>
    {
        public MembersDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddUserSecrets<ChatsDbContext>(true)
                .AddEnvironmentVariables()
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<MembersDbContext>();

            optionsBuilder.UseSqlServer(
                config.GetConnectionString("MembersConnectionString"),
                settings =>
                {
                    settings.EnableRetryOnFailure();
                });

            return new MembersDbContext(optionsBuilder.Options);
        }
    }
}

