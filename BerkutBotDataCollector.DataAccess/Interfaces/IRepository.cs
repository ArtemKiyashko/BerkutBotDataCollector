using System;
using BerkutBotDataCollector.DataAccess.Models;

namespace BerkutBotDataCollector.DataAccess.Interfaces
{
	internal interface IRepository<T> where T : BaseEntity
	{
		Task<Guid> Add(T entity);
		Task<T> GetById(Guid id);
        Task<T> GetByTelegramId(long telegramId);
        IQueryable<T> GetAll();
		Task SaveChanges();
	}
}

