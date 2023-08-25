using CleanCodeLaboration.Model.GameLogic.Strategy;
using CleanCodeLaboration.Model.GameLogic.Strategy.Interface;
using CleanCodeLaboration.Model.GameLogic.Strategy.MooGameStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLaboration.Model
{
    public class GameMenu : IGameMenu
    {
        IGameStrategy strategy;
        bool validSelection;
        public string GetMenu()
        {
            string games = "1. MooGame\n";
            return games;
        }
        public bool IsValidSelection()
        {
            return validSelection;
        }
        public void SelectedGame(string userAnswer) //Gör om det här till en factory? Vad avgör då Valet?
        {
            validSelection = true;
            switch (userAnswer)
            {
                case "1":
                    {
                        strategy = new MooGameStrategy();
                        break;
                    }
                default:
                    {
                        validSelection = false;
                        break;
                    }
            }
        }
        public IGameStrategy GetGameStrategy()
        {
            return strategy;
        }
    }
}
