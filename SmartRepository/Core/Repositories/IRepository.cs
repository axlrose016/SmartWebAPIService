using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartRepository.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class 
    {
        Task<TEntity> Get(int id);
        Task<TEntity> Get(Guid id);
        Task<TEntity> Get(string id);
        Task<IEnumerable<TEntity>> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        void AddAsync(TEntity entity);
        void AddRangeAsync(IEnumerable<TEntity> entities);
        void UpdateAsync(TEntity entity);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        int Complete();
        void DisposeContext();
    }
}
