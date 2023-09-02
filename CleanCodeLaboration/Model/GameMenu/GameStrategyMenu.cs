using CleanCodeLaboration.Model.GameLogic.Strategy;
using CleanCodeLaboration.Model.GameLogic.Strategy.Interface;
using CleanCodeLaboration.Model.GameLogic.Strategy.MooGameStrategy;
using CleanCodeLaboration.Model.GameLogic.Strategy.QuizGameStrategy;
using CleanCodeLaboration.Model.GameMenu.Commands;
using CleanCodeLaboration.Model.GameMenu.Interface;
using CleanCodeLaboration.View.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLaboration.Model.GameMenu
{
    public class GameStrategyMenu : IGameMenu //Nu jobbar den ju med samma Games här i command-listan. 
    {
        private readonly IIO io;
        private int commandIndex;
        private ICommand[] commands;


        public GameStrategyMenu(ICommand[] commands, IIO io)
        {
            this.commands = commands;
            this.io = io;
        }
        public void DisplayMenu() //PrintMenu?
        {
            List<string> commands = GetMenu(); //MenuItems?
            commands.ForEach(command => OutputGameInfo(command));
        }
        private List<string> GetMenu()
        {
            var commandDescriptions = commands
                .Select((command, index) => $"{index + 1}. {command.Description}")
                .ToList();
            return commandDescriptions;
        }
        private void OutputGameInfo(string output) //Bättre namn på det här helt klart. OUTPUT!!?!?!
        {
            io.GameOutput(output);
        }
        public IGameStrategy SelectGame()
        {
            int choice = GetValidChoice();
            IGameStrategy gameStrategy = GetGameStrategy(choice);
            return gameStrategy;
        }
        private int GetValidChoice() //Är det bättre att ha alla på utsidan av loopen? Kolla av med clean code boken.
        {
            bool validInput;
            int choice; //Choice?
            string userSelection; //User Selection?
            do
            {
                userSelection = GetUserInput();
                validInput =int.TryParse(userSelection, out choice) && choice <= commands.Length && choice > 0;
            } while (!validInput);

            return choice;
        }
        private string GetUserInput()
        {
            return io.GetUserInput();
        }

        private IGameStrategy GetGameStrategy(int choice) //Choice!?
        {
            return commands[choice - 1].Execute();
        }
    }
}
