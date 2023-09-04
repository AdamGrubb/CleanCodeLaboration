using CleanCodeLaboration.Controller.GameMenu.Interface;
using CleanCodeLaboration.Model.GameDAO.Interface;
using CleanCodeLaboration.Model.GameLogic.Strategy.Interface;
using CleanCodeLaboration.Model.GameLogic.Strategy.MooGameStrategy;
using CleanCodeLaboration.Model.GameLogic.Strategy.QuizGameStrategy;
using CleanCodeLaboration.Model.GameLogic.Strategy.QuizGameStrategy.QuizQuestionDAO.Interface;

namespace CleanCodeLaboration.Controller.GameMenu.Commands
{
    public class QuizCommand : ICommand
    {
        private const string description = "Quiz Game";
        private readonly IGameDAO gameDAO;
        private readonly IQuizQuestionDAO quizQuestionDAO;

        public QuizCommand(IGameDAO gameDAO, IQuizQuestionDAO quizQuestionDAO)
        {
            this.gameDAO = gameDAO;
            this.quizQuestionDAO = quizQuestionDAO;
        }
        public string Description
        {
            get { return description; }
        }

        public IGameStrategy Execute()
        {
            return new QuizGameStrategy(gameDAO, quizQuestionDAO);
        }
    }
}
