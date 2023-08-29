using CleanCodeLaboration.Model.GameDAO.Interface;
using CleanCodeLaboration.Model.GameLogic.Interface;
using CleanCodeLaboration.Model.GameLogic.Strategy;
using CleanCodeLaboration.Model.GameLogic.Strategy.Interface;
using CleanCodeLaboration.Model.GameMenu;
using CleanCodeLaboration.Model.GameMenu.Interface;
using CleanCodeLaboration.View.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLaboration.Controller
{
    public class GameController
    {
        private readonly IGameContext gameContext;
        private readonly IIO iO;
        private IGameMenu gameMenu;

        public GameController(IGameContext gameContext, IIO iO)
        {
            this.gameContext = gameContext;
            this.iO = iO;
            this.gameMenu = new GameMenu();
        }
        public void SetGameMenu(IGameMenu gameMenu)
        {
            this.gameMenu = gameMenu;
        }
        public void StartCleanCodeGameLoop()
        {
            SetUserName();
            StartGameLoop();
        }
        public void SetUserName()
        {
            string playerNameQuestion = gameContext.GetPlayerNameQuestion();
            iO.GameOutput(playerNameQuestion);
            string playerName = iO.GetUserInput();
            gameContext.SetPlayerName(playerName);
        }
        public void StartGameLoop()
        {
            do 
            {
                GetGameMenu();
                GetGameLoop();
            } while (ContinuePlaying());
        }
        public void GetGameMenu()
        {
            do
            {
                OutputMenu(); 
                string answer = iO.GetUserInput();
                gameMenu.SelectGame(answer);

            } while (!gameMenu.IsValidSelection());
            IGameStrategy chosenStrategy = gameMenu.GetGameStrategy();
            gameContext.SetGameStrategy(chosenStrategy);
        }
        private void OutputMenu()
        {
            List<string> showGameMenu = gameMenu.GetMenu();
            for (int i = 0; i < showGameMenu.Count; i++)
            {
                string menyNumber = i+1+". "; //Magic number?
                iO.GameOutput(menyNumber + showGameMenu[i]);
            }
        }
        public void GetGameLoop()
        {
            string gameIntroduction = gameContext.GetGameIntroduction();

            iO.GameOutput(gameIntroduction);

            string rightAnswer = gameContext.GetRightAnswer();

            iO.GameOutput(rightAnswer);

            while (gameContext.IsGameActive())
            {
                string userGuess = iO.GetUserInput();
                string gameUpdateMessage = gameContext.EvaluateGuess(userGuess);
                iO.GameOutput(gameUpdateMessage);
            }
            string highScore = gameContext.GetHighScore();
            iO.GameOutput(highScore);

            string finishedGameMessage = gameContext.GetFinishedGameMessage();
            iO.GameOutput(finishedGameMessage);
        }
        private bool ContinuePlaying()
        {
            string askIfKeepPlaying = gameContext.GetPlayAgainMessage();
            iO.GameOutput(askIfKeepPlaying);
            string answer = iO.GetUserInput();
            return gameContext.KeepPlaying(answer);
        }
    }
}
