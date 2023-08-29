using CleanCodeLaboration.Model.GameDAO.Interface;

namespace CleanCodeLaboration.Model.GameLogic.Strategy.Interface
{
    public interface IGameStrategy
    {
        void SetGameDAO(IGameDAO gameDAO);
        string EvaluateGuess(string guess);
        string GenerateRandomGoal();
        string GetFinishedGameMessage();
        string GetGameIntroduction();
        bool IsGameActive();
        void SetGoal(string goal);
        string GetHighScore();
        void SetPlayerName(string userName);
        void ActivateGame();
        void SaveGame();
        void IncrementGuess(); //Denna kanske behöver bytas namn på
        bool IsCorrectGuess(string guess);
        void DeactivateGame();
        string GetRightAnswer();
    }
}