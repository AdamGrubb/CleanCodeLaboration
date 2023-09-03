using CleanCodeLaboration.Model.GameLogic.Strategy.Interface;

namespace CleanCodeLaboration.Controller.GameLoop.Interface
{
    public interface IGameLoop
    {
        void SetGameStrategy(IGameStrategy gameStrategy);
        void RunGameLoop(); //Sätt ett bättre namn på den! StartGameLoop?
    }
}