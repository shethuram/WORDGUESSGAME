using WordGuessGame.Models;

namespace WordGuessGame.Interfaces
{
    public interface IGameSessionRepository
    {
        void SaveGameSession(GameSession session);
    }
}