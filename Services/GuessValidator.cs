using WordGuessGame.Exceptions;
using WordGuessGame.Interfaces;
using WordGuessGame.Models;

namespace WordGuessGame.Services
{
    public class GuessValidator : IGuessValidator
    {
        public void Validate(string guess, GameState gameState)
        {
            if (string.IsNullOrWhiteSpace(guess))
            {
                throw new InvalidGuessException(
                    "Input cannot be empty. Please enter a 5-letter word.");
            }

            if (guess.Length < 5)
            {
                throw new InvalidGuessException(
                    "Word must contain exactly 5 letters. Input is too short.");
            }

            if (guess.Length > 5)
            {
                throw new InvalidGuessException(
                    "Word must contain exactly 5 letters. Input is too long.");
            }

            if (guess.Any(char.IsDigit))
            {
                throw new InvalidGuessException(
                    "Numbers are not allowed in the word guess.");
            }

            if (!guess.All(char.IsLetter))
            {
                throw new InvalidGuessException(
                    "Special characters are not allowed in the word guess.");
            }

            if (gameState.GuessedWords.Contains(guess.ToUpper()))
            {
                throw new InvalidGuessException(
                    "You already guessed this word. Try a different word.");
            }
        }
    }
}