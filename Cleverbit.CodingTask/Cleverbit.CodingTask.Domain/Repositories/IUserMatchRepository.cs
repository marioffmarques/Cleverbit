using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cleverbit.CodingTask.Domain.Entities;

namespace Cleverbit.CodingTask.Domain.Repositories
{
    public interface IUserMatchRepository : IRepository<UserMatch>
    {
        /// <summary>
        /// Gets the user results for a given Match.
        /// </summary>
        /// <param name="matchId">Match Id.</param>
        /// <returns>List of results for the Match</returns>
        Task<IReadOnlyCollection<UserMatch>> GetMatchResultsAsync(Guid matchId);
    }
}