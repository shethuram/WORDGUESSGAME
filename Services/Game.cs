using WordGuessGame.Interfaces;
using WordGuessGame.Models;
using WordGuessGame.Utilities;

namespace WordGuessGame.Services
{
    public class Game
    {
        private readonly IWordProvider _wordProvider;
        private readonly IGuessValidator _validator;
        private readonly IFeedbackGenerator _feedbackGenerator;
        private readonly IScoreService _scoreService;
        private readonly IStatisticsService _statisticsService;
        private readonly HintService _hintService;

        public Game(
            IWordProvider wordProvider,
            IGuessValidator validator,
            IFeedbackGenerator feedbackGenerator,
            IScoreService scoreService,
            IStatisticsService statisticsService,
            HintService hintService)
        {
            _wordProvider = wordProvider;
            _validator = validator;
            _feedbackGenerator = feedbackGenerator;
            _scoreService = scoreService;
            _statisticsService = statisticsService;
            _hintService = hintService;
        }

        public void StartGame()
        {
            Console.Clear();

            DifficultyLevel difficulty = SelectDifficulty();

            GameSettings settings = GetSettings(difficulty);

            GameState gameState = new()
            {
                HiddenWord = _wordProvider.GetRandomWord()
            };

            TimerHelper timer = new();
            timer.Start();

            bool hintUsed = false;
            bool won = false;

            while (gameState.AttemptsUsed < settings.MaxAttempts)
            {
                Console.Write($"\nAttempt {gameState.AttemptsUsed + 1}: ");

                string guess = Console.ReadLine()?.ToUpper() ?? "";

                if (guess == "HINT" && settings.HintAllowed)
                {
                    _hintService.ShowHint(gameState.HiddenWord);
                    hintUsed = true;
                    continue;
                }

                try
                {
                    _validator.Validate(guess, gameState);

                    gameState.GuessedWords.Add(guess);

                    gameState.AttemptsUsed++;

                    string feedback =
                        _feedbackGenerator.GenerateFeedback(
                            gameState.HiddenWord,
                            guess);

                    PrintColoredFeedback(feedback);

                    if (guess == gameState.HiddenWord)
                    {
                        won = true;

                        int score = _scoreService.CalculateScore(
                            gameState.AttemptsUsed,
                            hintUsed);

                        timer.Stop();

                        ConsoleHelper.ShowSuccess(
                            $"\nYou guessed correctly!");

                        Console.WriteLine($"Score : {score}");

                        Console.WriteLine(
                            $"Time Taken : {timer.GetElapsedSeconds()} seconds");

                        break;
                    }
                }
                catch (Exception ex)
                {
                    ConsoleHelper.ShowError(ex.Message);
                }
            }

            if (!won)
            {
                ConsoleHelper.ShowError(
                    $"\nGame Over! Hidden word was {gameState.HiddenWord}");
            }

            _statisticsService.UpdateStatistics(
                won,
                gameState.AttemptsUsed);

            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }

        private DifficultyLevel SelectDifficulty()
        {
            Console.WriteLine("Select Difficulty");
            Console.WriteLine("1. Easy");
            Console.WriteLine("2. Medium");
            Console.WriteLine("3. Hard");

            Console.Write("Choice: ");

            string? input = Console.ReadLine();

            return input switch
            {
                "1" => DifficultyLevel.Easy,
                "2" => DifficultyLevel.Medium,
                "3" => DifficultyLevel.Hard,
                _ => DifficultyLevel.Easy
            };
        }

        private GameSettings GetSettings(DifficultyLevel difficulty)
        {
            return difficulty switch
            {
                DifficultyLevel.Easy => new GameSettings
                {
                    MaxAttempts = 6,
                    HintAllowed = true,
                    Difficulty = difficulty
                },

                DifficultyLevel.Medium => new GameSettings
                {
                    MaxAttempts = 5,
                    HintAllowed = false,
                    Difficulty = difficulty
                },

                DifficultyLevel.Hard => new GameSettings
                {
                    MaxAttempts = 4,
                    HintAllowed = false,
                    Difficulty = difficulty
                },

                _ => new GameSettings()
            };
        }

        private void PrintColoredFeedback(string feedback)
        {
            foreach (char c in feedback)
            {
                switch (c)
                {
                    case 'G':
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;

                    case 'Y':
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                }

                Console.Write($"{c} ");
                Console.ResetColor();
            }

            Console.WriteLine();
        }
    }
}