
using ControlService.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace ControlService.Models.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        HControlServiceDbContext Context;

        public Repository(HControlServiceDbContext context)
        {
            Context = context;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var result = await Context.Set<TEntity>().AddAsync(entity);
            return result.Entity;
        }

        public async Task<TEntity?> DeleteAsync(Guid id)
        {
            var search = await GetAsync(id);
            
            if(search is not null)
            {
                return Context.Set<TEntity>().Remove(search).Entity; 
            }
           
            return null;
        }

        public async Task<TEntity?> GetAsync(Guid id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity?>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public bool IfAny(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Any(predicate);
        }

        public TEntity Update(TEntity entity)
        {
            return Context.Set<TEntity>().Update(entity).Entity;
        }

    }
}
