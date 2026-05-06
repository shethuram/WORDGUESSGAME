namespace WordGuessGame.Interfaces
{
    public interface IScoreService
    {
        int CalculateScore(int attemptsUsed, bool hintUsed);
    }
}