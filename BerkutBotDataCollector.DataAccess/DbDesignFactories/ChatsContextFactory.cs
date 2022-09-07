using System;
using BerkutBotDataCollector.DataAccess.DataContexts;
using BerkutBotDataCollector.DataAccess.Options;
using CommandLine;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace BerkutBotDataCollector.DataAccess.DbDesignFactories
{
	internal class ChatsContextFactory : IDesignTimeDbContextFactory<ChatsDbContext>
    {
        public ChatsDbContext CreateDbContext(string[] args)
        {
            var dbCommectionOptions = Parser.Default.ParseArguments<DbCommandArgs>(args).Value;

            var config = new ConfigurationBuilder()
                .AddUserSecrets<ChatsDbContext>(true)
                .AddEnvironmentVariables()
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ChatsDbContext>();

            optionsBuilder.UseSqlServer(
                config.GetConnectionString(dbCommectionOptions.ConnectionStringName),
                settings =>
                {
                    settings.EnableRetryOnFailure();
                });

            return new ChatsDbContext(optionsBuilder.Options);
        }
    }
}

