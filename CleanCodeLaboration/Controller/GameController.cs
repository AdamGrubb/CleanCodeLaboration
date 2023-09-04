using CleanCodeLaboration.Controller.GameLoop.Interface;
using CleanCodeLaboration.Controller.GameMenu.Interface;
using CleanCodeLaboration.Model.GameLogic.Strategy.Interface;

namespace CleanCodeLaboration.Controller
{
    public class GameController
    {
        private readonly IGameLoop gameLoop;
        private IGameMenu gameMenu;

        public GameController(IGameLoop gameLoop, IGameMenu gameMenu)
        {
            this.gameLoop = gameLoop;
            this.gameMenu = gameMenu;
        }

        public void StartGame() //Lite osäker på namnet?
        {
            InitializeGameMenu();
        }

        private void InitializeGameMenu() //Denna behöver ett namnbyte.
        {
            InputPlayerName();
            do
            {
                OutputMenu();
                ChooseGame();
                StartGameLoop();
            } while (KeepPlaying());


        }
        private void InputPlayerName()
        {
            gameLoop.InputPlayerName();
        }
        private void OutputMenu()
        {
            gameMenu.OutputMenu();
        }
        private void ChooseGame()
        {
            IGameStrategy gameStrategy = gameMenu.SelectGame();
            SetGameStrategy(gameStrategy);
        }
        private void SetGameStrategy(IGameStrategy gameStrategy)
        {
            gameLoop.SetGameStrategy(gameStrategy);
        }
        private void StartGameLoop()
        {
            gameLoop.RunGameLoop();
        }
        private bool KeepPlaying()
        {
           return gameMenu.ContinuePlaying();
        }
    }
}
