using CleanCodeLaboration.Model.GameDAO.Interface;
using CleanCodeLaboration.Model.GameHighScore.Interface;
using CleanCodeLaboration.Model.GameHighScore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLaboration.Model.Utilities
{
    public static class PlayerConverter
    {
        public static List<IPlayer> ToPlayer(List<IPlayerScore> playerScores) //Ska jag göra en utility-klass med den här metoden? Frågar sig jag!
        {
            List<IPlayer> players = new List<IPlayer>();
            foreach (IPlayerScore playerScore in playerScores) //Går det att bryta ut till fler metoder kanske?
            {
                Player pd = new Player(playerScore.Name, playerScore.Guesses); //Här har du player som Pd
                int pos = players.IndexOf(pd); //Här har du en förkortning för pos, det är icke sa nicke.
                if (pos < 0)
                {
                    players.Add(pd);
                }
                else
                {
                    players[pos].Update(playerScore.Guesses);
                }
            }
            return players;
        }
    }
}
