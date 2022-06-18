using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cleverbit.CodingTask.Domain.Exceptions;
using Cleverbit.CodingTask.Domain.Repositories;
using Cleverbit.CodingTask.Utilities;

namespace Cleverbit.CodingTask.Application.Match
{
    public class MatchService : IMatchService
    {
        private readonly IMatchRepository _matchRepository;
        private readonly IUserMatchRepository _userMatchRepository;
        private readonly IDateTimeProvider _dateProvider;

        public MatchService(IUserMatchRepository userMatchRepository, IMatchRepository matchRepository, IDateTimeProvider dateProvider)
        {
            _matchRepository = matchRepository;
            _userMatchRepository = userMatchRepository;
            _dateProvider = dateProvider;
        }

        public async Task<MatchInfoDto> GetCurrentMatchInfoAsync()
        {
            Domain.Entities.Match activeMatch = await _matchRepository.GetActiveMatchAsync(_dateProvider.GetUtcNow());

            if (activeMatch == default) throw new ActiveMatchNotFoundException();

            var matchResults = await _userMatchRepository.GetMatchResultsAsync(activeMatch.Id);

            var currentMatchWinner = matchResults.OrderByDescending(x => x.Number).First();

            return new MatchInfoDto(
                activeMatch.Id,
                currentMatchWinner.User.UserName,
                currentMatchWinner.Number,
                activeMatch.MatchStart + activeMatch.MatchType.Duration);
        }

        public async Task<IReadOnlyCollection<MatchWinnerResultDto>> GetMatchesWinnersAsync()
        {
            var matchResults = await _userMatchRepository.GetAllAsync();

            return matchResults.GroupBy(
                x => x.MatchId,
                (key, result) => new MatchWinnerResultDto(
                    key,
                    result.OrderByDescending(w => w.Number).First().User.UserName,
                    result.Max(n => n.Number),
                    _dateProvider.GetUtcNow() >= result.First().Match.MatchStart + result.First().Match.MatchType.Duration)
            ).ToArray();
        }
    }
}