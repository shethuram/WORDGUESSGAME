namespace WordGuessGame.Models
{
    public class GameSettings
    {
        public int MaxAttempts { get; set; }
        public bool HintAllowed { get; set; }
        public DifficultyLevel Difficulty { get; set; }
    }
}