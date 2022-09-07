using System;
using BerkutBotDataCollector.DataAccess.DataContexts;
using BerkutBotDataCollector.DataAccess.DbDesignFactories;
using BerkutBotDataCollector.DataAccess.Interfaces;
using BerkutBotDataCollector.DataAccess.Models;
using BerkutBotDataCollector.DataAccess.Options;
using BerkutBotDataCollector.DataAccess.Repositories;
using CommandLine;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace BerkutBotDataCollector.DataAccess.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddChats(this IServiceCollection services, string connectionStringName)
        {
            services.AddScoped<IDesignTimeDbContextFactory<ChatsDbContext>, ChatsContextFactory>();
            services.AddScoped<ChatsDbContext>(provider =>
            {
                var contextFactory = provider.GetRequiredService<IDesignTimeDbContextFactory<ChatsDbContext>>();
                return contextFactory.CreateDbContext(
                    Parser.Default.FormatCommandLineArgs<DbCommandArgs>(
                        new DbCommandArgs {
                            ConnectionStringName = connectionStringName
                        }));
            });
            services.AddScoped<IRepository<Chat>, ChatsRepository>();
            return services;
        }

        public static IServiceCollection AddMembers(this IServiceCollection services, string connectionStringName)
        {
            services.AddScoped<IDesignTimeDbContextFactory<MembersDbContext>, MembersContextFactory>();
            services.AddScoped<MembersDbContext>(provider =>
            {
                var contextFactory = provider.GetRequiredService<IDesignTimeDbContextFactory<MembersDbContext>>();
                return contextFactory.CreateDbContext(
                    Parser.Default.FormatCommandLineArgs<DbCommandArgs>(
                        new DbCommandArgs
                        {
                            ConnectionStringName = connectionStringName
                        }));
            });
            services.AddScoped<IRepository<Member>, MembersRepository>();
            return services;
        }

        public static IServiceCollection AddMessages(this IServiceCollection services, string connectionStringName)
        {
            services.AddScoped<IDesignTimeDbContextFactory<MessagesDbContext>, MessagesContextFactory>();
            services.AddSingleton<MessagesDbContext>(provider =>
            {
                var contextFactory = provider.GetRequiredService<IDesignTimeDbContextFactory<MessagesDbContext>>();
                return contextFactory.CreateDbContext(
                    Parser.Default.FormatCommandLineArgs<DbCommandArgs>(
                        new DbCommandArgs
                        {
                            ConnectionStringName = connectionStringName
                        }));
            });
            services.AddScoped<IRepository<Message>, MessagesRepository>();
            return services;
        }
    }
}

