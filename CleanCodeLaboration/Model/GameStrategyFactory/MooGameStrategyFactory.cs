using CleanCodeLaboration.Model.GameDAO.Interface;
using CleanCodeLaboration.Model.GameLogic.Strategy.Interface;
using CleanCodeLaboration.Model.GameLogic.Strategy.MooGameStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLaboration.Model.GameStrategyFactory
{
    public class MooGameStrategyFactory : AbstractGameStrategyFactory
    {
        private readonly IGameDAO gameDAO;
        public MooGameStrategyFactory(IGameDAO gameDAO)
        {
            this.gameDAO = gameDAO;
        }
        protected override IGameStrategy GetStrategy()
        {
            return new MooGameStrategy(gameDAO);
        }
    }
}
