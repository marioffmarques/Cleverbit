using System;

namespace Cleverbit.CodingTask.Utilities
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime GetUtcNow() =>
            DateTime.UtcNow;
    }
}