using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanCodeLaboration.GameDAO.Interface;
using CleanCodeLaboration.GameLogic.Strategy;

namespace CleanCodeLaboration.GameDAO
{
    public class LocalFileDAO : IGameDAO
    {
        private const string nameAndScoreSeperator = "#&#";
        private const string fileFormat = ".txt";

        public void SavePlayerScore(string gameName, IPlayer player) //Här har jag kvar gameName, för att denna ska fungera som en webApi. 
        {
            StreamWriter streamWriter = new StreamWriter(gameName + fileFormat, append: true);
            streamWriter.WriteLine(player.Name + nameAndScoreSeperator + player.Guesses);
            streamWriter.Close();
        }

        public List<IPlayer> GetAllPlayerScores(string gameName)
        {
            StreamReader streamReader = new StreamReader(gameName + fileFormat);
            List<IPlayer> playerScores = new List<IPlayer>();
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                string[] nameAndScore = line.Split(new string[] { nameAndScoreSeperator }, StringSplitOptions.None);
                string name = nameAndScore[0];
                int score = Convert.ToInt32(nameAndScore[1]);
                playerScores.Add(new PlayerDTO(name, score));
            }
            streamReader.Close();

            return playerScores;
        }
    }
}
