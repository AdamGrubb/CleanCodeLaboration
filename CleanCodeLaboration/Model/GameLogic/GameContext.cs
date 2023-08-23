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
            this.gameStrategy = new MooGameStrategy(gameDAO);
            gameStrategy.StartGame();
            gameStrategy.SetPlayerName(playerName);
            string goal = gameStrategy.GenerateRandomGoal();
            gameStrategy.SetGoal(goal);
        }
        public string GetGameIntroduction()
        {
            return gameStrategy.GetGameIntroduction() + gameStrategy.GetPracticeRun();
        }
        public string EvaluateGuess(string guess)
        {
            return gameStrategy.EvaluateGuess(guess);
        }
        public bool IsGameActive()
        {
            return gameStrategy.GetGameStatus();
        }
        public void SaveGame()
        {
            gameStrategy.SaveGame();
        }
        public string GetHighScore()
        {
            return gameStrategy.GetHighScore();
        }
        public string GetFinishedGameMessage()
        {
            return gameStrategy.GetFinishedGameMessage();
        }
        public void PlayAgain(string answer)
        {
            gameStrategy.PlayAgain(answer);
        }
    }
}
