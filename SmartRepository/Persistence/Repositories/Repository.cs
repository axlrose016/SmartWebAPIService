using Microsoft.EntityFrameworkCore;
using SmartRepository.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartRepository.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly PlutoContext Context;
        public Repository(PlutoContext _context) { Context = _context; }
        public async void AddAsync(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
        } 

        public async void AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await Context.Set<TEntity>().AddRangeAsync(entities);
        }
        public void UpdateAsync(TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate).AsNoTracking();
        }

        public async Task<TEntity> Get(int id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> Get(Guid id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }
        public async Task<TEntity> Get(string id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }
        public int Complete()
        {
            return Context.SaveChanges();
        }

        public void DisposeContext()
        {
            Context.Dispose();
        }
    }
}
