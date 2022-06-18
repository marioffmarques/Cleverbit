using Cleverbit.CodingTask.Domain.Entities;
using Cleverbit.CodingTask.Domain.Repositories;

namespace Cleverbit.CodingTask.Data.Repositories
{
    public class MatchTypeRepository : RepositoryBase<MatchType>, IMatchTypeRepository
    {
        public MatchTypeRepository(CodingTaskContext dbContext) : base(dbContext) { }
    }
}