using CleanCodeLaboration.Model.GameDAO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLaboration.Model.GameLogic.Strategy
{
    public static class StrategyUtilitys
    {
        public static string GetFormattedPlayerScores(List<Player> players)
        {
            string formatedPlayerScores = "";
            foreach (Player player in players)
            {
                formatedPlayerScores += string.Format("{0,-9}{1,5:D}{2,9:F2}\n", player.Name, player.NumberOfGames, player.GetAverageScore());
            }
            return formatedPlayerScores;
        }
        public static void SortPlayersByScore(List<Player> players)
        {
            players.Sort((p1, p2) => p1.GetAverageScore().CompareTo(p2.GetAverageScore()));
        }
        public static List<Player> ConvertToPlayer(List<IPlayerScore> playersDTO)
        {
            List<Player> players = new List<Player>();
            foreach (IPlayerScore playerDTO in playersDTO)
            {
                Player pd = new Player(playerDTO.Name, playerDTO.Guesses);
                int pos = players.IndexOf(pd);
                if (pos < 0)
                {
                    players.Add(pd);
                }
                else
                {
                    players[pos].Update(playerDTO.Guesses);
                }
            }
            return players;
        }

    }
}
