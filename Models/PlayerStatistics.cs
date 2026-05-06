namespace WordGuessGame.Models
{
    public class PlayerStatistics
    {
        public int GamesPlayed { get; set; }

        public int GamesWon { get; set; }

        public int GamesLost { get; set; }

        public int TotalAttempts { get; set; }

        public double WinRate
        {
            get
            {
                if (GamesPlayed == 0)
                {
                    return 0;
                }

                return (double)GamesWon / GamesPlayed * 100;
            }
        }

        public double AverageAttempts
        {
            get
            {
                if (GamesPlayed == 0)
                {
                    return 0;
                }

                return (double)TotalAttempts / GamesPlayed;
            }
        }
    }
}