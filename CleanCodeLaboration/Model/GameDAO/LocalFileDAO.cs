using CleanCodeLaboration.Model.GameDAO.Interface;

namespace CleanCodeLaboration.Model.GameDAO
{
    public class LocalFileDAO : IGameDAO
    {
        private const string nameAndScoreSeperator = "#&#";
        private const string fileFormat = ".txt";

        public void SavePlayerScore(string gameName, IPlayerScore player)
        {
            StreamWriter streamWriter = new StreamWriter(gameName + fileFormat, append: true);
            streamWriter.WriteLine(player.Name + nameAndScoreSeperator + player.Guesses);
            streamWriter.Close();
        }

        public List<IPlayerScore> GetAllPlayerScores(string gameName)
        {
            StreamReader streamReader = new StreamReader(gameName + fileFormat);
            List<IPlayerScore> playerScores = new List<IPlayerScore>();
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                string[] nameAndGuesses = line.Split(new string[] { nameAndScoreSeperator }, StringSplitOptions.None);
                string name = nameAndGuesses[0];
                int guesses = Convert.ToInt32(nameAndGuesses[1]);
                playerScores.Add(new PlayerScoreDTO(name, guesses));
            }
            streamReader.Close();

            return playerScores;
        }
    }
}
