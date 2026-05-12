using WordGuessGame.Interfaces;
using WordGuessGame.Models;

namespace WordGuessGame.Services
{
    public class StatisticsService
        : IStatisticsService
    {
        private readonly IStatisticsRepository
            _statisticsRepository;

        public StatisticsService(
            IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository =
                statisticsRepository;
        }

        public void UpdateStatistics(
            bool isWon,
            int attemptsUsed)
        {
            _statisticsRepository
                .UpdateStatistics(
                    isWon,
                    attemptsUsed);
        }

        public PlayerStatistics GetStatistics()
        {
            return _statisticsRepository
                .GetStatistics();
        }
    }
}

