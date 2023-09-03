using CleanCodeLaboration.Controller.GameMenu.Interface;
using CleanCodeLaboration.Model.GameLogic.Strategy.Interface;
using CleanCodeLaboration.View.Interface;

namespace CleanCodeLaboration.Controller.GameMenu
{
    public class GameStrategyMenu : IGameMenu
    {
        private readonly IIO iO;
        private ICommand[] commands;


        public GameStrategyMenu(ICommand[] commands, IIO iO)
        {
            this.commands = commands;
            this.iO = iO;
        }
        public void OutputMenu()
        {
            List<string> commands = GetMenu();
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
            iO.GameOutput(output);
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
                validInput = int.TryParse(userSelection, out choice) && choice <= commands.Length && choice > 0;
            } while (!validInput);

            return choice;
        }
        private string GetUserInput()
        {
            return iO.GetUserInput();
        }

        private IGameStrategy GetGameStrategy(int choice) //Choice!?
        {
            return commands[choice - 1].Execute();
        }
        public bool ContinuePlaying()
        {
            GetPlayAgainMessage();
            return KeepPlaying();
        }
        private bool KeepPlaying()
        {
            string answer = GetUserInput();
            const string endGame = "n"; //Låter endGame Bra?
            if (!string.IsNullOrWhiteSpace(answer) && answer.Substring(0, 1) == endGame)
            {
                return false;
            }
            return true;
        }
        private void GetPlayAgainMessage()
        {
            const string playAgainMessage = "Continue?"; //Är det redundant information med message?
            iO.GameOutput(playAgainMessage);
        }
    }
}
