using CleanCodeLaboration.Controller.GameLoop.Interface;
using CleanCodeLaboration.Controller.GameMenu.Interface;
using CleanCodeLaboration.Model.GameLogic.Strategy.Interface;
using CleanCodeLaboration.Model.GameStrategyFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLaboration.Controller.GameMenu.Commands
{
    public class GameSelectionCommand : IMenuCommand
    {
        private readonly AbstractGameStrategyFactory gameFactory;
        private readonly IGameLoop gameLoop;

        public GameSelectionCommand(AbstractGameStrategyFactory gameFactory, IGameLoop gameLoop)
        {
            this.gameFactory = gameFactory;
            this.gameLoop = gameLoop;
        }
        public void Execute()
        {
            SetStrategy();
            RunGameLoop();
        }
        private void SetStrategy()
        {
            IGameStrategy gameStrategy = gameFactory.CreateStrategy();
            gameLoop.SetGameStrategy(gameStrategy);
        }
        private void RunGameLoop()
        {
            gameLoop.RunGameLoop();
        }
    }
}
