using CleanCodeLaboration.Model.GameLogic.Strategy.Interface;

namespace CleanCodeLaboration.Model.GameMenu.Interface
{
    public interface IGameMenu
    {
        IGameStrategy GetGameStrategy();
        List<string> GetMenu();
        void SelectGame(string userAnswer);
        bool IsValidSelection();
    }
}