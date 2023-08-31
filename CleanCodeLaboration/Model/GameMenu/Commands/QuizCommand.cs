using CleanCodeLaboration.Model.GameLogic.Strategy.Interface;
using CleanCodeLaboration.Model.GameLogic.Strategy.MooGameStrategy;
using CleanCodeLaboration.Model.GameLogic.Strategy.QuizGameStrategy;
using CleanCodeLaboration.Model.GameMenu.Interface;

namespace CleanCodeLaboration.Model.GameMenu.Commands
{
    public class QuizCommand : ICommand
    {
        private const string description = "Quiz Game";
        public string Description
        {
            get { return description; }
        }

        public IGameStrategy Execute()
        {
            return new QuizGameStrategy();
        }
    }
}
