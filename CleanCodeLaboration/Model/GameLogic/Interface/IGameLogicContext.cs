using CleanCodeLaboration.Model.GameLogic.Strategy.Interface;

namespace CleanCodeLaboration.Model.GameLogic.Interface
{
    public interface IGameLogicContext
    {
        string CheckPlayerAnswer(string guess);
        string GetFinishedGameMessage();
        string GetGameIntroduction();
        string GetHighScore();
        string GetPlayerNameQuestion();
        bool IsGameActive();
        void SetGameStrategy(IGameStrategy gameStrategy);
        void StartNewGame();
        void SetPlayerName(string playerName);
        string GetRightAnswer();
    }
}