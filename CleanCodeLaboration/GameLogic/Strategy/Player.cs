using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanCodeLaboration.GameDAO.Interface;

namespace CleanCodeLaboration.GameLogic.Strategy
{
    public class Player
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

        public void Update(int guesses) //Flytta ut till en annan klass.
        {
            Guesses += guesses;
            NumberOfGames++;
        }
        public double GetAverageScore() //Flytta ut till en annan klass.
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
