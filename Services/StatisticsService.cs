using WordGuessGame.Interfaces;
using WordGuessGame.Models;

namespace WordGuessGame.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly PlayerStatistics _statistics = new();

        public void UpdateStatistics(bool isWon, int attemptsUsed)
        {
            _statistics.GamesPlayed++;

            if (isWon)
            {
                _statistics.GamesWon++;
            }
            else
            {
                _statistics.GamesLost++;
            }

            _statistics.TotalAttempts += attemptsUsed;
        }

        public PlayerStatistics GetStatistics()
        {
            return _statistics;
        }
    }
}