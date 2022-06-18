using System;

namespace Cleverbit.CodingTask.Domain.Entities
{
    public class UserMatch
    {
        public Guid MatchId { get; set; }
        public Match Match { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public int Number { get; set; }
    }
}