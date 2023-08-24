using CleanCodeLaboration.Model.GameDAO.Interface;
using CleanCodeLaboration.Model.GameLogic.Interface;
using CleanCodeLaboration.Model.GameLogic.Strategy;
using CleanCodeLaboration.Model.GameLogic.Strategy.Interface;
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

        public GameController(IGameContext gameContext, IView view)
        {
            this.gameContext = gameContext;
            this.view = view;
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
            do
            {
                GetGameMenu();
                GetGameLoop();
            } while (ContinuePlaying());

        }
        public void GetGameMenu() //Här kommer du implementera meny-klassen. Mest troligt via dependency injection.
        {
            //Dummy-metod. DAO sätts inom SetGameStrategy - möjligen via en builder?
            //Här har du en stänga av funktion också.
            gameContext.SetGameStrategy(new MooGameStrategy());
        }
        public void GetGameLoop()
        {
            string gameIntroduction = gameContext.GetGameIntroduction();

            view.GameOutput(gameIntroduction);

            while (gameContext.IsGameActive())
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
