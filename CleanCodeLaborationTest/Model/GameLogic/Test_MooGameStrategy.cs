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
using CleanCodeLaboration.Model.GameHighScore.Interface;
using CleanCodeLaboration.Model.GameLogic.Interface;

namespace CleanCodeLaborationTest.Model.GameLogic
{
    [TestClass]
    public class Test_MooGameStrategy
    {
        IGameStrategy mooGameStrategy;
        IGameDAO gameDAO;
        [TestInitialize]
        public void TestInitialize()
        {
            gameDAO = new LocalFileDAO();
            mooGameStrategy = new MooGameStrategy(gameDAO);
        }
        [TestMethod]
        public void TestActivateGame()
        {
            bool isGameActive = false;

            mooGameStrategy.ActivateGame();
            isGameActive = mooGameStrategy.IsGameActive();

            Assert.IsTrue(isGameActive);
        }
        [DataTestMethod]
        [DataRow("3224", "BBB,C")]
        [DataRow("3724", "BBBB,")]
        public void TestEvaluateGuess(string guess, string evaluatedAnswer)
        {
            string goal = "3724";

            mooGameStrategy.SetGoal(goal);

            Assert.AreEqual(evaluatedAnswer, mooGameStrategy.GetEvaluatedGuess(guess));
        }
        [DataTestMethod]
        [DataRow("3724")]
        [DataRow("3752")]
        [DataRow("3428")]
        [DataRow("7234")]
        public void TestSetGoal(string goal)
        {
            string expectedResult = "For practice, number is: " + goal;
            string recivedResult;

            mooGameStrategy.SetGoal(goal);
            recivedResult = mooGameStrategy.GetRightAnswer();

            Assert.AreEqual(@expectedResult, recivedResult);
        }
        [DataTestMethod]
        [DataRow(4)]
        [DataRow(2)]
        [DataRow(12)]
        public void TestIncrementGuess(int guesses)
        {
            string expectedResult = "Correct, it took " + guesses + " guesses";
            string recivedResult;

            for (int i = 0; i < guesses; i++)
            {
                mooGameStrategy.IncrementGuessCount();
            }
            recivedResult = mooGameStrategy.GetFinishedGameMessage();

            Assert.AreEqual(expectedResult, recivedResult);
        }
        [TestMethod]
        public void TestWrongGuess()
        {
            string wrongEvaluatedGuess = "BB,CCCCCCC";

            bool wrongGuess = mooGameStrategy.IsCorrectGuess(wrongEvaluatedGuess);

            Assert.IsFalse(wrongGuess);
        }
        [TestMethod]
        public void TestCorrectGuess()
        {
            string rightEvaluatedGuess = "BBBB,";

            bool correctGuess = mooGameStrategy.IsCorrectGuess(rightEvaluatedGuess);

            Assert.IsTrue(correctGuess);
        }

        [TestMethod]
        public void TestGenerateRandomGoal()

        {
            string goal;
            const int lengthOfGoal = 4;

            goal = mooGameStrategy.GenerateGoal();

            for (int i = 0; i < lengthOfGoal; i++)
            {
                for (int j = i + 1; j < lengthOfGoal; j++)
                {
                    Assert.IsFalse(goal[i] == goal[j]);
                }
            }
            Assert.AreEqual(lengthOfGoal, goal.Length);
        }
    }
}
