using System;

namespace Cleverbit.CodingTask.Domain
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        protected Entity() : this(Guid.NewGuid()) { }

        protected Entity(Guid id)
        {
            Id = id;
        }
    }
}
