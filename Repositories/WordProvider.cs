using WordGuessGame.Interfaces;

namespace WordGuessGame.Repositories
{
    public class WordProvider : IWordProvider
    {
        private readonly List<string> _words =
        [
            "APPLE",
            "MANGO",
            "GRAPE",
            "TRAIN",
            "PLANT",
            "BRAIN",
            "STONE",
            "CHAIR",
            "LIGHT",
            "CLOUD"
        ];

        public string GetRandomWord()
        {
            Random random = new();

            int index = random.Next(_words.Count);

            return _words[index];
        }
    }
}