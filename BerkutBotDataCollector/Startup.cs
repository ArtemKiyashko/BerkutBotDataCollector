﻿using System;
using Azure.Identity;
using BerkutBotDataCollector.DataAccess.DataContexts;
using BerkutBotDataCollector.DataAccess.Interfaces;
using BerkutBotDataCollector.DataAccess.Models;
using BerkutBotDataCollector.DataAccess.Repositories;
using BerkutBotDataCollector.Infrastructure;
using BerkutBotDataCollector.Options;
using BerkutBotDataCollector.Proxies;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Telegram.Bot;

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

            builder.Services.Configure<BotOptions>(_functionConfig.GetSection("BotOptions"));
            builder.Services.AddSingleton<ITelegramBotClient, TelegramBotClient>(provider =>
                new TelegramBotClient(provider.GetRequiredService<IOptions<BotOptions>>().Value.Token));
            builder.Services.AddTransient<ITelegramBotMessageProxy, TelegramBotMessageProxy>();

            builder.Services.Configure<ServiceBusOptions>(_functionConfig.GetSection("ServiceBusOptions"));
            builder.Services.AddAzureClients(clientBuilder =>
            {
                var provider = builder.Services.BuildServiceProvider();

                clientBuilder.UseCredential(new DefaultAzureCredential());
                clientBuilder.AddServiceBusClientWithNamespace(provider.GetRequiredService<IOptions<ServiceBusOptions>>().Value.FullyQualifiedNamespace);
            });

            builder.Services.AddLogging();
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

