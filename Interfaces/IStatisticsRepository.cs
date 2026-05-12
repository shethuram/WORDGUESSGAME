using WordGuessGame.Models;

namespace WordGuessGame.Interfaces
{
    public interface IStatisticsRepository
    {
        void UpdateStatistics(
            bool isWon,
            int attemptsUsed);

        PlayerStatistics GetStatistics();
    }
}