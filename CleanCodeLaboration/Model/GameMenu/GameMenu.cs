using CleanCodeLaboration.Model.GameLogic.Strategy;
using CleanCodeLaboration.Model.GameLogic.Strategy.Interface;
using CleanCodeLaboration.Model.GameLogic.Strategy.MooGameStrategy;
using CleanCodeLaboration.Model.GameLogic.Strategy.QuizGameStrategy;
using CleanCodeLaboration.Model.GameMenu.Commands;
using CleanCodeLaboration.Model.GameMenu.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLaboration.Model.GameMenu
{
    public class GameMenu : IGameMenu
    {
        private IGameStrategy strategy;
        private bool validSelection;
        private int commandIndex;
        ICommand[] commands = new ICommand[]
        {
            new Game ("Moogame", new MooGameStrategy()),
            new Game ("QuizGame", new QuizGameStrategy())
        };

        public List<string> GetMenu()
        {
            var commandDescriptions = commands.Select(command => command.Description).ToList();
            return commandDescriptions;
        }
        public bool IsValidSelection()
        {
            return validSelection;
        }
        public void SelectGame(string userAnswer)
        {
            if (isValidChoice(userAnswer)) 
            {
                strategy = commands[commandIndex - 1].Execute();
            }
        }
        private bool isValidChoice(string userAnswer)
        {
            validSelection = !int.TryParse(userAnswer, out commandIndex) || commandIndex > commands.Length ? false : true;
            return validSelection;
        }
        public IGameStrategy GetGameStrategy()
        {
            return strategy;
        }
    }
}
