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
            return "Enter your user name";
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
            SetStrategyGoal();
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

        private void SetStrategyGoal()
        {
            string goal = gameStrategy.GenerateRandomGoal();
            gameStrategy.SetGoal(goal);
        }
        public string GetGameIntroduction()
        {
            return gameStrategy.GetGameIntroduction(); //Här kan man lägga in practiceRun.
        }
        public string GetRightAnswer()
        {
            return gameStrategy.GetRightAnswer();
        }
        public string EvaluateGuess(string guess)
        {
            gameStrategy.IncrementGuess();
            string evaluatedGuess = gameStrategy.EvaluateGuess(guess);
            bool correctGuess = gameStrategy.IsCorrectGuess(evaluatedGuess);
            if (correctGuess)
            {
                gameStrategy.SaveGame();
                gameStrategy.EndGame();
            }
            return evaluatedGuess;
        }
        public bool GetGameStatus()
        {
            return gameStrategy.GetGameStatus();
        }
        public string GetHighScore() //Här får du också bryta ut alla funktioner och använda dem en efter en som du gjort i evaluateGuess.
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
