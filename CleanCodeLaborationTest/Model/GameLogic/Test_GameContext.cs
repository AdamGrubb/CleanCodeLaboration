using CleanCodeLaboration.Model.GameDAO;
using CleanCodeLaboration.Model.GameDAO.Interface;
using CleanCodeLaboration.Model.GameLogic;
using CleanCodeLaboration.Model.GameLogic.Interface;
using CleanCodeLaboration.Model.GameLogic.Strategy;
using CleanCodeLaboration.Model.GameLogic.Strategy.Interface;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLaborationTest.Model.GameLogic
{
    [TestClass]
    public class Test_GameContext
    {
        private Mock<IGameStrategy> mockGameStrategy;
        private Mock<IGameDAO> mockGameDAO;
        private IGameContext gameContext;

        [TestInitialize]
        public void Initialize()
        {
            mockGameStrategy = new Mock<IGameStrategy>();
            mockGameDAO = new Mock<IGameDAO>();
            gameContext = new GameContext(mockGameDAO.Object);
        }

        [DataTestMethod]
        [DataRow("adam", "adam", "Han Solo", 1)]
        [DataRow("jane", "jane", "Darth Vader", 3)]
        public void TestStartNewGame(string name, string sameName,string mockGoal, int callsMade)
        {

            //Arrange
            gameContext.SetPlayerName(name);
            gameContext.SetGameStrategy(mockGameStrategy.Object);
            mockGameStrategy.Setup(dao => dao.GenerateRandomGoal()).Returns(mockGoal);


            //Act
            for (int i = 0; i<callsMade; i++)
            {
                gameContext.StartNewGame();
            }
            

            //Assert
            mockGameStrategy.Verify(method => method.SetGameDAO(It.Is<IGameDAO>(dao => dao == mockGameDAO.Object)), Times.Exactly(callsMade));
            mockGameStrategy.Verify(method => method.SetPlayerName(sameName),Times.Exactly(callsMade));
            mockGameStrategy.Verify(method => method.GenerateRandomGoal(),Times.Exactly(callsMade));
            mockGameStrategy.Verify(method => method.SetGoal(mockGoal),Times.Exactly(callsMade));
            mockGameStrategy.Verify(method => method.ActivateGame(),Times.Exactly(callsMade));
        }
        [DataTestMethod]
        [DataRow("Välkommen till hänga gubbe")]
        [DataRow("Välkommen till quizGame")]
        [DataRow("Välkommen till Zerg Rush")]
        public void TestGetGameIntroduction(string introduction)
        {
            //Arrange
            mockGameStrategy.Setup(mockGame => mockGame.GetGameIntroduction()).Returns(introduction);
            gameContext.SetGameStrategy(mockGameStrategy.Object);

            //Act
            string gameIntroduction = gameContext.GetGameIntroduction();

            //Assert
            Assert.AreEqual(introduction, gameIntroduction);
        }
        //public string GetGameIntroduction()
        //{
        //    return gameStrategy.GetGameIntroduction();
        //}

    }

}
