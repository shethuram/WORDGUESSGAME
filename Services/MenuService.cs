using WordGuessGame.Interfaces;

namespace WordGuessGame.Services
{
    public class MenuService
    {
        private readonly Game _game;
        private readonly IStatisticsService _statisticsService;

        public MenuService(Game game,
            IStatisticsService statisticsService)
        {
            _game = game;
            _statisticsService = statisticsService;
        }

        public void ShowMenu()
        {
            bool running = true;

            while (running)
            {
                Console.Clear();

                Console.WriteLine("========================");
                Console.WriteLine("WORD GUESS GAME");
                Console.WriteLine("========================");
                Console.WriteLine("1. Start New Game");
                Console.WriteLine("2. View Rules");
                Console.WriteLine("3. View Statistics");
                Console.WriteLine("4. Exit");

                Console.Write("\nEnter choice: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        _game.StartGame();
                        break;

                    case "2":
                        ShowRules();
                        break;

                    case "3":
                        ShowStatistics();
                        break;

                    case "4":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void ShowRules()
        {
            Console.Clear();

            Console.WriteLine("========== RULES ==========");
            Console.WriteLine("Guess the hidden 5-letter word.");
            Console.WriteLine("G = Correct letter and position");
            Console.WriteLine("Y = Correct letter wrong position");
            Console.WriteLine("X = Letter not present");
            Console.WriteLine();

            Console.WriteLine("Easy   -> 6 Attempts + Hint Allowed");
            Console.WriteLine("Medium -> 5 Attempts");
            Console.WriteLine("Hard   -> 4 Attempts");
            Console.WriteLine();

            Console.WriteLine("Type HINT in Easy mode.");
            Console.WriteLine();

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void ShowStatistics()
        {
            Console.Clear();

            var stats = _statisticsService.GetStatistics();

            Console.WriteLine("========== STATISTICS ==========");
            Console.WriteLine($"Games Played : {stats.GamesPlayed}");
            Console.WriteLine($"Games Won    : {stats.GamesWon}");
            Console.WriteLine($"Games Lost   : {stats.GamesLost}");
            Console.WriteLine($"Win Rate     : {stats.WinRate:F2}%");
            Console.WriteLine($"Avg Attempts : {stats.AverageAttempts:F2}");

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}