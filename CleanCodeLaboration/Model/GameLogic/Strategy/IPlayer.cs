namespace CleanCodeLaboration.Model.GameLogic.Strategy
{
    public interface IPlayer
    {
        string Name { get; }
        int NumberOfGames { get; }

        bool Equals(object p);
        double GetAverageScore();
        int GetHashCode();
        void Update(int guesses);
    }
}