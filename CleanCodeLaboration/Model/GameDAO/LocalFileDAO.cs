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

        public List<IPlayerScore> GetAllPlayerScores(string gameName) //I denna metod så saknas det felhantering för om filen inte skulle existera samt ingen tryparse på convertToInt32 ifall det skulle vara text i filen som inte går att convertera.
        {
            StreamReader streamReader = new StreamReader(gameName + fileFormat);
            List<IPlayerScore> playerScores = new List<IPlayerScore>();
            string line; //Line? Row kanske? eller något
            while ((line = streamReader.ReadLine()) != null)
            {
                string[] nameAndScore = line.Split(new string[] { nameAndScoreSeperator }, StringSplitOptions.None);
                string name = nameAndScore[0];
                int score = Convert.ToInt32(nameAndScore[1]);
                playerScores.Add(new PlayerScoreDTO(name, score));
            }
            streamReader.Close();

            return playerScores;
        }
    }
}
