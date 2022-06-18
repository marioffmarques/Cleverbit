namespace Cleverbit.CodingTask.Application
{
    public class PlayHitDto
    {
        public int PlayedNumber { get; }

        public PlayHitDto(int number)
        {
            PlayedNumber = number;
        }
    }
}