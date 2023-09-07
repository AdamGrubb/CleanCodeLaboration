using CleanCodeLaboration.Model.GameLogic.Strategy.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLaboration.Model.GameStrategyFactory
{
    public abstract class AbstractGameStrategyFactory
    {

        protected abstract IGameStrategy GetStrategy();
        public IGameStrategy CreateStrategy()
        {
            return GetStrategy();
        }
    }
}
