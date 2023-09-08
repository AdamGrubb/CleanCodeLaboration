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
        public static List<IPlayer> ToPlayer(List<IPlayerScore> playerScores)
        {
            List<IPlayer> players = new List<IPlayer>();
            foreach (IPlayerScore playerScore in playerScores)
            {
                IPlayer player = new Player(playerScore.Name, playerScore.Guesses);

                int playerIndex = players.IndexOf(player);
                
                if (playerIndex < 0)
                {
                    players.Add(player);
                }
                else
                {
                    players[playerIndex].Update(playerScore.Guesses);
                }
            }
            return players;
        }
    }

}
