using WordGuessGame.Models;

namespace WordGuessGame.Services
{
    public static class SessionService
    {
        public static User? CurrentUser
        {
            get;
            set;
        }
    }
}