namespace WordGuessGame.Models
{
    public class GameState
    {
        public string HiddenWord { get; set; } = string.Empty;

        public int AttemptsUsed { get; set; }

        public int Score { get; set; }

        public HashSet<string> GuessedWords { get; set; } = new();
    }
}