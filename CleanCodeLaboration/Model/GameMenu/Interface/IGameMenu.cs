using CleanCodeLaboration.Model.GameLogic.Strategy.Interface;

namespace CleanCodeLaboration.Model.GameMenu.Interface
{
    public interface IGameMenu
    {
        IGameStrategy GetGameStrategy();
        string GetMenu();
        void SelectedGame(string userAnswer);
        bool IsValidSelection();
    }
}