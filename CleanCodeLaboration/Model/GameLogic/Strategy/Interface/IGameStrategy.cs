namespace CleanCodeLaboration.Model.GameLogic.Strategy.Interface
{
    public interface IGameStrategy
    {
        string EvaluateGuess(string guess);
        string GenerateRandomGoal();
        string GetFinishedGameMessage();
        string GetGameIntroduction();
        bool GetGameStatus();
        string GetGoal();
        void SetGoal(string goal);
        string GetHighScore();
        string GetPlayAgainMessage();
        string GetPracticeRun();
        void PlayAgain(string answer);
        void SaveGame();
        void SetPlayerName(string userName);
        void StartGame();
    }
}