using CleanCodeLaboration.Model.GameLogic.Interface;
using CleanCodeLaboration.Model.GameLoop.Interface;
using CleanCodeLaboration.View.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLaboration.Model.GameLoop
{
    public class GameLoop : IGameLoop
    {
        private readonly IIO iO;
        private readonly IGameContext gameContext;

        public GameLoop(IIO iO, IGameContext gameContext) //Det är ju lite tokigt att den kommer krascha ifall man inte har skickat in ett IGameStrategy? Du kan ju ha det som output att man måste använda SetGameStrategy.
        {
            this.iO = iO;
            this.gameContext = gameContext;
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
        public void GetGameLoop()
        {
            do
            {
                AskForPlayerName();

                SetUserName();

                StartNewGame();

                GameIntroduction(); //OutputGameIntroduktion?

                GetCorrectAnswer(); //ShowCorrectAnswer? OutPutCorrectAnswer?

                GetUserGuesses(); //Här ska det framgå mer att det är nån slags guess-loop?

                GetHighScore();

                GetFinishedGameMessage();

            } while (ShouldContinuePlaying());


        }
        private void StartNewGame() //Start Game? Eventuellt ta bort
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
        private void GetUserGuesses() //Här skulle jag ju kunna lägga till en int som aggregeras och skickas in i save?
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
    }
}
