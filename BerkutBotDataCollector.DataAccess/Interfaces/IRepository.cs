using System;
using BerkutBotDataCollector.DataAccess.Models;

namespace BerkutBotDataCollector.DataAccess.Interfaces
{
	public interface IRepository<T> where T : BaseEntity
	{
		Task<Guid> Add(T entity);
		Task<T> GetById(Guid id);
        Task<T> GetByTelegramId(long telegramId);
        Task<ICollection<T>> GetAll();
	}
}

