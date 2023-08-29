using CleanCodeLaboration.Model.GameDAO.Interface;
using CleanCodeLaboration.Model.GameLogic.Interface;
using CleanCodeLaboration.Model.GameLogic.Strategy.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLaboration.Model.GameLogic
{
    public class GameStrategyBuilder : IGameStrategyBuilder
    {
        private IGameStrategy gameStrategy;

        public GameStrategyBuilder(IGameStrategy gameStrategy)
        {
            this.gameStrategy = gameStrategy;
        }

        public IGameStrategy Build()
        {
            return gameStrategy;
        }

        public IGameStrategyBuilder ConfigureGameDAO(IGameDAO gameDAO)
        {
            gameStrategy.SetGameDAO(gameDAO);
            return this;
        }

        public IGameStrategyBuilder ActivateGame()
        {
            gameStrategy.ActivateGame();
            return this;
        }

        public IGameStrategyBuilder SetPlayerName(string playerName)
        {
            gameStrategy.SetPlayerName(playerName);
            return this;
        }

        public IGameStrategyBuilder SetGoal()
        {
            string goal = gameStrategy.GenerateRandomGoal();
            gameStrategy.SetGoal(goal);
            return this;
        }
    }
}
