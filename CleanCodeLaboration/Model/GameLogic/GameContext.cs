using CleanCodeLaboration.Model.GameDAO.Interface;
using CleanCodeLaboration.Model.GameLogic.Interface;
using CleanCodeLaboration.Model.GameLogic.Strategy;
using CleanCodeLaboration.Model.GameLogic.Strategy.Interface;

namespace CleanCodeLaboration.Model.GameLogic
{
    public class GameContext : IGameContext //Vad är GameContext? Du borde döpa om den här och fundera ut vad den har för ansvar. Läs på om strategy.
    {
        private IGameStrategy gameStrategy;
        private IGameDAO gameDAO;
        private string playerName;
        
        public GameContext(IGameDAO gameDAO) //Om man inte gör SetPlayerName så kommer den göra null istället? 
        {
            this.gameDAO = gameDAO;
            playerName = string.Empty; //Är detta en bättre lösning?
        }
        public string GetPlayerNameQuestion() //Ska man göra en const här?
        {
            const string nameQuestion = "Enter your user name";
            return nameQuestion;
        }
        public void SetPlayerName(string playerName)
        {
            this.playerName = playerName;
        }
        public void SetGameStrategy(IGameStrategy gameStrategy) //Frågan är ju här ifall det är för många metoder för en SetGameStrategy? Bryt ut en funktion som är StartGame?
        {
            this.gameStrategy = gameStrategy;
        }
        public void StartNewGame()
        {
            SetGameDAO();
            SetPlayerName();
            SetGameGoal();
            ActivateGame();
        }
        private void SetGameDAO()
        {
            gameStrategy.SetGameDAO(gameDAO);
        }
        private void SetPlayerName()
        {
            gameStrategy.SetPlayerName(playerName);
        }
        private void SetGameGoal()
        {
            string goal = gameStrategy.GenerateRandomGoal();
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
        public string EvaluateGuess(string guess) //Är det tokigt att IncrementGuess ligger här? Bryta ut till fler metoder kanske?
        {
            string evaluatedGuess = gameStrategy.GetEvaluatedGuess(guess);
            UpdateGame(evaluatedGuess);
            return evaluatedGuess;
        }
        private void UpdateGame(string evaluatedGuess)
        {
            gameStrategy.IncrementGuess();
            bool correctGuess = gameStrategy.IsCorrectGuess(evaluatedGuess);
            if (correctGuess)
            {
                gameStrategy.SaveGame();
                gameStrategy.DeactivateGame();
            }
        }
        public bool IsGameActive()
        {
            return gameStrategy.IsGameActive();
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
            const string endGame = "n"; //Låter endGame Bra?
            if (!string.IsNullOrWhiteSpace(answer) && answer.Substring(0, 1) == endGame)
            {
                return false;
            }
            return true;
        }
        public string GetPlayAgainMessage()
        {
            const string playAgainMessage = "Continue?"; //Är det redundant information med message?
            return playAgainMessage;
        }
    }
}
