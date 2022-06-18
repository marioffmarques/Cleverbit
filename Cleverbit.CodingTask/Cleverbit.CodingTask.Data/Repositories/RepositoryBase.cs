using System.Collections.Generic;
using System.Threading.Tasks;
using Cleverbit.CodingTask.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Cleverbit.CodingTask.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _dbContext;

        public RepositoryBase(DbContext context)
        {
            _dbContext = context;
        }

        public Task AddAsync(TEntity entity)
        {
            EntityState state = _dbContext.Entry(entity).State;

            if (state == EntityState.Detached)
            {
                _dbContext.Set<TEntity>().Attach(entity);
            }
            _dbContext.Set<TEntity>().AddAsync(entity);

            return _dbContext.SaveChangesAsync();;
        }

        public ValueTask<TEntity> GetAsync(params object[] ids) =>
            _dbContext.Set<TEntity>().FindAsync(ids);

        public virtual async Task<IList<TEntity>> GetAllAsync() =>
            await _dbContext.Set<TEntity>().AsNoTracking().ToListAsync();
    }
}