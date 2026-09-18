using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SenToxRepository.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        public ISqlSugarClient Db { get; }

        public BaseRepository(ISqlSugarClient db)
        {
            Db = db;
        }

        public async Task<T?> GetByIdAsync(long id)
        {
            return await Db.Queryable<T>().In(id).FirstAsync();
        }

        public async Task<List<T>> GetListAsync()
        {
            return await Db.Queryable<T>().ToListAsync();
        }

        public async Task<List<T>> GetListAsync(Expression<Func<T, bool>> where)
        {
            return await Db.Queryable<T>().Where(where).ToListAsync();
        }

        public async Task<bool> AddAsync(T entity)
        {
            return await Db.Insertable(entity).ExecuteCommandAsync() > 0;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            return await Db.Updateable(entity).ExecuteCommandAsync() > 0;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            return await Db.Deleteable<T>().In(id).ExecuteCommandAsync() > 0;
        }
    }
}
