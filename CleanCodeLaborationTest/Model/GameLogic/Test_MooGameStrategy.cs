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
using CleanCodeLaboration.Model.GameHighScore;

namespace CleanCodeLaborationTest.Model.GameLogic
{
    [TestClass]
    public class Test_MooGameStrategy //Borde jag kanske ta bort alla arrange act och assert?
    {
        MooGameStrategy gameStrategy = new MooGameStrategy();

        [TestMethod]
        public void TestActivateGame()
        {
            //Arrange
            bool beforeActivateGame;
            bool afterActivateGame;
           

            //Act
            beforeActivateGame = gameStrategy.IsGameActive();
            gameStrategy.ActivateGame();
            afterActivateGame = gameStrategy.IsGameActive();

            //Assert
            Assert.IsFalse(beforeActivateGame);
            Assert.IsTrue(afterActivateGame);
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
        public void TestEvaluateGuess() //testa DataTestMethod för att snygga till det.
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
            Assert.AreEqual(rightGuessResponse, gameStrategy.GetEvaluatedGuess(rightGuess)); //Plocka ut dem till egna variabler
            Assert.AreEqual(wrongGuessResponse, gameStrategy.GetEvaluatedGuess(wrongGuess)); //Plocka ut dem till egna variabler
        }
        [TestMethod]
        public void TestSetGoal()
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
                gameStrategy.IncrementGuessCount();
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
            goal = gameStrategy.GenerateGoal();

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
        [TestCleanup]
        public void TestCleanup() //Kanske jätteonödigt att göra, tar massa kraft??
        {
            gameStrategy = new MooGameStrategy();
        }
    }
}
