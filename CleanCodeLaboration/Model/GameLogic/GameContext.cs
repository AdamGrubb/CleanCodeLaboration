using CleanCodeLaboration.Model.GameDAO.Interface;
using CleanCodeLaboration.Model.GameLogic.Interface;
using CleanCodeLaboration.Model.GameLogic.Strategy;
using CleanCodeLaboration.Model.GameLogic.Strategy.Interface;

namespace CleanCodeLaboration.Model.GameLogic
{
    public class GameContext : IGameContext
    {
        private IGameStrategy gameStrategy;
        private IGameDAO gameDAO;
        private string playerName;
        public GameContext(IGameDAO gameDAO)
        {
            this.gameDAO = gameDAO;
        }
        public string GetPlayerNameQuestion()
        {
            return "Enter your user name\n";
        }
        public void SetPlayerName(string playerName)
        {
            this.playerName = playerName;
        }
        public void SetGameStrategy(IGameStrategy gameStrategy) //Kanske ha en menyklass som stoppar in en strategy i GameContext? Typ en intern klass inom controllern som spottar ut menyval efter en loop och sen tar fram rätt strategy till GameContext.
        {
            this.gameStrategy = gameStrategy;
            ConfigureGameStrategy();
            StartGameStrategy();
            SetPlayerNameForStrategy();
            GenerateAndSetGoalForStrategy();
        }

        private void ConfigureGameStrategy()
        {
            gameStrategy.SetGameDAO(gameDAO);
        }

        private void StartGameStrategy()
        {
            gameStrategy.StartGame();
        }

        private void SetPlayerNameForStrategy()
        {
            gameStrategy.SetPlayerName(playerName);
        }

        private void GenerateAndSetGoalForStrategy()
        {
            string goal = gameStrategy.GenerateRandomGoal();
            gameStrategy.SetGoal(goal);
        }
        public string GetGameIntroduction()
        {
            return gameStrategy.GetGameIntroduction() + gameStrategy.GetPracticeRun();
        }
        public string EvaluateGuess(string guess) //Denna ska kalla på incrementGuess, EvaluateGuess och sen ta värdet och lägga in det i en metod som avgör om spelet är klart eller inte? Slutligen returnera 
        {
            /*gameStrategy.IncrementGuess();
             * string response = gameStrategy.EvaluateGuess(guess)
             * gameStrategy.CheckIfWon() eller nått som kollar ifall spelet är uppnått.
             * return response;
             */
            return gameStrategy.EvaluateGuess(guess);
        }
        public bool IsGameActive()
        {
            return gameStrategy.GetGameStatus();
        }
        public string GetHighScore()
        {
            return gameStrategy.GetHighScore();
        }
        public string GetFinishedGameMessage()
        {
           return gameStrategy.GetFinishedGameMessage();
        }
        public bool KeepPlaying(string answer)
        {
            if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
            {
                return false;
            }
            return true;
        }
        public string GetPlayAgainMessage()
        {
            return "Continue?";
        }
    }
}
