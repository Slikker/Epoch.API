using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace API.EPOCH.BACKEND
{
    public interface IRepository<T> where T : IBaseClass
    {
        Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> expression);

		Task<T> GetAsync(Expression<Func<T, bool>> expression);

		Task<bool> DataAddAsync(T newData);

        Task <bool> DataUpdateAsync(T newData);

        Task<bool> DataDeleteAsync(T newData);
    }
}
