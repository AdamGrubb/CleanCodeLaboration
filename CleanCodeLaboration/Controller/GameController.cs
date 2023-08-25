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
        private readonly IView view;
        private IGameMenu gameMenu;

        public GameController(IGameContext gameContext, IView view)
        {
            this.gameContext = gameContext;
            this.view = view;
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
            view.GameOutput(playerNameQuestion);
            string playerName = view.GetUserInput();
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
                view.GameOutput(showGameMenu);
                string answer = view.GetUserInput();
                gameMenu.SelectedGame(answer);

            } while (!gameMenu.IsValidSelection());
            IGameStrategy chosenStrategy = gameMenu.GetGameStrategy();
            gameContext.SetGameStrategy(chosenStrategy);
 
        }
        public void GetGameLoop()
        {
            string gameIntroduction = gameContext.GetGameIntroduction();

            view.GameOutput(gameIntroduction);

            while (gameContext.GetGameStatus())
            {
                string userGuess = view.GetUserInput();
                string gameUpdateMessage = gameContext.EvaluateGuess(userGuess);
                view.GameOutput(gameUpdateMessage);
            }
            string highScore = gameContext.GetHighScore();
            view.GameOutput(highScore);

            string finishedGameMessage = gameContext.GetFinishedGameMessage();
            view.GameOutput(finishedGameMessage);
        }
        private bool ContinuePlaying()
        {
            string askIfKeepPlaying = gameContext.GetPlayAgainMessage();
            view.GameOutput(askIfKeepPlaying);
            string answer = view.GetUserInput();
            return gameContext.KeepPlaying(answer);
        }
    }
}
