﻿using CleanCodeLaboration.Model.GameLogic.Interface;
using CleanCodeLaboration.Model.GameLogic.Strategy.Interface;
using CleanCodeLaboration.Model.GameMenu;
using CleanCodeLaboration.Model.GameMenu.Interface;
using CleanCodeLaboration.View.Interface;

namespace CleanCodeLaboration.Controller
{

    /*
     * Kolla över om du använder denna standard:
    Use Get prefix for methods that return a single value or object.
    Use Set prefix for methods that assign a value or object to a property or field.
    Use Add prefix for methods that add an item to a collection.
    Use Remove prefix for methods that remove an item from a collection.
    Use Create prefix for methods that create and return a new instance of a type.
    Use Find prefix for methods that search for an item in a collection and return it or its index.
    Use Is, Has, or Can prefixes for methods that return a boolean value indicating a condition or capability.

    Sid. 80 Vertical Distance kolla på det.
     */
    public class GameController
    {
        private readonly IGameContext gameContext;
        private readonly IIO iO;
        private IGameMenu gameMenu;

        public GameController(IGameContext gameContext, IIO iO)
        {
            this.gameContext = gameContext;
            this.iO = iO;
            gameMenu = new GameMenu();
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

        public void StartGameLoop() //Egentligen borde GetGameLoop kanske heta StartGameLoop. Ska man kanske plocka in SetUserName här ínnan? Så döper jag den till StartGame()? Och tar bort StartCleanCodeGameLoop
        {
            do 
            {
                GetGameMenu();
                GetGameLoop();
            } while (ContinuePlaying());
        }

        public void GetGameMenu() //Start GameMenu or something? Det är ju Void?
        {
            do
            {
                OutputMenu(); 
                string answer = iO.GetUserInput();
                gameMenu.SelectGame(answer);

            } while (!gameMenu.IsValidSelection()); //Ändra namn till MadeValidSelection?
            IGameStrategy chosenStrategy = gameMenu.GetGameStrategy();
            gameContext.SetGameStrategy(chosenStrategy);
        }

        private void OutputMenu()
        {
            List<string> showGameMenu = gameMenu.GetMenu();
            for (int i = 0; i < showGameMenu.Count; i++)
            {
                int displayNumber = i + 1;
                string menuNumber = $"{displayNumber}. ";
                iO.GameOutput(menuNumber + showGameMenu[i]);
            }
        }

        public void GetGameLoop() //Lista ut vad den här ska heta, 
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
