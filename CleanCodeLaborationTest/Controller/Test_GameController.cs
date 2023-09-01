using CleanCodeLaboration.Model.GameDAO.Interface;
using CleanCodeLaboration.Model.GameLogic.Strategy.Interface;
using CleanCodeLaboration.Model.GameLogic.Strategy.MooGameStrategy;
using CleanCodeLaboration.Model.GameLogic;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanCodeLaboration.Model.GameMenu.Interface;
using CleanCodeLaboration.Controller;
using CleanCodeLaboration.Model.GameLogic.Interface;
using CleanCodeLaboration.View.Interface;

namespace CleanCodeLaborationTest.Controller
{
    [TestClass]
    public class Test_GameController
    {
        Mock<IGameMenu> mockMenu;
        Mock<IGameStrategy> mockStrategy;
        Mock<IGameContext> mockContext;
        Mock<IIO> mockIO;
        GameController gameController;

        [TestInitialize]
        public void Initialize()
        {
            mockMenu = new Mock<IGameMenu>();
            mockStrategy = new Mock<IGameStrategy>();
            mockContext = new Mock<IGameContext>();
            mockIO = new Mock<IIO>();
            gameController = new GameController(mockContext.Object, mockIO.Object);
        }
    }
}
