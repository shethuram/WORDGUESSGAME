using WordGuessGame.Models;

namespace WordGuessGame.Interfaces
{
    public interface IStatisticsService
    {
        void UpdateStatistics(bool isWon, int attemptsUsed);

        PlayerStatistics GetStatistics();
    }
}