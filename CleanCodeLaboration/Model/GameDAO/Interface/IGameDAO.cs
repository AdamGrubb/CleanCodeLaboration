namespace CleanCodeLaboration.Model.GameDAO.Interface
{
    public interface IGameDAO
    {
        List<IPlayerScore> GetAllPlayerScores(string gameName);
        void SavePlayerScore(string gameName, IPlayerScore player);
    }
}