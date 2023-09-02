using CleanCodeLaboration.Controller;
using CleanCodeLaboration.Model.GameDAO.Interface;
using CleanCodeLaboration.Model.GameDAO;
using CleanCodeLaboration.Model.GameLogic.Interface;
using CleanCodeLaboration.Model.GameLogic;
using CleanCodeLaboration.View.Interface;
using CleanCodeLaboration.View;
using CleanCodeLaboration.Model.GameMenu;
using CleanCodeLaboration.Model.GameMenu.Interface;
using CleanCodeLaboration.Model.GameMenu.Commands;
using CleanCodeLaboration.Model.GameHighScore.Interface;
using CleanCodeLaboration.Model.GameHighScore;

IIO iO = new ConsoleView();

IGameDAO gameDAO = new LocalFileDAO();

IHighScoreFormatter highScoreFormatter = new HighScoreFormatter();

IGameContext gameContext = new GameContext(gameDAO, highScoreFormatter);

ICommand[] commands = new ICommand[]
{
            new MooGameCommand(),
            new QuizCommand()
};

IGameMenu gameMenu = new GameStrategyMenu(commands);

GameController controller = new GameController(gameContext, iO, gameMenu);


controller.InitializeGame();