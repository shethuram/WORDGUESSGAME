using WordGuessGame.Interfaces;
using WordGuessGame.Repositories;
using WordGuessGame.Services;

IWordProvider wordProvider = new WordProvider();

IGuessValidator validator = new GuessValidator();

IFeedbackGenerator feedbackGenerator = new FeedbackGenerator();

IScoreService scoreService = new ScoreService();

IStatisticsService statisticsService = new StatisticsService();

HintService hintService = new();

Game game = new(
    wordProvider,
    validator,
    feedbackGenerator,
    scoreService,
    statisticsService,
    hintService);

MenuService menu = new(game, statisticsService);

menu.ShowMenu();