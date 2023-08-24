using CleanCodeLaboration.Model.GameDAO;
using CleanCodeLaboration.Model.GameDAO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLaborationTest.Model.GameDAO
{
    [TestClass]
    public class Test_LocalFileDAO
    {
        const string localFileDAOFormat = ".txt";
        const string nameAndScoreSeperator = "#&#";
        const string TestGameName = "Test";
        [TestMethod]
        public void SavePlayerScore_Test()
        {
            //Arrange
            IGameDAO gameDAO = new LocalFileDAO();

            IPlayerScore testPlayerScore = new PlayerScoreDTO("Tarzan", 5);


            //Act
            gameDAO.SavePlayerScore(TestGameName, testPlayerScore);

            //Assert
            string[] lines = File.ReadAllLines(TestGameName + ".txt");
            Assert.IsTrue(lines.Length > 0);
            Assert.AreEqual($"{testPlayerScore.Name}{nameAndScoreSeperator}{testPlayerScore.Guesses}", lines[0]);

        }
        [TestMethod]
        public void GetAllPlayerScores_Test()
        {
            //Arrange
            IGameDAO gameDAO = new LocalFileDAO();
            List<IPlayerScore> TestPlayers = new List<IPlayerScore>() { new PlayerScoreDTO("Tarzan", 5), new PlayerScoreDTO("Jonnes", 5), new PlayerScoreDTO("Skrumpis", 5) };

            //Act
            TestPlayers.ForEach(player => gameDAO.SavePlayerScore(TestGameName, player));
            List<IPlayerScore> retrivedList = gameDAO.GetAllPlayerScores(TestGameName);

            //Assert
            CollectionAssert.AreEqual(TestPlayers, retrivedList);

        }
        [TestCleanup]
        public void TestCleanup()
        {
            if (File.Exists(TestGameName + localFileDAOFormat)) File.Delete(TestGameName + localFileDAOFormat);
        }

    }
}
