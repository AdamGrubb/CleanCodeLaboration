using CleanCodeLaboration.Model.GameLogic.Strategy.Interface;

namespace CleanCodeLaboration.Model.GameLoop.Interface
{
    public interface IGameLoop
    {
        void SetGameStrategy(IGameStrategy gameStrategy);
        void GetGameLoop();
    }
}