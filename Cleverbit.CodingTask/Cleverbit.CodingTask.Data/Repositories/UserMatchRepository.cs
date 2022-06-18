using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cleverbit.CodingTask.Domain.Entities;
using Cleverbit.CodingTask.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Cleverbit.CodingTask.Data.Repositories
{
    public class UserMatchRepository : RepositoryBase<UserMatch>, IUserMatchRepository
    {
        public UserMatchRepository(CodingTaskContext dbContext) : base(dbContext) { }

        public async Task<IReadOnlyCollection<UserMatch>> GetMatchResultsAsync(Guid matchId) =>
            await _dbContext.Set<UserMatch>()
                .AsSplitQuery()
                .AsNoTracking()
                .Include(x => x.User)
                .Where(x => x.MatchId == matchId)
                .ToArrayAsync();

        public override async Task<IList<UserMatch>> GetAllAsync() =>
            await _dbContext.Set<UserMatch>()
                .AsSplitQuery()
                .AsNoTracking()
                .Include(x => x.User)
                .Include(z => z.Match)
                    .ThenInclude(zz => zz.MatchType)
                .ToListAsync();
    }
}