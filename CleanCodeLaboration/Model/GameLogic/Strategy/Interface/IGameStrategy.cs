using CleanCodeLaboration.Model.GameDAO.Interface;

namespace CleanCodeLaboration.Model.GameLogic.Strategy.Interface
{
    public interface IGameStrategy
    {
        string GetEvaluatedGuess(string guess);
        string GenerateGoal();
        string GetFinishedGameMessage();
        string GetGameIntroduction();
        bool IsGameActive();
        void SetGoal(string goal);
        List<IPlayerScore> GetPlayerScores();
        void ActivateGame();
        void SaveGame(string playerName);
        void IncrementGuessCount();
        bool IsCorrectGuess(string guess);
        void DeactivateGame();
        string GetRightAnswer();
    }
}