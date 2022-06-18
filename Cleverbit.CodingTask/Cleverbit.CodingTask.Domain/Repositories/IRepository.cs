using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cleverbit.CodingTask.Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Adds an entity to the datastore.
        /// </summary>
        /// <param name="entity">Entity object</param>
        Task AddAsync(TEntity entity);

        /// <summary>
        /// Gets an entity from the datastore by its identifiers.
        /// </summary>
        /// <param name="ids"></param>
        ValueTask<TEntity> GetAsync(params object[] ids);

        /// <summary>
        /// Gets all entities of a given type.
        /// </summary>
        Task<IList<TEntity>> GetAllAsync();
    }
}