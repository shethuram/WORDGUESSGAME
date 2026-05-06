using WordGuessGame.Interfaces;

namespace WordGuessGame.Services
{
    public class FeedbackGenerator : IFeedbackGenerator
    {
        public string GenerateFeedback(string hiddenWord, string guess)
        {
            char[] feedback = ['X', 'X', 'X', 'X', 'X'];

            bool[] matchedPositions = new bool[5];

            // PASS 1 -> Exact matches (G)
            for (int i = 0; i < 5; i++)
            {
                if (guess[i] == hiddenWord[i])
                {
                    feedback[i] = 'G';
                    matchedPositions[i] = true;
                }
            }

            // PASS 2 -> Wrong position matches (Y)
            for (int i = 0; i < 5; i++)
            {
                // Skip already matched letters
                if (feedback[i] == 'G')
                {
                    continue;
                }

                for (int j = 0; j < 5; j++)
                {
                    // Skip already used hidden positions
                    if (matchedPositions[j])
                    {
                        continue;
                    }

                    // Match found
                    if (guess[i] == hiddenWord[j])
                    {
                        feedback[i] = 'Y';

                        // consume that hidden letter
                        matchedPositions[j] = true;

                        break;
                    }
                }
            }

            return new string(feedback);
        }
    }
}