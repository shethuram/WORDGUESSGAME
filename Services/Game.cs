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

        private readonly IGameSessionRepository
            _gameSessionRepository;

        public Game(
            IWordProvider wordProvider,
            IGuessValidator validator,
            IFeedbackGenerator feedbackGenerator,
            IScoreService scoreService,
            IStatisticsService statisticsService,
            HintService hintService,
            IGameSessionRepository gameSessionRepository)
        {
            _wordProvider = wordProvider;

            _validator = validator;

            _feedbackGenerator = feedbackGenerator;

            _scoreService = scoreService;

            _statisticsService = statisticsService;

            _hintService = hintService;

            _gameSessionRepository =
                gameSessionRepository;
        }

        public void StartGame()
        {
            Console.Clear();

            Console.WriteLine(
                $"Welcome {SessionService.CurrentUser!.Username}");

            DifficultyLevel difficulty =
                SelectDifficulty();

            GameSettings settings =
                GetSettings(difficulty);

            GameState gameState = new()
            {
                HiddenWord =
                    _wordProvider.GetRandomWord()
            };

            TimerHelper timer = new();

            timer.Start();

            bool hintUsed = false;

            bool won = false;

            int score = 0;

            while (gameState.AttemptsUsed <
                   settings.MaxAttempts)
            {
                Console.Write(
                    $"\nAttempt {gameState.AttemptsUsed + 1}: ");

                string guess =
                    Console.ReadLine()?.ToUpper() ?? "";

                if (guess == "HINT" &&
                    settings.HintAllowed)
                {
                    _hintService.ShowHint(
                        gameState.HiddenWord);

                    hintUsed = true;

                    continue;
                }

                try
                {
                    _validator.Validate(
                        guess,
                        gameState);

                    gameState.GuessedWords
                        .Add(guess);

                    gameState.AttemptsUsed++;

                    string feedback =
                        _feedbackGenerator
                            .GenerateFeedback(
                                gameState.HiddenWord,
                                guess);

                    PrintColoredFeedback(feedback);

                    if (guess ==
                        gameState.HiddenWord)
                    {
                        won = true;

                        score =
                            _scoreService
                                .CalculateScore(
                                    gameState.AttemptsUsed,
                                    hintUsed);

                        timer.Stop();

                        ConsoleHelper.ShowSuccess(
                            "\nYou guessed correctly!");

                        Console.WriteLine(
                            $"Score : {score}");

                        Console.WriteLine(
                            $"Time Taken : {timer.GetElapsedSeconds()} seconds");

                        break;
                    }
                }
                catch (Exception ex)
                {
                    ConsoleHelper.ShowError(
                        ex.Message);
                }
            }

            if (!won)
            {
                timer.Stop();

                ConsoleHelper.ShowError(
                    $"\nGame Over! Hidden word was {gameState.HiddenWord}");
            }

            _statisticsService
                .UpdateStatistics(
                    won,
                    gameState.AttemptsUsed);

            GameSession session = new()
            {
                UserId =
                    SessionService
                        .CurrentUser!.Id,

                Difficulty =
                    difficulty.ToString(),

                AttemptsUsed =
                    gameState.AttemptsUsed,

                Score = score,

                TimeTaken =
                    (int)timer
                        .GetElapsedSeconds(),

                IsWon = won,

                PlayedAt = DateTime.Now
            };

            _gameSessionRepository
                .SaveGameSession(session);

            Console.WriteLine(
                "\nPress any key to continue...");

            Console.ReadKey(true);
        }

        private DifficultyLevel SelectDifficulty()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine(
                    "===== SELECT DIFFICULTY =====");

                Console.WriteLine("1. Easy");

                Console.WriteLine("2. Medium");

                Console.WriteLine("3. Hard");

                Console.Write("\nChoice: ");

                string? input =
                    Console.ReadLine();

                switch (input)
                {
                    case "1":
                        return DifficultyLevel.Easy;

                    case "2":
                        return DifficultyLevel.Medium;

                    case "3":
                        return DifficultyLevel.Hard;

                    default:

                        ConsoleHelper.ShowError(
                            "\nInvalid Difficulty Choice!");

                        Console.ReadKey(true);

                        break;
                }
            }
        }

        private GameSettings GetSettings(
            DifficultyLevel difficulty)
        {
            return difficulty switch
            {
                DifficultyLevel.Easy =>
                    new GameSettings
                    {
                        MaxAttempts = 6,
                        HintAllowed = true,
                        Difficulty = difficulty
                    },

                DifficultyLevel.Medium =>
                    new GameSettings
                    {
                        MaxAttempts = 5,
                        HintAllowed = false,
                        Difficulty = difficulty
                    },

                DifficultyLevel.Hard =>
                    new GameSettings
                    {
                        MaxAttempts = 4,
                        HintAllowed = false,
                        Difficulty = difficulty
                    },

                _ => new GameSettings()
            };
        }

        private void PrintColoredFeedback(
            string feedback)
        {
            Console.WriteLine();

            foreach (char c in feedback)
            {
                switch (c)
                {
                    case 'G':

                        Console.ForegroundColor =
                            ConsoleColor.Green;

                        break;

                    case 'Y':

                        Console.ForegroundColor =
                            ConsoleColor.Yellow;

                        break;

                    default:

                        Console.ForegroundColor =
                            ConsoleColor.Red;

                        break;
                }

                Console.Write($"{c} ");

                Console.ResetColor();
            }

            Console.WriteLine();
        }
    }
}

