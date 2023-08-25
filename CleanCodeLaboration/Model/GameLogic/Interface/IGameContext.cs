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
        bool GetGameStatus();
        void SetGameStrategy(IGameStrategy gameStrategy);
        void SetPlayerName(string playerName);
        bool KeepPlaying(string answer);
        string GetPlayAgainMessage();
    }
}