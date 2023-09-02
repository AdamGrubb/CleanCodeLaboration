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
        public string GetPlayerNameQuestion() //Ska man göra en const här?
        {
            const string nameQuestion = "Enter your user name";
            return nameQuestion;
        }
        public void SetPlayerName(string playerName)
        {
            gameStrategy.SetPlayerName(playerName);
        }
        public void SetGameStrategy(IGameStrategy gameStrategy) //Frågan är ju här ifall det är för många metoder för en SetGameStrategy? Bryt ut en funktion som är StartGame?
        {
            this.gameStrategy = gameStrategy;
        }
        public void StartNewGame()
        {
            SetGameDAO(); //AssignGameDao?
            SetGameGoal();
            ActivateGame();
        }
        private void SetGameDAO()
        {
            gameStrategy.SetGameDAO(gameDAO);
        }
 
        private void SetGameGoal()
        {
            string goal = gameStrategy.GenerateGoal();
            gameStrategy.SetGoal(goal);
        }
        private void ActivateGame()
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
        public string CheckPlayerAnswer(string guess) //Frågan är ifall man skulle bryta ut loopen ändå?
        {
            IncrementGuessCount();
            string evaluatedGuess = EvaluateGuess(guess);
            if (IsCorrectGuess(evaluatedGuess))
            {
                SaveGame();
                EndGame();
            }
            return evaluatedGuess;
        }
        private string EvaluateGuess(string guess)
        {
            return gameStrategy.GetEvaluatedGuess(guess); //Borde GameContext heta GetEvaluatedGuess och gameStrategy heta EvaluateGuess?
        }
        private void IncrementGuessCount()
        {
            gameStrategy.IncrementGuessCount(); //IncrementGuessCount?
        }
        private bool IsCorrectGuess(string guess)
        {
            return gameStrategy.IsCorrectGuess(guess);
        }
        private void SaveGame()
        {
            gameStrategy.SaveGame();
        }
        private void EndGame()
        {
            gameStrategy.DeactivateGame();
        }
        public bool IsGameActive()
        {
            return gameStrategy.IsGameActive();
        }
        public string GetHighScore()
        {
            List<IPlayerScore> playerScores = gameStrategy.GetPlayerScores();
            string highScore = highScoreFormatter.FormatHighScores(playerScores);
            return highScore;
        }

        public List<IPlayerScore> GetPlayerScores()
        {
            return gameStrategy.GetPlayerScores();
        }
        public string GetFinishedGameMessage()
        {
            return gameStrategy.GetFinishedGameMessage();
        }
    }
}
