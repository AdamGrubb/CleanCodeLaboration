using CleanCodeLaboration.Model.GameDAO.Interface;
using CleanCodeLaboration.Model.GameLogic.Interface;
using CleanCodeLaboration.Model.GameLogic.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLaboration.Model.GameLogic
{
    public class HigScoreFormatter : IHigScoreFormatter
    {
        public string FormatHighScores(List<IPlayer> players)
        {
            string spacing = "\n";
            string highScores = "Player   games average" + spacing;
            
            string formattedPlayersScores = GetFormattedPlayerScores(players);
            highScores += formattedPlayersScores;
            return highScores;
        }
        private  string GetFormattedPlayerScores(List<IPlayer> players)
        {
            List<IPlayer> sortedPlayers = SortPlayerByScore(players);
            string playerScores = FormatResult(sortedPlayers);
            return playerScores;
        }
        private List<IPlayer> SortPlayerByScore(List<IPlayer> players)
        {
            List<IPlayer> sortedPlayers = new List<IPlayer>(players);
            sortedPlayers.Sort((p1, p2) => p1.GetAverageScore().CompareTo(p2.GetAverageScore()));
            return sortedPlayers;
        }
        private string FormatResult(List<IPlayer> players)
        {
            string spacing = "\n";
            string formatedPlayerScores = "";
            foreach (Player player in players)
            {
                formatedPlayerScores += string.Format("{0,-9}{1,5:D}{2,9:F2}" + spacing, player.Name, player.NumberOfGames, player.GetAverageScore()); //Ska du bryta ut formaten till ints eller nått? typ "int LeftOrientation = -9, osv"
            }
            return formatedPlayerScores;
        }
        public static List<Player> ConvertToPlayer(List<IPlayerScore> playersDTO)
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
