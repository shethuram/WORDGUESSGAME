namespace WordGuessGame.Services
{
    public class HintService
    {
        public void ShowHint(string hiddenWord)
        {
            Random random = new();

            int index = random.Next(hiddenWord.Length);

            Console.WriteLine(
                $"Hint: Letter at position {index + 1} is '{hiddenWord[index]}'");
        }
    }
}