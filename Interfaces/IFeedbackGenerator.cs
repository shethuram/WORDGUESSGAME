namespace WordGuessGame.Interfaces
{
    public interface IFeedbackGenerator
    {
        string GenerateFeedback(string hiddenWord, string guess);
    }
}