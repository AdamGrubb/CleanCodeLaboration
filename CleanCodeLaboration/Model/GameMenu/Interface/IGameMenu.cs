using CleanCodeLaboration.Model.GameLogic.Strategy.Interface;

namespace CleanCodeLaboration.Model.GameMenu.Interface
{
    public interface IGameMenu
    {
        void DisplayMenu();
        IGameStrategy SelectGame();
    }
}