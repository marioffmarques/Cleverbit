using System;
using System.Threading.Tasks;
using Cleverbit.CodingTask.Application.Match;
using Cleverbit.CodingTask.Domain.Exceptions;
using Cleverbit.CodingTask.Domain.Repositories;
using Cleverbit.CodingTask.Utilities;
using FluentAssertions;
using Moq;
using Xunit;

namespace Cleverbit.CodingTask.Tests.Unit.Game
{
    public class MatchServiceTests
    {
        private static readonly DateTime _currentUtcDate = new System.DateTime(2022, 6, 19, 10, 10, 10);
        private static readonly Domain.Entities.Match _currentMatch = new Domain.Entities.Match()
        {
            MatchTypeId = Guid.NewGuid(),
            MatchStart = _currentUtcDate,
            MatchType = new Domain.Entities.MatchType()
            {
                Duration = TimeSpan.FromMinutes(3)
            }
        };

        private readonly Domain.Entities.UserMatch _userMatch1 = new Domain.Entities.UserMatch()
        {
            MatchId = _currentMatch.Id,
            UserId = Guid.NewGuid(),
            User = new Domain.Entities.User()
            {
                UserName = "User1"
            },
            Number = 10
        };

        private readonly Domain.Entities.UserMatch _userMatch2 = new Domain.Entities.UserMatch()
        {
            MatchId = _currentMatch.Id,
            UserId = Guid.NewGuid(),
            User = new Domain.Entities.User()
            {
                UserName = "User2"
            },
            Number = 15
        };

        private readonly Domain.Entities.UserMatch _userMatch3 = new Domain.Entities.UserMatch()
        {
            MatchId = _currentMatch.Id,
            UserId = Guid.NewGuid(),
            User = new Domain.Entities.User()
            {
                UserName = "User3"
            },
            Number = 3
        };

        private readonly Domain.Entities.UserMatch _userMatch4 = new Domain.Entities.UserMatch()
        {
            MatchId = _currentMatch.Id,
            UserId = Guid.NewGuid(),
            User = new Domain.Entities.User()
            {
                UserName = "User4"
            },
            Number = 15
        };

        private readonly IMatchService _matchService;
        private readonly Mock<IUserMatchRepository> _userMatchRepositoryMock = new Mock<IUserMatchRepository>();
        private readonly Mock<IMatchRepository> _matchRepositoryMock = new Mock<IMatchRepository>();
        private readonly Mock<IDateTimeProvider> _dateTimeProviderMock = new Mock<IDateTimeProvider>();

        public MatchServiceTests()
        {
            _dateTimeProviderMock
                .Setup(x => x.GetUtcNow())
                .Returns(_currentUtcDate);

            _matchRepositoryMock
                .Setup(x => x.GetActiveMatchAsync(_currentUtcDate))
                .ReturnsAsync(_currentMatch);

            _matchService = new MatchService(_userMatchRepositoryMock.Object, _matchRepositoryMock.Object, _dateTimeProviderMock.Object);
        }

        [Fact]
        public async Task GetCurrentMatchInfo_WithActiveMatch_Should_RetrieveMatchInfo()
        {
            /*
             *  Setup test
             */
            _userMatchRepositoryMock
                .Setup(x => x.GetMatchResultsAsync(_currentMatch.Id))
                .ReturnsAsync(new Domain.Entities.UserMatch[]
                {
                    _userMatch1, _userMatch2, _userMatch3
                });

            /*
             *  Act
             */
            var currentMatchInfo = await _matchService.GetCurrentMatchInfoAsync();

            /*
             * Assert
             */
            currentMatchInfo.Should().NotBeNull();
            currentMatchInfo.CurrentWinner.Should().Be(_userMatch2.User.UserName);
            currentMatchInfo.ExpiresAtUtc.Should().Be(_currentUtcDate.AddMinutes(3));
        }

        [Fact]
        public async Task GetCurrentMatchInfo_WithMultipleWinners_Should_RetrieveMatchInfo_WithFirstWinner()
        {
            /*
             *  Setup test
             */
            _userMatchRepositoryMock
                .Setup(x => x.GetMatchResultsAsync(_currentMatch.Id))
                .ReturnsAsync(new Domain.Entities.UserMatch[]
                {
                    _userMatch1, _userMatch2, _userMatch3, _userMatch4
                });

            /*
             *  Act
             */
            var currentMatchInfo = await _matchService.GetCurrentMatchInfoAsync();

            /*
             * Assert
             */
            currentMatchInfo.Should().NotBeNull();
            currentMatchInfo.CurrentWinner.Should().Be(_userMatch2.User.UserName);
            currentMatchInfo.ExpiresAtUtc.Should().Be(_currentUtcDate.AddMinutes(3));
        }

        [Fact]
        public async Task GetCurrentMatchInfo_WithNoActiveMatch_Should_Throw()
        {
            /*
             *  Setup test
             */
            _matchRepositoryMock.Setup(x => x.GetActiveMatchAsync(_currentUtcDate))
                .ReturnsAsync(default(Domain.Entities.Match));

            /*
             *  Act
             */
            Func<Task> act = async () => await _matchService.GetCurrentMatchInfoAsync();

            /*
             * Assert
             */
            await act.Should().ThrowExactlyAsync<ActiveMatchNotFoundException>();
        }

        public void GetMatchesWinners_WithMultipleCompletedMatches_Should_RetrieveMatchesWinners()
        {
            // TBD: Implement test
        }

        public void GetMatchesWinners_WithNoMatches_Should_RetrieveEmptyResult()
        {
            // TBD: Implement test
        }

        public void GetMatchesWinners_WithOnGoingMatch_Should_RetrieveCurrentWinner()
        {
            // TBD: Implement test
        }
    }
}