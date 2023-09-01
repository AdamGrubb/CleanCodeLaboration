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

IIO iO = new ConsoleView();

IGameDAO gameDAO = new LocalFileDAO();

IGameContext gameContext = new GameContext(gameDAO);

ICommand[] commands = new ICommand[]
{
            new MooGameCommand(),
            new QuizCommand()
};

IGameMenu gameMenu = new GameStrategyMenu(commands);

GameController controller = new GameController(gameContext, iO, gameMenu);


controller.InitializeGame();