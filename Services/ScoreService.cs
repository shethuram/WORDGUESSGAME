using WordGuessGame.Interfaces;

namespace WordGuessGame.Services
{
    public class ScoreService : IScoreService
    {
        public int CalculateScore(int attemptsUsed, bool hintUsed)
        {
            int score = 100 - ((attemptsUsed - 1) * 20);

            if (hintUsed)
            {
                score -= 10;
            }

            return Math.Max(score, 0);
        }
    }
}