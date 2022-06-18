using System;

namespace Cleverbit.CodingTask.Utilities
{
    public interface IDateTimeProvider
    {
        DateTime GetUtcNow();
    }
}