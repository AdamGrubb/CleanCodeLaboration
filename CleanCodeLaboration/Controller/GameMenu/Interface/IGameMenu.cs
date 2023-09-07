using CleanCodeLaboration.Model.GameLogic.Strategy.Interface;

namespace CleanCodeLaboration.Controller.GameMenu.Interface
{
    public interface IGameMenu
    {
        void OutputMenu();
        void SelectMenu();
        bool ContinuePlaying();
    }
}