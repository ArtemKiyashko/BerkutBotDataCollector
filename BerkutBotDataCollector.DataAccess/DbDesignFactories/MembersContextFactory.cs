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
	internal class MembersContextFactory : IDesignTimeDbContextFactory<MembersDbContext>
    {
        public MembersDbContext CreateDbContext(string[] args)
        {
            var dbCommectionOptions = Parser.Default.ParseArguments<DbCommandArgs>(args).Value;

            var config = new ConfigurationBuilder()
                .AddUserSecrets<MembersDbContext>(true)
                .AddEnvironmentVariables()
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<MembersDbContext>();

            optionsBuilder.UseSqlServer(
                config.GetConnectionString(dbCommectionOptions.ConnectionStringName),
                settings =>
                {
                    settings.EnableRetryOnFailure();
                });

            return new MembersDbContext(optionsBuilder.Options);
        }
    }
}

