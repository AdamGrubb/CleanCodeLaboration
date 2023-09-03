using CleanCodeLaboration.Controller.GameLoop.Interface;
using CleanCodeLaboration.Model.GameLogic.Interface;
using CleanCodeLaboration.Model.GameLogic.Strategy.Interface;
using CleanCodeLaboration.View.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLaboration.Controller.GameLoop
{
    public class GameLoop : IGameLoop
    {
        private readonly IIO iO;
        private readonly IGameContext gameContext;

        public GameLoop(IIO iO, IGameContext gameContext)
        {
            this.iO = iO;
            this.gameContext = gameContext;
        }
        public void SetGameStrategy(IGameStrategy gameStrategy)
        {
            gameContext.SetGameStrategy(gameStrategy);
        }
        public void RunGameLoop()
        {
            OutputPlayerNamePromt();

            SetUserName();

            StartNewGame();

            OutputGameIntroduction();

            OutputCorrectAnswer();

            PromtUserGuesses();  //PromtUserGuesses? Fundera lite mer på den.

            OutputHighScore();

            OutputFinishedGameMessage();
        }
        private void OutputPlayerNamePromt()
        {
            string playerNameQuestion = gameContext.GetPlayerNameQuestion();
            iO.GameOutput(playerNameQuestion);
        }
        private void SetUserName()
        {

            string playerName = iO.GetUserInput();
            gameContext.SetPlayerName(playerName);
        }
        private void StartNewGame()
        {
            gameContext.StartNewGame();
        }
        private void OutputGameIntroduction()
        {
            string gameIntroduction = gameContext.GetGameIntroduction();

            iO.GameOutput(gameIntroduction);
        }
        private void OutputCorrectAnswer()
        {
            string rightAnswer = gameContext.GetRightAnswer();
            iO.GameOutput(rightAnswer);
        }
        private void PromtUserGuesses()
        {
            while (gameContext.IsGameActive())
            {
                string userGuess = iO.GetUserInput();
                string gameUpdateMessage = gameContext.CheckPlayerAnswer(userGuess);
                iO.GameOutput(gameUpdateMessage);
            }
        }
        private void OutputHighScore()
        {
            string highScore = gameContext.GetHighScore();
            iO.GameOutput(highScore);
        }
        private void OutputFinishedGameMessage()
        {
            string finishedGameMessage = gameContext.GetFinishedGameMessage();
            iO.GameOutput(finishedGameMessage);
        }
    }
}
