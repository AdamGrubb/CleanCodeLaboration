using CleanCodeLaboration.Model.GameHighScore.Interface;

namespace CleanCodeLaboration.Model.GameHighScore
{
    public class Player : IPlayer
    {

        public string Name { get; private set; }
        public int NumberOfGames { get; private set; }
        public int Guesses;


        public Player(string name, int guesses)
        {
            Name = name;
            NumberOfGames = 1;
            Guesses = guesses;
        }

        public void Update(int guesses)
        {
            Guesses += guesses;
            NumberOfGames++;
        }
        public double GetAverageScore()
        {
            return (double)Guesses / NumberOfGames;
        }
        public override bool Equals(object p)
        {
            return Name.Equals(((Player)p).Name);
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
