using System;

namespace Cleverbit.CodingTask.Application.Match
{
    public class MatchInfoDto
    {
        public MatchInfoDto(Guid matchId, string currentWinner, int currentWinnerNumber, DateTime expiresAt)
        {
            MatchId = matchId;
            CurrentWinner = currentWinner;
            CurrentWinnerNumber = currentWinnerNumber;
            ExpiresAtUtc = expiresAt;
        }

        public Guid MatchId { get; set; }

        /// <summary>
        /// Represent the winner at a given point in time. The match might not be finished yet, so the Winner might change in the future.
        /// </summary>
        public string CurrentWinner { get; set; }
        public int CurrentWinnerNumber { get; set; }

        /// <summary>
        /// Datetime value expressing the moment when the Match finishes.
        /// </summary>
        public DateTime ExpiresAtUtc { get; }
    }
}