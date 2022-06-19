using System;
using System.Linq;
using System.Threading.Tasks;
using Cleverbit.CodingTask.Domain.Entities;
using Cleverbit.CodingTask.Domain.Exceptions;
using Cleverbit.CodingTask.Domain.Repositories;
using Cleverbit.CodingTask.Utilities;

namespace Cleverbit.CodingTask.Application.Game
{
    public class GameService : IGameService
    {
        private readonly IMatchRepository _matchRepository;
        private readonly IUserMatchRepository _userMatchRepository;
        private readonly IMatchTypeRepository _matchTypeRepository;
        private readonly IDateTimeProvider _dateProvider;

        public GameService(IMatchRepository matchRepository, IUserMatchRepository userMatchRepository, IMatchTypeRepository matchTypeRepository, IDateTimeProvider dateProvider)
        {
            _matchRepository = matchRepository;
            _userMatchRepository = userMatchRepository;
            _matchTypeRepository = matchTypeRepository;
            _dateProvider = dateProvider;
        }

        public async Task<PlayHitDto> PlayAsync(Guid userId)
        {
            Domain.Entities.Match activeMatch = await _matchRepository.GetActiveMatchAsync(_dateProvider.GetUtcNow());

            if (activeMatch != default)
            {
                // Check if user has already played the match
                var currentUserPlay = await _userMatchRepository.GetAsync(activeMatch.Id, userId);

                if (currentUserPlay != default) throw new MatchAlreadyPlayedException();
            }
            else
            {
                activeMatch = new Domain.Entities.Match()
                {
                    MatchTypeId = (await _matchTypeRepository.GetAllAsync()).First().Id, // TBD: Validate if MatchTypes exists on the database (To avoid NRE)
                    MatchStart = _dateProvider.GetUtcNow()
                };

                await _matchRepository.AddAsync(activeMatch);
            }

            var playNumber = RandomNumberGenerator.Generate();
            await _userMatchRepository.AddAsync(new UserMatch
            {
                MatchId = activeMatch.Id,
                UserId = userId,
                Number = playNumber
            });

            return new PlayHitDto(playNumber);
        }
    }
}
