using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cleverbit.CodingTask.Application.Match
{
    public interface IMatchService
    {
        /// <summary>
        /// Gets the current match statistics info.
        /// </summary>
        Task<MatchInfoDto> GetCurrentMatchInfoAsync();

        /// <summary>
        /// Gets all the winners results of all existent matches.
        /// </summary>
        Task<IReadOnlyCollection<MatchWinnerResultDto>> GetMatchesWinnersAsync();
    }
}