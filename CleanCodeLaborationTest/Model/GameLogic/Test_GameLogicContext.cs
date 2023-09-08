using CleanCodeLaboration.Model.GameHighScore;
using CleanCodeLaboration.Model.GameHighScore.Interface;
using CleanCodeLaboration.Model.GameLogic;
using CleanCodeLaboration.Model.GameLogic.Interface;
using CleanCodeLaboration.Model.GameLogic.Strategy.Interface;
using CleanCodeLaboration.Model.GameLogic.Strategy.MooGameStrategy;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLaborationTest.Model.GameLogic
{

    [TestClass]
    public class Test_GameLogicContext
    {
        IHighScoreReport highScoreReport;
        IGameLogicContext gameLogicContext;
        Mock<IGameStrategy> mockGameStrategy;
        [TestInitialize]
        public void TestInitialize()
        {
            highScoreReport = new HighScoreReport();
            gameLogicContext = new GameLogicContext(highScoreReport);
            mockGameStrategy = new Mock<IGameStrategy>();

        }
        [TestMethod]
        [DataTestMethod]
        [DataRow("adam", "adam", "Han Solo", 1)]
        [DataRow("jane", "jane", "Darth Vader", 3)]
        public void TestStartNewGame(string name, string sameName, string mockGoal, int callsMade)
        {

            //Arrange
            gameLogicContext.SetPlayerName(name);
            gameLogicContext.SetGameStrategy(mockGameStrategy.Object);
            mockGameStrategy.Setup(dao => dao.GenerateGoal()).Returns(mockGoal);


            //Act
            for (int i = 0; i < callsMade; i++)
            {
                gameLogicContext.StartNewGame();
            }


            //Assert
            mockGameStrategy.Verify(method => method.GenerateGoal(), Times.Exactly(callsMade));
            mockGameStrategy.Verify(method => method.SetGoal(mockGoal), Times.Exactly(callsMade));
            mockGameStrategy.Verify(method => method.ActivateGame(), Times.Exactly(callsMade));
        }
        [DataTestMethod]
        [DataRow("Välkommen till hänga gubbe")]
        [DataRow("Välkommen till quizGame")]
        [DataRow("Välkommen till Zerg Rush")]
        public void TestGetGameIntroduction(string introduction)
        {
            //Arrange
            mockGameStrategy.Setup(mockGame => mockGame.GetGameIntroduction()).Returns(introduction);
            gameLogicContext.SetGameStrategy(mockGameStrategy.Object);

            //Act
            string gameIntroduction = gameLogicContext.GetGameIntroduction();

            //Assert
            Assert.AreEqual(introduction, gameIntroduction);
        }
        [DataTestMethod]
        [DataRow("234", "Rätt", true, "adam")]
        [DataRow("234", "Fel", false, "john")]
        [DataRow("234", "Rätt", true, "hannes")]
        [DataRow("2354", "fel", false,"johanna")]
        public void TestCheckPlayerAnswer(string guess, string evaluatedReturn, bool IsCorrectGuess, string playerName)
        {
            //Arrange
            gameLogicContext.SetGameStrategy(mockGameStrategy.Object);
            gameLogicContext.SetPlayerName(playerName);
            mockGameStrategy.Setup(strategy => strategy.GetEvaluatedGuess(guess)).Returns(evaluatedReturn);
            mockGameStrategy.Setup(strategy => strategy.IsCorrectGuess(evaluatedReturn)).Returns(IsCorrectGuess);

            //Act
            string evaluatedGuess = gameLogicContext.CheckPlayerAnswer(guess);

            //Assert
            mockGameStrategy.Verify(strategy => strategy.GetEvaluatedGuess(guess));
            mockGameStrategy.Verify(strategy => strategy.IncrementGuessCount(), Times.Once);
            if (IsCorrectGuess == true)
            {
                mockGameStrategy.Verify(strategy => strategy.SaveGame(playerName), Times.Once);
                mockGameStrategy.Verify(strategy => strategy.DeactivateGame(), Times.Once);
            }
            Assert.AreEqual(evaluatedGuess, evaluatedReturn);

        }

    }
}
