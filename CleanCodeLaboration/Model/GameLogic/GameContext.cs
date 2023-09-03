using CleanCodeLaboration.Model.GameDAO.Interface;
using CleanCodeLaboration.Model.GameHighScore;
using CleanCodeLaboration.Model.GameHighScore.Interface;
using CleanCodeLaboration.Model.GameLogic.Interface;
using CleanCodeLaboration.Model.GameLogic.Strategy;
using CleanCodeLaboration.Model.GameLogic.Strategy.Interface;

namespace CleanCodeLaboration.Model.GameLogic
{
    public class GameContext : IGameContext //Vad är GameContext? Du borde döpa om den här och fundera ut vad den har för ansvar. Läs på om strategy.
    {
        private IGameStrategy gameStrategy;
        private readonly IGameDAO gameDAO;
        private readonly IHighScoreFormatter highScoreFormatter;
        
        public GameContext(IGameDAO gameDAO, IHighScoreFormatter higScoreFormatter) 
        {
            this.gameDAO = gameDAO;
            this.highScoreFormatter = higScoreFormatter;
        }
        public string GetPlayerNameQuestion()
        {
            const string nameQuestion = "Enter your user name";
            return nameQuestion;
        }
        public void SetPlayerName(string playerName)
        {
            gameStrategy.SetPlayerName(playerName);
        }
        public void SetGameStrategy(IGameStrategy gameStrategy)
        {
            this.gameStrategy = gameStrategy;
        }
        public void StartNewGame()
        {
            SetGameStrategyDAO();
            SetGoalForGame();
            StartGame();
        }
        private void SetGameStrategyDAO()
        {
            gameStrategy.SetGameDAO(gameDAO);
        }
 
        private void SetGoalForGame()
        {
            string goal = gameStrategy.GenerateGoal();
            gameStrategy.SetGoal(goal);
        }
        private void StartGame()
        {
            gameStrategy.ActivateGame();
        }
        public string GetGameIntroduction()
        {
            return gameStrategy.GetGameIntroduction();
        }
        public string GetRightAnswer()
        {
            return gameStrategy.GetRightAnswer();
        }
        public string CheckPlayerAnswer(string guess)
        {
            IncrementGuessCount();
            string evaluatedGuess = GetEvaluateGuess(guess);
            if (IsCorrectGuess(evaluatedGuess))
            {
                SaveGame();
                StopGame();
            }
            return evaluatedGuess;
        }
        private string GetEvaluateGuess(string guess)
        {
            return gameStrategy.GetEvaluatedGuess(guess);
        }
        private void IncrementGuessCount()
        {
            gameStrategy.IncrementGuessCount();
        }
        private bool IsCorrectGuess(string guess)
        {
            return gameStrategy.IsCorrectGuess(guess);
        }
        private void SaveGame()
        {
            gameStrategy.SaveGame();
        }
        private void StopGame()
        {
            gameStrategy.DeactivateGame();
        }
        public bool IsGameActive()
        {
            return gameStrategy.IsGameActive();
        }
        public string GetHighScore()
        {
            List<IPlayerScore> playerScores = GetPlayerScores();
            string highScore = GetFormattedHighScore(playerScores);
            return highScore;
        }

        private List<IPlayerScore> GetPlayerScores()
        {
            return gameStrategy.GetPlayerScores();
        }
        private string GetFormattedHighScore(List<IPlayerScore> playerScores)
        {
            return highScoreFormatter.FormatHighScores(playerScores);
        }
        public string GetFinishedGameMessage()
        {
            return gameStrategy.GetFinishedGameMessage();
        }
    }
}
