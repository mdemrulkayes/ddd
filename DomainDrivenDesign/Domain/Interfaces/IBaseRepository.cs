using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Interfaces
{
    public interface IBaseRepository<T> where T: BaseEntity
    {
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> GetAsync(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression = null);
    }
}
