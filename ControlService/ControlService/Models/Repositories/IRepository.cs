using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;

namespace ControlService.Models.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public Task<TEntity> AddAsync(TEntity entity);
        public Task<TEntity> DeleteAsync(Guid id);
        public Task<TEntity> GetAsync(Guid id);
        public Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        public bool IfAny(Expression<Func<TEntity, bool>> predicate);
        public TEntity Update(TEntity entity);

    }
}
