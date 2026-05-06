namespace WordGuessGame.Exceptions
{
    public class InvalidGuessException : Exception
    {
        public InvalidGuessException(string message)
            : base(message)
        {
        }
    }
}