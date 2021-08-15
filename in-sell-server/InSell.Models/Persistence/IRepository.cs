using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace InSell.Models.Persistence
{
    public interface IRepository
    {
    }

    public interface IRepository<T> : IRepository where T : class, IConcern
    {
        Task<T> GetByIdAsync(string id, string partitionKey = null);

        Task<T> AddAsync(T concern);

        Task<T> UpdateAsync(T concern);

        Task<T> ReplaceAsync(T concern);

        Task<IList<T>> GetItems();

        Task<IList<T>> GetItemsByQuery(string query);

        Task<IList<T>> GetItemsByQuery(Expression<Func<T, bool>> query, Expression<Func<T, object>> orderByQuery = null, bool orderByAscending = false);

        Task<bool> RemoveAsync(string id);

        Task<int> GetCountByQuery(string query);

        Task<int> GetCount(Expression<Func<T, bool>> expr);

    }
}
