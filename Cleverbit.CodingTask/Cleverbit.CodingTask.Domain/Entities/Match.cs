using System;

namespace Cleverbit.CodingTask.Domain.Entities
{
    public class Match : Entity
    {
        public Guid MatchTypeId { get; set; }
        public MatchType MatchType { get; set; }
        public DateTime MatchStart { get; set; }
    }
}