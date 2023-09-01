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
    public class GameMenu : IGameMenu //Nu jobbar den ju med samma Games här i command-listan. 
    {
        private int commandIndex;
        ICommand[] commands = new ICommand[]
        {
            new MooGameCommand(),
            new QuizCommand()
        };

        public List<string> GetMenu()
        {
            var commandDescriptions = commands.Select(command => command.Description).ToList();
            return commandDescriptions;
        }
        public IGameStrategy? SelectGame(string userAnswer) //Ska jag göra denna till validSelectionOfGame? och sen bryta ut strategy = command-grejen till en privat metod?
        {
            bool validChoice = isValidChoice(userAnswer);


            if (validChoice)
            {
                return GetGameStrategy();
            }
            return null;
        }
        private bool isValidChoice(string userAnswer)
        {
            return int.TryParse(userAnswer, out commandIndex) && commandIndex <= commands.Length && commandIndex > 0;

        }
        private IGameStrategy GetGameStrategy()
        {
            return commands[commandIndex - 1].Execute();
        }
    }
}
