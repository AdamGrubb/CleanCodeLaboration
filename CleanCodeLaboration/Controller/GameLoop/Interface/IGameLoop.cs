using CleanCodeLaboration.Model.GameLogic.Strategy.Interface;

namespace CleanCodeLaboration.Controller.GameLoop.Interface
{
    public interface IGameLoop
    {
        void SetGameStrategy(IGameStrategy gameStrategy);
        void RunGameLoop();
        void PromptUserForName();
    }
}