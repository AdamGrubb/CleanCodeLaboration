using CleanCodeLaboration.Model.GameDAO;
using CleanCodeLaboration.Model.GameDAO.Interface;
using CleanCodeLaboration.Model.GameLogic.Strategy;
using CleanCodeLaboration.Model.GameLogic.Strategy.Interface;
using CleanCodeLaboration.Model.GameLogic.Strategy.MooGameStrategy;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;

namespace CleanCodeLaborationTest.Model.GameLogic
{
    [TestClass]
    public class Test_MooGameStrategy
    {
        MooGameStrategy gameStrategy = new MooGameStrategy();

        [TestMethod]
        public void TestStartGame()
        {
            //Arrange
            bool afterStartGame;
            bool beforeStartGame;

            //Act
            beforeStartGame = gameStrategy.GetGameStatus();
            gameStrategy.StartGame();
            afterStartGame = gameStrategy.GetGameStatus();

            //Assert
            Assert.IsFalse(beforeStartGame);
            Assert.IsTrue(afterStartGame);
        }

        [TestMethod]
        public void TestGetGameIntroduction()
        {
            //Arrange
            const string expectedMessage = "New game:";
            string recivedMessage;

            //Act
            recivedMessage = gameStrategy.GetGameIntroduction();

            //Assert
            Assert.AreEqual(expectedMessage, recivedMessage);
        }
        [TestMethod]
        public void TestEvaluateGuess()
        {
            //Arrange
            string goal = "3724";
            string wrongGuess = "3224";
            string rightGuess = "3724";
            string rightGuessResponse = "BBBB,";
            string wrongGuessResponse = "BBB,C";


            //Act
            gameStrategy.SetGoal(goal);



            //Assert
            Assert.AreEqual(rightGuessResponse, gameStrategy.EvaluateGuess(rightGuess)); //Plocka ut dem till egna variabler
            Assert.AreEqual(wrongGuessResponse, gameStrategy.EvaluateGuess(wrongGuess)); //Plocka ut dem till egna variabler
        }
        [TestMethod]
        public void TestGetPracticeRun()
        {
            //Arrange
            string goal = "3724";
            gameStrategy.SetGoal(goal);
            string expectedResult = "For practice, number is: " + goal;
            string recivedResult;

            //Act
            recivedResult = gameStrategy.GetRightAnswer();

            //Assert
            Assert.AreEqual(@expectedResult, recivedResult);
        }
        [TestMethod]
        public void TestIncrementGuess()
        {
            //Arrange
            int guesses = 4;
            string expectedResult = "Correct, it took " + guesses + " guesses";
            string recivedResult;

            //Act
            for (int i = 0; i < guesses; i++)
            {
                gameStrategy.IncrementGuess();
            }
            recivedResult = gameStrategy.GetFinishedGameMessage();

            //Assert
            Assert.AreEqual(@expectedResult, recivedResult);
        }
        [TestMethod]
        public void TestIsCorrectGuess()
        {
            //Arrange
            string rightEvaluatedGuess = "BBBB,";
            string wrongEvaluatedGuess = "BB,CCCCCCC";

            //Act
            bool correctGuess = gameStrategy.IsCorrectGuess(rightEvaluatedGuess);
            bool wrongGuess = gameStrategy.IsCorrectGuess(wrongEvaluatedGuess);

            //Assert
            Assert.IsTrue(correctGuess);
            Assert.IsFalse(wrongGuess);
        }
        [TestMethod]
        public void TestGenerateRandomGoal()

        {
            //Arrange
            string goal;
            int lengthOfGoal = 4;

            //Act
            goal = gameStrategy.GenerateRandomGoal();

            //Assert
            // The loop iterates over the goal to check if every element of the goal is unique, which is the premise of MooGame.
            for (int i = 0; i < lengthOfGoal; i++)
            {
                for (int j = i + 1; j < lengthOfGoal; j++)
                {
                    Assert.IsFalse(goal[i] == goal[j]);
                }
            }
            Assert.AreEqual(lengthOfGoal, goal.Length);
        }
        [TestMethod]
        public void TestHighScore() //Denna skulle du kunna strukturera mer ordentligt, speciellt mock-delen.
        {
            //Arrange 
            var mockDAO = new Mock<IGameDAO>();
            string expectedHighScores = "Player   games average\n";
            string recivedHighScores;

            List<IPlayerScore> testPlayersScores = new List<IPlayerScore> { new PlayerScoreDTO("Bananaman", 15), new PlayerScoreDTO("Korven Senap", 15) };

            List<Player> players = StrategyUtilitys.ConvertToPlayer(testPlayersScores);

            StrategyUtilitys.SortPlayersByScore(players);
            expectedHighScores += StrategyUtilitys.GetFormattedPlayerScores(players);

            mockDAO.Setup(dao => dao.GetAllPlayerScores(It.IsAny<string>())).Returns(testPlayersScores);


            //Act
            gameStrategy.SetGameDAO(mockDAO.Object);
            recivedHighScores = gameStrategy.GetHighScore();

            //Assert
            Assert.AreEqual(expectedHighScores, recivedHighScores);
        }
        [TestCleanup]
        public void TestCleanup() //Kanske jätteonödigt att göra, tar massa kraft??
        {
            gameStrategy = new MooGameStrategy();
        }

        /*Dessa är kvar att testa:
         *EndGame
         *
         *Dessa två skulle jag kunna testa med en mock-dao. Göra SetPlayerName och sen incrementa 3 gånger, sen köra en Savegame typ?
         *SaveGame()
         *SetPlayerName
         */

    }
}
