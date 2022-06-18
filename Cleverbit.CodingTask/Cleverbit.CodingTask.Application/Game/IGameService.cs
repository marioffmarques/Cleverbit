using System;
using System.Threading.Tasks;

namespace Cleverbit.CodingTask.Application.Game
{
    public interface IGameService
    {
        /// <summary>
        /// Plays the current Match (Generates and stores a random number for the given user).
        /// </summary>
        /// <param name="userId">Authenticated user id.</param>
        /// <returns>Generated number.</returns>
        public Task<PlayHitDto> PlayAsync(Guid userId);
    }
}