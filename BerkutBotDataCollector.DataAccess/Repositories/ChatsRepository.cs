﻿using System;
using BerkutBotDataCollector.DataAccess.DataContexts;
using BerkutBotDataCollector.DataAccess.DbDesignFactories;
using BerkutBotDataCollector.DataAccess.Helpers;
using BerkutBotDataCollector.DataAccess.Interfaces;
using BerkutBotDataCollector.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace BerkutBotDataCollector.DataAccess.Repositories
{
	internal class ChatsRepository : IRepository<Chat>
	{
        private readonly ChatsDbContext _chatsDbContext;

        public ChatsRepository(ChatsDbContext chatsDbContext)
		{
            _chatsDbContext = chatsDbContext;
        }

        public async Task<Guid> Add(Chat entity)
        {
            var existedChat = await GetByTelegramId(entity.TelegramId);

            if (existedChat is not null)
            {
                entity.CopyTo(existedChat);
                await _chatsDbContext.SaveChangesAsync();
                return existedChat.Id;
            }

            _chatsDbContext.Chats.Add(entity);
            await _chatsDbContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<ICollection<Chat>> GetAll() => await _chatsDbContext.Chats.ToListAsync();

        public async Task<Chat> GetById(Guid id) => await _chatsDbContext.Chats.FindAsync(id);

        public async Task<Chat> GetByTelegramId(long telegramId) => await _chatsDbContext.Chats.FirstOrDefaultAsync(c => c.TelegramId == telegramId);
    }
}

