using CleanCodeLaboration.Model.GameLogic.Strategy.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanCodeLaboration.Model.GameMenu.Interface;

namespace CleanCodeLaboration.Model.GameMenu.Commands
{
    public class Game : ICommand
    {
        private readonly string description;
        private readonly IGameStrategy game;

        public Game(string description, IGameStrategy game)
        {
            this.description = description;
            this.game = game;
        }

        public string Description => description;

        public IGameStrategy Execute()
        {
            return game;
        }
    }
}
