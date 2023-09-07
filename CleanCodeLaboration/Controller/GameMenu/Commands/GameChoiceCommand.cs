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
    public class GameChoiceCommand : IGameCommand
    {
        private readonly string gameName;
        private readonly AbstractGameStrategyFactory gameFactory;

        public GameChoiceCommand(AbstractGameStrategyFactory gameFactory, string gameNem)
        {
            this.gameName = gameNem;
            this.gameFactory = gameFactory;
        }
        public string GameName
        {
            get { return gameName; }
        }

        public IGameStrategy Execute()
        {
            return gameFactory.CreateStrategy();
        }
    }
}
