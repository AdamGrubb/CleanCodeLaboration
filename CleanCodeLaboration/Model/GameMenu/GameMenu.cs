using CleanCodeLaboration.Model.GameLogic.Strategy;
using CleanCodeLaboration.Model.GameLogic.Strategy.Interface;
using CleanCodeLaboration.Model.GameLogic.Strategy.MooGameStrategy;
using CleanCodeLaboration.Model.GameLogic.Strategy.QuizGameStrategy;
using CleanCodeLaboration.Model.GameMenu.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLaboration.Model.GameMenu
{
    public class GameMenu : IGameMenu
    {
        IGameStrategy strategy;
        bool validSelection;
        public string GetMenu()
        {
            string games = "1. MooGame\n2. QuizGame\n";
            return games;
        }
        public bool IsValidSelection()
        {
            return validSelection;
        }
        public void SelectGame(string userAnswer)
        {
            validSelection = true;
            switch (userAnswer)
            {
                case "1":
                    {
                        strategy = new MooGameStrategy();
                        break;
                    }
                case "2":
                    {
                        strategy = new QuizGameStrategy ();
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
