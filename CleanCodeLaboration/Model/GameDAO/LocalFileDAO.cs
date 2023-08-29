using CleanCodeLaboration.Model.GameDAO.Interface;

namespace CleanCodeLaboration.Model.GameDAO
{
    public class LocalFileDAO : IGameDAO
    {
        private const string nameAndScoreSeperator = "#&#";
        private const string fileFormat = ".txt";

        public void SavePlayerScore(string gameName, IPlayerScore player) //Här har jag kvar gameName, för att denna ska fungera som en webApi. 
        {
            StreamWriter streamWriter = new StreamWriter(gameName + fileFormat, append: true);
            streamWriter.WriteLine(player.Name + nameAndScoreSeperator + player.Guesses);
            streamWriter.Close();
        }

        public List<IPlayerScore> GetAllPlayerScores(string gameName)
        {
            StreamReader streamReader = new StreamReader(gameName + fileFormat);
            List<IPlayerScore> playerScores = new List<IPlayerScore>();
            string line; //Line?
            while ((line = streamReader.ReadLine()) != null)
            {
                string[] nameAndScore = line.Split(new string[] { nameAndScoreSeperator }, StringSplitOptions.None);
                string name = nameAndScore[0];
                int score = Convert.ToInt32(nameAndScore[1]); //Här finns ju ingen felhantering, men whatever!?!?!?!?
                playerScores.Add(new PlayerScoreDTO(name, score));
            }
            streamReader.Close();

            return playerScores;
        }
    }
}
