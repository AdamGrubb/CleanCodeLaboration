using CleanCodeLaboration.Model.GameDAO.Interface;
using CleanCodeLaboration.Model.GameLogic.Interface;
using CleanCodeLaboration.Model.GameLogic.Strategy;
using CleanCodeLaboration.Model.GameLogic.Strategy.Interface;
using CleanCodeLaboration.Model.GameMenu.Interface;
using CleanCodeLaboration.View.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
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
            do //Varför en do-while-loop här?
            {
                GetGameMenu();
                GetGameLoop();
            } while (ContinuePlaying());

        }
        public void GetGameMenu()
        {
            do //Varför göra en do-while-loop här?
            {
                string showGameMenu = gameMenu.GetMenu();
                iO.GameOutput(showGameMenu);
                string answer = iO.GetUserInput();
                gameMenu.SelectedGame(answer);

            } while (!gameMenu.IsValidSelection());
            IGameStrategy chosenStrategy = gameMenu.GetGameStrategy();
            gameContext.SetGameStrategy(chosenStrategy);

        }
        public void GetGameLoop()
        {
            string gameIntroduction = gameContext.GetGameIntroduction();

            iO.GameOutput(gameIntroduction);

            while (gameContext.GetGameStatus())
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
