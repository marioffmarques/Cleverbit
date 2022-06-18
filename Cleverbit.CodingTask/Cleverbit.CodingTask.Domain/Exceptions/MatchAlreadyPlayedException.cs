using System;

namespace Cleverbit.CodingTask.Domain.Exceptions
{
    public class MatchAlreadyPlayedException : Exception
    {
        public MatchAlreadyPlayedException() : base()
        {
        }

        public MatchAlreadyPlayedException(string message) : base(message)
        {
        }

        public MatchAlreadyPlayedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}