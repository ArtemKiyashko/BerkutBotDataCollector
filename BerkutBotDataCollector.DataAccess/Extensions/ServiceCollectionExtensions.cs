using System;
using BerkutBotDataCollector.DataAccess.DataContexts;
using BerkutBotDataCollector.DataAccess.DbDesignFactories;
using BerkutBotDataCollector.DataAccess.Interfaces;
using BerkutBotDataCollector.DataAccess.Models;
using BerkutBotDataCollector.DataAccess.Options;
using BerkutBotDataCollector.DataAccess.Repositories;
using CommandLine;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BerkutBotDataCollector.DataAccess.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddChats(this IServiceCollection services, string connectionStringName)
        {
            var config = new ConfigurationBuilder()
                .AddUserSecrets<ChatsDbContext>(true)
                .AddEnvironmentVariables()
                .Build();

            services.AddDbContext<ChatsDbContext>(options => {
                options.UseSqlServer(config.GetConnectionString(connectionStringName),
                    settings => settings.EnableRetryOnFailure());
            });

            services.AddScoped<IRepository<Chat>, ChatsRepository>();
            return services;
        }

        public static IServiceCollection AddMembers(this IServiceCollection services, string connectionStringName)
        {
            var config = new ConfigurationBuilder()
                .AddUserSecrets<MembersDbContext>(true)
                .AddEnvironmentVariables()
                .Build();

            services.AddDbContext<MembersDbContext>(options => {
                options.UseSqlServer(config.GetConnectionString(connectionStringName),
                    settings => settings.EnableRetryOnFailure());
            });

            services.AddScoped<IRepository<Member>, MembersRepository>();
            return services;
        }

        public static IServiceCollection AddMessages(this IServiceCollection services, string connectionStringName)
        {
            var config = new ConfigurationBuilder()
                .AddUserSecrets<MessagesDbContext>(true)
                .AddEnvironmentVariables()
                .Build();

            services.AddDbContext<MessagesDbContext>(options => {
                options.UseSqlServer(config.GetConnectionString(connectionStringName),
                    settings => settings.EnableRetryOnFailure());
            });

            services.AddScoped<IRepository<Message>, MessagesRepository>();
            return services;
        }
    }
}

