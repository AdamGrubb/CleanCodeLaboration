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
        public void InputPlayerName() //Lite oklart att den sätter namnet samt frågar om det.
        {
            OutputPlayerNamePromt();

            SetUserName();
        }
        public void RunGameLoop()
        {


            StartNewGame(); //Lite fortfarande för StartNewGame, det är svårt att veta vad den gör.

            OutputGameIntroduction();

            OutputCorrectAnswer();

            PromtUserGuesses();  //PromtUserGuesses? Fundera lite mer på den. också svårt att veta vad den gör. Har sammai GameStrategyMenu nu också.

            OutputHighScore();

            OutputFinishedGameMessage();
        }
        private void OutputPlayerNamePromt()
        {
            string playerNameQuestion = gameContext.GetPlayerNameQuestion();
            OutputMessage(playerNameQuestion);
        }
        private void OutputMessage(string output) //Denna får du också kolla över namnet på.
        {
            iO.GameOutput(output);
        }
        private void SetUserName()
        {

            string playerName = GetUserInput();
            gameContext.SetPlayerName(playerName);
        }
        private string GetUserInput()
        {
            return iO.GetUserInput();
        }
        private void StartNewGame()
        {
            gameContext.StartNewGame();
        }
        private void OutputGameIntroduction()
        {
            string gameIntroduction = gameContext.GetGameIntroduction();

            OutputMessage(gameIntroduction);

        }
        private void OutputCorrectAnswer()
        {
            string rightAnswer = gameContext.GetRightAnswer();

            OutputMessage(rightAnswer);
        }
        private void PromtUserGuesses()
        {
            while (ActiveGame())
            {
                string userGuess = GetUserInput();
                string gameUpdateMessage = CheckPlayerAnswer(userGuess);

                OutputMessage(gameUpdateMessage);
            }
        }
        private bool ActiveGame()
        {
            return gameContext.IsGameActive();
        }
        private string CheckPlayerAnswer(string userGuess)
        {
            return gameContext.CheckPlayerAnswer(userGuess);
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
