using System;
using System.Threading.Tasks;
using Cleverbit.CodingTask.Domain.Entities;

namespace Cleverbit.CodingTask.Domain.Repositories
{
    public interface IMatchRepository : IRepository<Match>
    {
        /// <summary>
        /// Gets the active Match.
        /// </summary>
        /// <returns>Active Match (if any).</returns>
        Task<Match> GetActiveMatchAsync(DateTime currentTime);
    }
}