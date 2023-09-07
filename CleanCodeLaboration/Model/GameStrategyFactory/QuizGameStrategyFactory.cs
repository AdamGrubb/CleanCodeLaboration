using CleanCodeLaboration.Model.GameDAO.Interface;
using CleanCodeLaboration.Model.GameLogic.Strategy.Interface;
using CleanCodeLaboration.Model.GameLogic.Strategy.MooGameStrategy;
using CleanCodeLaboration.Model.GameLogic.Strategy.QuizGameStrategy;
using CleanCodeLaboration.Model.GameLogic.Strategy.QuizGameStrategy.QuizQuestionDAO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLaboration.Model.GameStrategyFactory
{
    public class QuizGameStrategyFactory : AbstractGameStrategyFactory
    {
        private readonly IGameDAO gameDAO;
        private readonly IQuizQuestionDAO quizQuestionDAO;

        public QuizGameStrategyFactory(IGameDAO gameDAO, IQuizQuestionDAO quizQuestionDAO)
        {
            this.gameDAO = gameDAO;
            this.quizQuestionDAO = quizQuestionDAO;
        }
        protected override IGameStrategy GetStrategy()
        {
            return new QuizGameStrategy(gameDAO, quizQuestionDAO);
        }
    }
}
