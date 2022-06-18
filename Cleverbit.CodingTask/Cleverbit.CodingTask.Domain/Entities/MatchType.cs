using System;

namespace Cleverbit.CodingTask.Domain.Entities
{
    public class MatchType : Entity
    {
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
    }
}