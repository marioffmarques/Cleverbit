using System;

namespace Cleverbit.CodingTask.Domain.Exceptions
{
    public class ActiveMatchNotFoundException : Exception
    {
        public ActiveMatchNotFoundException() : base()
        {
        }

        public ActiveMatchNotFoundException(string message) : base(message)
        {
        }

        public ActiveMatchNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}