using CleanCodeLaboration.Model.GameDAO.Interface;
using CleanCodeLaboration.Model.GameHighScore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLaboration.Model.GameHighScore
{
    public class HighScoreFormatter : IHighScoreFormatter
    {
        public string FormatHighScores(List<IPlayerScore> playerScores)
        {
            string spacing = "\n";
            string highScores = "Player   games average" + spacing;
            List<IPlayer> players = ConvertToPlayer(playerScores);
            string formattedPlayersScores = GetFormattedPlayerScores(players);
            highScores += formattedPlayersScores;
            return highScores;
        }
        private string GetFormattedPlayerScores(List<IPlayer> players)
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
        public List<IPlayer> ConvertToPlayer(List<IPlayerScore> playerScores)
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
