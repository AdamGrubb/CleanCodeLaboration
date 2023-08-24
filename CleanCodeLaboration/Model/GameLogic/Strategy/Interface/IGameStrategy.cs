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
        bool GetGameStatus();
        string GetGoal();
        void SetGoal(string goal);
        string GetHighScore();
        string GetPracticeRun();
        void SetPlayerName(string userName);
        void StartGame();
    }
}