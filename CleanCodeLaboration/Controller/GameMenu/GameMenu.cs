using CleanCodeLaboration.Controller.GameMenu.Interface;
using CleanCodeLaboration.Model.GameLogic.Strategy.Interface;
using CleanCodeLaboration.View.Interface;

namespace CleanCodeLaboration.Controller.GameMenu
{
    public class GameMenu : IGameMenu
    {
        private readonly IGameMenuSelection[] menuSelections;
        private readonly IIO iO;


        public GameMenu(IGameMenuSelection[] menuSelections, IIO iO)
        {
            this.menuSelections = menuSelections;
            this.iO = iO;
        }
        public void OutputMenu()
        {
            List<string> names = GetGameNames();
            OutputGameNames(names);
        }
        private List<string> GetGameNames()
        {
            var gameNames = menuSelections
                .Select((command, index) => $"{index + 1}. {command.Description}") //Fixa commandgrejen, det ska väl vara selection 
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
        public void SelectMenu() //Här så väljer man vilket val i listan.
        {
            int choice = PromtUserChoice();
            GetGameStrategy(choice);
        }
        private int PromtUserChoice()
        {
            bool validInput;
            int choice;
            string userSelection; //User selection och userCHoice vaddåå!???!?!?
            do
            {
                userSelection = GetUserInput();
                validInput = int.TryParse(userSelection, out choice) && choice <= menuSelections.Length && choice > 0;
            } while (!validInput);

            return choice;
        }
        private string GetUserInput()
        {
            return iO.GetUserInput();
        }

        private void GetGameStrategy(int userChoice) //Denna gör valet i listan. Här ska man låta command köra sin  metod.
        {
            int indexCorrection = 1;
            menuSelections[userChoice - indexCorrection].MenuCommand.Execute();
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
