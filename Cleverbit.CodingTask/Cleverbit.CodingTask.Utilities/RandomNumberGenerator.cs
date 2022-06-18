using System;

namespace Cleverbit.CodingTask.Utilities
{
    public static class RandomNumberGenerator
    {
        public static int Generate(int min = 0, int max = 100) =>
            new Random().Next(min, max);
    }
}