using CleanCodeLaboration.Model.GameLogic.Interface;
using CleanCodeLaboration.Model.GameLogic.Strategy.Interface;
using CleanCodeLaboration.Model.GameMenu;
using CleanCodeLaboration.Model.GameMenu.Interface;
using CleanCodeLaboration.View.Interface;

namespace CleanCodeLaboration.Controller
{
    public class GameController
    {
        private readonly IGameContext gameContext;
        private readonly IIO iO;
        private IGameMenu gameMenu;

        public GameController(IGameContext gameContext, IIO iO, IGameMenu gameMenu)
        {
            this.gameContext = gameContext;
            this.iO = iO;
            this.gameMenu = gameMenu;
        }

        public void InitializeGame() //Lite osäker på namnet?
        {
            AskForPlayerName();
            SetUserName();
            StartGameLoop();
        }


        private void AskForPlayerName()
        {
            string playerNameQuestion = gameContext.GetPlayerNameQuestion();
            iO.GameOutput(playerNameQuestion);
        }
        private void SetUserName()
        {

            string playerName = iO.GetUserInput();
            gameContext.SetPlayerName(playerName);
        }

        private void StartGameLoop() //Egentligen borde GetGameLoop kanske heta StartGameLoop.
        {
            do 
            {
                InitializeGameMenu(); //Dnna borde ha ett namn som betyder att den både ger output och förväntar sig input. Namn som typ StartGameMenu?
                GetGameLoop(); //Denna borde inte också heta gameLoop? Den här innehåller ju det spelet man valt.
                GetAskIfContinuePlaying();
            } while (ShouldContinuePlaying());
        }

        private void InitializeGameMenu() //Denna behöver ett namnbyte.
        {
            OutputMenu();
            ChooseGame();
        }
        private void OutputMenu()
        {
            List<string> showGameMenu = gameMenu.GetMenu();
            showGameMenu.ForEach(alternative =>
            {
                iO.GameOutput(alternative);
            });
        }
        private void ChooseGame()
        {
            IGameStrategy selectedGame;
            do
            {
                selectedGame = GetSelectedGame(); //Är det risky buisniess att ge tillbaka null från menyn?


            } while (selectedGame == null); 
            SetGameStrategy(selectedGame);
        }
        private IGameStrategy? GetSelectedGame() //Hur är det att skicka null hit och dit?
        {
            string answer = iO.GetUserInput();
            return gameMenu.SelectGame(answer);
        }
        private void SetGameStrategy(IGameStrategy gameStrategy)
        {
            gameContext.SetGameStrategy(gameStrategy);
        }


        private void GetGameLoop()
        {
            StartNewGame();

            GameIntroduction(); //OutputGameIntroduktion?

            GetCorrectAnswer(); //ShowCorrectAnswer? OutPutCorrectAnswer?

            GetUserGuesses(); //Här ska det framgå mer att det är nån slags guess-loop?

            GetHighScore();

            GetFinishedGameMessage();
            
        }
        private void StartNewGame() //Start Game?
        {
            gameContext.StartNewGame();
        }
        private void GameIntroduction()
        {
            string gameIntroduction = gameContext.GetGameIntroduction();

            iO.GameOutput(gameIntroduction);
        }
        private void GetCorrectAnswer()
        {
            string rightAnswer = gameContext.GetRightAnswer();
            iO.GameOutput(rightAnswer);
        }
        private void GetUserGuesses()
        {
            while (gameContext.IsGameActive())
            {
                string userGuess = iO.GetUserInput();
                string gameUpdateMessage = gameContext.CheckPlayerAnswer(userGuess);
                iO.GameOutput(gameUpdateMessage);
            }
        }
        private void GetHighScore()
        {
            string highScore = gameContext.GetHighScore();
            iO.GameOutput(highScore);
        }
        private void GetFinishedGameMessage()
        {
            string finishedGameMessage = gameContext.GetFinishedGameMessage();
            iO.GameOutput(finishedGameMessage);
        }

        private bool ShouldContinuePlaying() //Hur blir det här, den borde ju lägga nära metoden som använder den, men om den har metoder som använder den hur gör man då?
        {
            string answer = iO.GetUserInput();
            return gameContext.KeepPlaying(answer);
        }
        private void GetAskIfContinuePlaying()
        {
            string askIfKeepPlaying = gameContext.GetPlayAgainMessage();
            iO.GameOutput(askIfKeepPlaying);
        }
    }
}
