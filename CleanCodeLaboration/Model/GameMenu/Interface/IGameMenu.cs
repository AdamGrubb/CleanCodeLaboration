using CleanCodeLaboration.Model.GameLogic.Strategy.Interface;

namespace CleanCodeLaboration.Model.GameMenu.Interface
{
    public interface IGameMenu
    {
        List<string> GetMenu();
        IGameStrategy? SelectGame(string userAnswer);
    }
}