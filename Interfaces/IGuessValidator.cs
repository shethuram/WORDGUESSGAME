using WordGuessGame.Models;

namespace WordGuessGame.Interfaces
{
    public interface IGuessValidator
    {
        void Validate(string guess, GameState gameState);
    }
}