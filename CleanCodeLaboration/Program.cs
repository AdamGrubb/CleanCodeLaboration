using CleanCodeLaboration.Controller;
using CleanCodeLaboration.Model.GameDAO.Interface;
using CleanCodeLaboration.Model.GameDAO;
using CleanCodeLaboration.Model.GameLogic.Interface;
using CleanCodeLaboration.Model.GameLogic;
using CleanCodeLaboration.View.Interface;
using CleanCodeLaboration.View;
using CleanCodeLaboration.Model.GameHighScore.Interface;
using CleanCodeLaboration.Model.GameHighScore;
using CleanCodeLaboration.Controller.GameLoop.Interface;
using CleanCodeLaboration.Controller.GameMenu.Interface;
using CleanCodeLaboration.Controller.GameMenu;
using CleanCodeLaboration.Controller.GameMenu.Commands;
using CleanCodeLaboration.Controller.GameLoop;

IIO iO = new ConsoleView();

IGameDAO gameDAO = new LocalFileDAO();

IHighScoreFormatter highScoreFormatter = new HighScoreFormatter();

IGameContext gameContext = new GameContext(gameDAO, highScoreFormatter);

ICommand[] commands = new ICommand[] //Factory här då? Så kan du ha olik
{
            new MooGameCommand(),
            new QuizCommand()
};

IGameMenu gameMenu = new GameStrategyMenu(commands, iO);
IGameLoop gameLoop = new GameLoop(iO, gameContext);

GameController controller = new GameController(gameLoop, gameMenu);
controller.StartGame();