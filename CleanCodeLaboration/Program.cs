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
using CleanCodeLaboration.Model.GameLogic.Strategy.QuizGameStrategy.QuizQuestionDAO.Interface;
using CleanCodeLaboration.Model.GameLogic.Strategy.QuizGameStrategy.QuizQuestionDAO;

IQuizQuestionDAO quizQuestionDAO = new StarWarsQuestionDAO();
IIO iO = new ConsoleView();

IGameDAO gameDAO = new LocalFileDAO();

IHighScoreFormatter highScoreFormatter = new HighScoreFormatter();

IGameContext gameContext = new GameLogicContext(highScoreFormatter);

IGameCommand[] commands = new IGameCommand[]
{
            new MooGameCommand(gameDAO),
            new QuizCommand(gameDAO, quizQuestionDAO)
};

IGameMenu gameMenu = new GameStrategyMenu(commands, iO);
IGameLoop gameLoop = new GameLoop(iO, gameContext);

GameController controller = new GameController(gameLoop, gameMenu);
controller.StartGame();