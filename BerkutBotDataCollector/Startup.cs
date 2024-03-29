﻿using System;
using Azure.Identity;
using BerkutBotDataCollector.DataAccess.DataContexts;
using BerkutBotDataCollector.DataAccess.Extensions;
using BerkutBotDataCollector.DataAccess.Interfaces;
using BerkutBotDataCollector.DataAccess.Models;
using BerkutBotDataCollector.DataAccess.Repositories;
using BerkutBotDataCollector.Infrastructure;
using BerkutBotDataCollector.Options;
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

            builder.Services.Configure<ServiceBusOptions>(_functionConfig.GetSection("ServiceBusOptions"));
            builder.Services.AddAzureClients(clientBuilder =>
            {
                var provider = builder.Services.BuildServiceProvider();

                clientBuilder.UseCredential(new DefaultAzureCredential());
                clientBuilder.AddServiceBusClientWithNamespace(provider.GetRequiredService<IOptions<ServiceBusOptions>>().Value.FullyQualifiedNamespace);
            });

            builder.Services.AddLogging();
            builder.Services.AddChats("ChatsConnectionString");
            builder.Services.AddMembers("MembersConnectionString");
            builder.Services.AddMessages("MessagesConnectionString");
            builder.Services.AddAutoMapper(typeof(MapperProfile));
            builder.Services.AddScoped<ChatStep>();
            builder.Services.AddScoped<MemberStep>();
            builder.Services.AddScoped<MessageStep>();
            builder.Services.AddScoped<IDataStorePipeline, DataStorePipeline>(factory =>
            {
                var pipeline = new DataStorePipeline();
                pipeline
                    .AddStep(factory.GetService<ChatStep>())
                    .AddStep(factory.GetService<MemberStep>())
                    .AddStep(factory.GetService<MessageStep>());
                return pipeline;
            });
        }
    }
}

