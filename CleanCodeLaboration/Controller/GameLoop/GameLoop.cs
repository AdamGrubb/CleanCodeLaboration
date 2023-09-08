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
        private readonly IGameLogicContext gameContext;

        public GameLoop(IIO iO, IGameLogicContext gameContext)
        {
            this.iO = iO;
            this.gameContext = gameContext;
        }
        public void SetGameStrategy(IGameStrategy gameStrategy)
        {
            gameContext.SetGameStrategy(gameStrategy);
        }
        public void InputPlayerName()
        {
            OutputPlayerNamePrompt();

            SetUserName();
        }
        public void RunGameLoop()
        {
            StartNewGame();

            OutputGameIntroduction();

            OutputCorrectAnswer();

            PromptUserGuesses();

            OutputHighScore();

            OutputFinishedGameMessage();
        }
        private void OutputPlayerNamePrompt()
        {
            string playerNameQuestion = gameContext.GetPlayerNameQuestion();
            OutputMessage(playerNameQuestion);
        }
        private void OutputMessage(string messageToOutput)
        {
            iO.GameOutput(messageToOutput);
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
        private void PromptUserGuesses()
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
