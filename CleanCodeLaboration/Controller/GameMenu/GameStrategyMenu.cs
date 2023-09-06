using CleanCodeLaboration.Controller.GameMenu.Interface;
using CleanCodeLaboration.Model.GameLogic.Strategy.Interface;
using CleanCodeLaboration.View.Interface;

namespace CleanCodeLaboration.Controller.GameMenu
{
    public class GameStrategyMenu : IGameMenu
    {
        private readonly IIO iO;
        private IGameCommand[] commands;


        public GameStrategyMenu(IGameCommand[] commands, IIO iO)
        {
            this.commands = commands;
            this.iO = iO;
        }
        public void OutputMenu()
        {
            List<string> names = GetGameNames();
            OutputGameNames(names);
        }
        private List<string> GetGameNames()
        {
            var gameNames = commands
                .Select((command, index) => $"{index + 1}. {command.Description}")
                .ToList();
            return gameNames;
        }
        private void OutputMessage(string output)
        {
            iO.GameOutput(output);
        }
        private void OutputGameNames(List<string> names)
        {
            names.ForEach(name => OutputMessage(name));
        }
        public IGameStrategy SelectGame()
        {
            int choice = PromtUserChoice();
            IGameStrategy gameStrategy = GetGameStrategy(choice);
            return gameStrategy;
        }
        private int PromtUserChoice()
        {
            bool validInput;
            int choice;
            string userSelection; //User selection och userCHoice vaddåå!???!?!?
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

        private IGameStrategy GetGameStrategy(int userChoice)
        {
            int indexCorrection = 1;
            return commands[userChoice - indexCorrection].Execute();
        }
        public bool ContinuePlaying()
        {
            OutputPlayAgainPrompt();

            return KeepPlaying();
        }
        private bool KeepPlaying()
        {
            string answer = GetUserInput();
            bool keepPlaying = !ShouldStopPlaying(answer);
            return keepPlaying;
        }
        private bool ShouldStopPlaying(string answer)
        {
            const string endGame = "n";
            return !string.IsNullOrWhiteSpace(answer) && answer.StartsWith(endGame);
        }
        private void OutputPlayAgainPrompt()
        {
            const string promptContinue = "Continue?";

            OutputMessage(promptContinue);
        }
    }
}
