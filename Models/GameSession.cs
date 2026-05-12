namespace WordGuessGame.Models
{
    public class GameSession
    {
        public int UserId { get; set; }

        public string Difficulty
        {
            get;
            set;
        } = string.Empty;

        public int AttemptsUsed
        {
            get;
            set;
        }

        public int Score
        {
            get;
            set;
        }

        public int TimeTaken
        {
            get;
            set;
        }

        public bool IsWon
        {
            get;
            set;
        }

        public DateTime PlayedAt
        {
            get;
            set;
        }
    }
}