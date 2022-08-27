using System;
namespace BerkutBotDataCollector.DataAccess.Interfaces
{
	public interface IRepository<T>
	{
		Task<Guid> Add(T entity);
		Task<T> GetById(Guid id);
		Task<T> Find(Func<T, bool> func);
	}
}

