using WordGuessGame.Models;

namespace WordGuessGame.Interfaces
{
    public interface IAuthenticationService
    {
        void Register();

        User Login();
    }
}