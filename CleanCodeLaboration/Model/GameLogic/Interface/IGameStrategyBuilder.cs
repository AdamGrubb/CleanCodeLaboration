using CleanCodeLaboration.Model.GameDAO.Interface;
using CleanCodeLaboration.Model.GameLogic.Strategy.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLaboration.Model.GameLogic.Interface
{
    public interface IGameStrategyBuilder
    {
        IGameStrategy Build();
        IGameStrategyBuilder ConfigureGameDAO(IGameDAO gameDAO);
        IGameStrategyBuilder StartGame();
        IGameStrategyBuilder SetPlayerName(string playerName);
        IGameStrategyBuilder SetGoal();
    }
}
