using CleanCodeLaboration.Controller.GameMenu.Interface;
using CleanCodeLaboration.Model.GameLogic.Strategy.Interface;
using CleanCodeLaboration.Model.GameLogic.Strategy.MooGameStrategy;
using CleanCodeLaboration.Model.GameMenu;
using CleanCodeLaboration.Model.GameMenu.Commands;
using Moq;
using System.Security.Cryptography.X509Certificates;

namespace CleanCodeLaborationTest.Model.GameMenu
{
    [TestClass]
    public class Test_GameMenu
    {
        Mock<IGameCommand> mockCommand;
        Mock<IGameStrategy> mockStrategy;
        IGameMenu gameMenu;
        [TestInitialize]
        public void Initialize()
        {
            mockCommand = new Mock<IGameCommand>();
            mockStrategy = new Mock<IGameStrategy>();
            IGameCommand[] commands = new IGameCommand[] { mockCommand.Object, mockCommand.Object, mockCommand.Object };
            gameMenu = new GameStrategyMenu(commands);


        }

        [DataTestMethod]
        [DataRow("Minröjare")]
        [DataRow("Flerval")]
        [DataRow("Run")]
        public void TestGetMenu(string mockMenuItem)
        {
            //Arrange
            mockCommand.Setup(meny => meny.Description).Returns(mockMenuItem);



            //Act
            List<string> games = gameMenu.GetMenu();

            //Assert
            games.ForEach((game) =>
            {
                Assert.IsTrue(game.Contains(mockMenuItem));
            });

        }
        [DataTestMethod]
        [DataRow("1", true)]
        [DataRow("", false)]
        [DataRow("2", true)]
        [DataRow(null, false)]
        [DataRow("432432", false)]
        public void TestSelectGame(string mockGuess, bool expectedResult)
        {
            //Arrange
            mockCommand.Setup(gameStrategy => gameStrategy.Execute()).Returns(new MooGameStrategy());
            bool IsNull;

            //Act
            IGameStrategy mockResult = gameMenu.SelectGame(mockGuess);
            IsNull = mockResult != null;

            //Assert
            Assert.AreEqual(IsNull, expectedResult);
        }
    }

}
