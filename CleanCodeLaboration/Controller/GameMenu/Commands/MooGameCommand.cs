using CleanCodeLaboration.Controller.GameMenu.Interface;
using CleanCodeLaboration.Model.GameDAO.Interface;
using CleanCodeLaboration.Model.GameLogic.Strategy.Interface;
using CleanCodeLaboration.Model.GameLogic.Strategy.MooGameStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLaboration.Controller.GameMenu.Commands
{
    public class MooGameCommand : IGameCommand
    {
        private const string description = "MooGame";
        private readonly IGameDAO gameDAO;
        public MooGameCommand(IGameDAO gameDAO)
        {
            this.gameDAO = gameDAO;
        }

        public string Description
        {
            get { return description; }
        }

        public IGameStrategy Execute()
        {
            return new MooGameStrategy(gameDAO);
        }
    }
}
