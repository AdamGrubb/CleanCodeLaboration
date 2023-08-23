namespace CleanCodeLaboration.Model.GameDAO.Interface
{
    public interface IGameDAO
    {
        List<IPlayer> GetAllPlayerScores(string gameName);
        void SavePlayerScore(string gameName, IPlayer player);
    }
}