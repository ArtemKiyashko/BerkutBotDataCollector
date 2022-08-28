using System;
using BerkutBotDataCollector.DataAccess.DataContexts;
using BerkutBotDataCollector.DataAccess.Interfaces;
using BerkutBotDataCollector.DataAccess.Models;
using BerkutBotDataCollector.DataAccess.Repositories;
using BerkutBotDataCollector.Infrastructure;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(BerkutBotDataCollector.Startup))]
namespace BerkutBotDataCollector
{
	public class Startup : FunctionsStartup
    {
        private IConfigurationRoot _functionConfig;

        public override void Configure(IFunctionsHostBuilder builder)
        {
            _functionConfig = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .Build();

            builder.Services.AddTransient<IRepository<Chat>, ChatsRepository>();
            builder.Services.AddTransient<IRepository<Member>, MembersRepository>();
            builder.Services.AddAutoMapper(typeof(MapperProfile));
            builder.Services.AddTransient<ChatStep>();
            builder.Services.AddTransient<MemberStep>();
            builder.Services.AddTransient<IDataStorePipeline, DataStorePipeline>(factory =>
            {
                var pipeline = new DataStorePipeline();
                pipeline
                    .AddStep(factory.GetService<ChatStep>())
                    .AddStep(factory.GetService<MemberStep>());
                return pipeline;
            });
        }
    }
}

