
using ControlService.Models.Entities;
using Google.Protobuf.WellKnownTypes;
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

        public Repository()
        {
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
        public TEntity? GetLastEntity<TSortKey>(Func<TEntity, TSortKey> orderBy)
        {
            return Context.Set<TEntity>()
                .OrderByDescending(orderBy)
                .FirstOrDefault();
        }

        public async Task<IEnumerable<TEntity?>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().Where(predicate).ToListAsync();
        }
        public async Task<IEnumerable<TEntity?>> GetPageAsync(int page, int page_size, IComparer<TEntity> comparer) 
        {

            var all_entities_list = new List<TEntity>(await Context.Set<TEntity>().ToListAsync());
            all_entities_list.Sort(comparer);
            return all_entities_list.GetRange((page - 1) * page_size, page_size); 
        }
        public async Task<IEnumerable<TEntity?>> GetPageAsync(int page, int page_size, IComparer<TEntity> comparer, Expression<Func<TEntity, bool>> predicate)
        {

            var all_entities_list = new List<TEntity>(await Context.Set<TEntity>().Where(predicate).ToListAsync());
            all_entities_list.Sort(comparer);
            return all_entities_list.GetRange((page - 1) * page_size, page_size);
        }
        public uint PagesCount(int page_size)
        {
            uint count = (uint)(Context.Set<TEntity>().Count() / page_size);
            return count % page_size == 0 ? count : count + 1;
        }
        public uint PagesCount(int page_size, Expression<Func<TEntity, bool>> predicate)
        {
            uint count = (uint)(Context.Set<TEntity>().Where(predicate).Count() / page_size);
            return count % page_size == 0 ? count : count + 1;
        }

        public bool IfAny(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Any(predicate);
        }
        public async void Complete()
        {
            await Context.SaveChangesAsync(); 
        }

        public TEntity Update(TEntity entity)
        {
            return Context.Set<TEntity>().Update(entity).Entity;
        }
        public TEntity UpdateLast<TSortKey>(TEntity entity, Func<TEntity, TSortKey> orderBy)
        {
            var lastEntity = Context.Set<TEntity>()
                .OrderByDescending(orderBy)
                .FirstOrDefault();

            if (lastEntity != null)
            {
                // Обновление свойств последней сущности на основе свойств переданной сущности
                // Например:
                // lastEntity.Property1 = entity.Property1;
                // lastEntity.Property2 = entity.Property2;

                // Использование следующей строки для явного указания, что сущность изменена,
                // чтобы Entity Framework отслеживал изменения
                Context.Entry(lastEntity).State = EntityState.Modified;
            }

            return lastEntity;
        }


    }
}
