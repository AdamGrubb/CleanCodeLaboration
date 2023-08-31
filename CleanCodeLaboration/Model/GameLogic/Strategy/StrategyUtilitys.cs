using CleanCodeLaboration.Model.GameDAO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLaboration.Model.GameLogic.Strategy
{
    public static class StrategyUtilitys //Kolla upp hur man namngiver static methods så att de är förståelsebara.
    {
        public static string GetFormattedPlayerScores(List<Player> players) //GetFormattedPlayerScores? Kanske nått mer beskrivande namn.
        {
            string spacing = "\n";
            string formatedPlayerScores = "";
            foreach (Player player in players)
            {
                formatedPlayerScores += string.Format("{0,-9}{1,5:D}{2,9:F2}"+ spacing, player.Name, player.NumberOfGames, player.GetAverageScore()); //Ska du bryta ut formaten till ints eller nått? typ "int LeftOrientation = -9, osv"
            }
            return formatedPlayerScores;
        }

        public static void SortPlayersByScore(List<Player> players)
        {
            players.Sort((p1, p2) => p1.GetAverageScore().CompareTo(p2.GetAverageScore()));
        }

        public static List<Player> ConvertToPlayer(List<IPlayerScore> playersDTO)  //Ändra till till ToPLayer istället enligt sebbes slides.
        {
            List<Player> players = new List<Player>();
            foreach (IPlayerScore playerDTO in playersDTO) //Går det att bryta ut till fler metoder kanske?
            {
                Player pd = new Player(playerDTO.Name, playerDTO.Guesses); //Här har du player som Pd
                int pos = players.IndexOf(pd); //Här har du en förkortning för pos, det är icke sa nicke.
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
