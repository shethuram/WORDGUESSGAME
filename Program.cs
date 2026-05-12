using WordGuessGame.Data;
using WordGuessGame.Interfaces;
using WordGuessGame.Repositories;
using WordGuessGame.Services;

DatabaseInitializer.Initialize();

IWordProvider wordProvider =
    new WordProvider();

IGuessValidator validator =
    new GuessValidator();

IFeedbackGenerator feedbackGenerator =
    new FeedbackGenerator();

IScoreService scoreService =
    new ScoreService();

IStatisticsRepository statisticsRepository =
    new StatisticsRepository();

IStatisticsService statisticsService =
    new StatisticsService(
        statisticsRepository);

IGameSessionRepository gameSessionRepository =
    new GameSessionRepository();

IUserRepository userRepository =
    new UserRepository();

IAuthenticationService authenticationService =
    new AuthenticationService(
        userRepository);

HintService hintService =
    new();

Game game = new(
    wordProvider,
    validator,
    feedbackGenerator,
    scoreService,
    statisticsService,
    hintService,
    gameSessionRepository);

MenuService menu =
    new(game, statisticsService);

bool running = true;

while (running)
{
    Console.Clear();

    Console.WriteLine(
        "===== WORD GUESS GAME =====");

    Console.WriteLine("1. Login");

    Console.WriteLine("2. Register");

    Console.WriteLine("3. Exit");

    Console.Write("\nChoice: ");

    string? choice =
        Console.ReadLine();

    switch (choice)
    {
        case "1":

            SessionService.CurrentUser =
                authenticationService.Login();

            menu.ShowMenu();

            break;

        case "2":

            authenticationService.Register();

            break;

        case "3":

            running = false;

            break;

        default:

            Console.WriteLine(
                "Invalid Choice!");

            Console.ReadKey(true);

            break;
    }
}

