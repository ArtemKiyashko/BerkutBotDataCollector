using System;
using BerkutBotDataCollector.DataAccess.Interfaces;
using BerkutBotDataCollector.DataAccess.Managers;
using BerkutBotDataCollector.DataAccess.Models;
using BerkutBotDataCollector.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BerkutBotDataCollector.DataAccess.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddChats(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IRepository<Chat>, ChatsRepository>();
            serviceCollection.AddTransient<IChatManager, ChatManager>();
            return serviceCollection;
        }

        public static IServiceCollection AddMembers(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IRepository<Member>, MembersRepository>();
            serviceCollection.AddTransient<IMemberManager, MemberManager>();
            return serviceCollection;
        }

        public static IServiceCollection AddMessages(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IRepository<Message>, MessagesRepository>();
            serviceCollection.AddTransient<IMessageManager, MessageManager>();
            return serviceCollection;
        }
    }
}

