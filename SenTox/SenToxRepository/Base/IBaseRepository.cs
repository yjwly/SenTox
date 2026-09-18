using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SenToxRepository.Base
{
    public interface IBaseRepository<T> where T : class, new()
    {
        ISqlSugarClient Db { get; }
        Task<T?> GetByIdAsync(long id);
        Task<List<T>> GetListAsync();
        Task<List<T>> GetListAsync(Expression<Func<T, bool>> where);
        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(long id);
    }
}
