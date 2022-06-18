using System;
using System.Linq;
using System.Threading.Tasks;
using Cleverbit.CodingTask.Domain.Entities;
using Cleverbit.CodingTask.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Cleverbit.CodingTask.Data.Repositories
{
    public class MatchRepository : RepositoryBase<Match>, IMatchRepository
    {
        public MatchRepository(CodingTaskContext dbContext) : base(dbContext) { }

        public async Task<Match> GetActiveMatchAsync(DateTime currentTime)
        {
            var currentMatches = await _dbContext.Set<Match>()
                .AsSplitQuery()
                .AsNoTracking()
                .Include(x => x.MatchType)
                .Where(x => currentTime >= x.MatchStart)
                .ToArrayAsync();

            // Ensure there is only on Match active at a given time (SingleOrDefault)
            // TBD: This filter was implemented here because the expression could be translated by EFCore (investigate why)
            return currentMatches.SingleOrDefault(x => currentTime - x.MatchStart < x.MatchType.Duration);
        }
    }
}
