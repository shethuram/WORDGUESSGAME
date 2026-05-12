using WordGuessGame.Models;

namespace WordGuessGame.Interfaces
{
    public interface IUserRepository
    {
        void Register(User user);

        User? Login(
            string username,
            string password);
    }
}