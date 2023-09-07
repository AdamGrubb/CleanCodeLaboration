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
    public class MooGameCommand : IGameCommand
    {
        private readonly string gameName = "MooGame";
        private readonly AbstractGameStrategyFactory gameFactory;
        private readonly IGameLoop gameLoop;

        public MooGameCommand(AbstractGameStrategyFactory gameFactory, IGameLoop gameLoop) //Problemet hä är att du måste göra en specifik command för varje spel och hårdkoda gameName.
        {
            this.gameFactory = gameFactory;
            this.gameLoop = gameLoop;
        }


        public string Description
        {
            get { return gameName; }
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
