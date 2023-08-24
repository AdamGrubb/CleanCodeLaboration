﻿using CleanCodeLaboration.Model.GameDAO.Interface;
using CleanCodeLaboration.Model.GameLogic.Strategy;
using CleanCodeLaboration.Model.GameLogic.Strategy.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLaborationTest.Model.GameLogic
{
    [TestClass]
    public class Test_MooGameStrategy
    {
        IGameStrategy gameStrategy = new MooGameStrategy();

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
            const string expectedMessage = "New game:\n";
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
            Assert.AreEqual(rightGuessResponse, gameStrategy.EvaluateGuess(rightGuess));
            Assert.AreEqual(wrongGuessResponse, gameStrategy.EvaluateGuess(wrongGuess));
        }
        [TestMethod]
        public void TestGetPracticeRun()
        {
            //Arrange
            string goal = "3724";
            gameStrategy.SetGoal(goal);
            string expectedResult = "For practice, number is: " + goal + "\n";
            string recivedResult;

            //Act
            recivedResult = gameStrategy.GetPracticeRun();

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
            for (int i = 0; i< lengthOfGoal; i++)
            {
                for (int j = i+1; j < lengthOfGoal; j++)
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


        /*
        void SetGameDAO;

        GetGoal?

        GetHighScore

        SetPlayerName?

        SaveGame(),

        EndGame.

        */

        //Arrange

        //Act

        //Assert

    }
}
