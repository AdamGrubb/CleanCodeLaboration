using CleanCodeLaboration.Model.GameLogic.Strategy.Interface;

namespace CleanCodeLaboration.Model.GameLogic.Interface
{
    public interface IGameContext
    {
        string EvaluateGuess(string guess);
        string GetFinishedGameMessage();
        string GetGameIntroduction();
        string GetHighScore();
        string GetPlayerNameQuestion();
        bool IsGameActive();
        void PlayAgain(string answer);
        void SaveGame();
        void SetGameStrategy(IGameStrategy gameStrategy);
        void SetPlayerName(string playerName);
    }
}