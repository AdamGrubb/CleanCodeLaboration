using CleanCodeLaboration.Model.GameLogic.Strategy.Interface;
using CleanCodeLaboration.Model.GameLogic.Strategy.MooGameStrategy;
using CleanCodeLaboration.Model.GameMenu.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLaboration.Model.GameMenu.Commands
{
    public class MooGameCommand : ICommand
    {
        private const string description = "MooGame";
        public string Description 
        {
            get { return description; } 
        }

        public IGameStrategy Execute()
        {
            return new MooGameStrategy();
        }
    }
}
