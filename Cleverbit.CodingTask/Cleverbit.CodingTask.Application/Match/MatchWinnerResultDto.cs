using System;

namespace Cleverbit.CodingTask.Application
{
    public class MatchWinnerResultDto
    {
        public MatchWinnerResultDto(Guid matchId, string winner, int number, bool isFinished)
        {
            MatchId = matchId;
            Winner = winner;
            Number = number;
            IsFinished = isFinished;
        }

        public Guid MatchId { get; }
        public string Winner { get; }
        public int Number { get; }
        public bool IsFinished { get; }
    }
}