using CleanCodeLaboration.Model.GameDAO;
using CleanCodeLaboration.Model.GameDAO.Interface;
using CleanCodeLaboration.Model.GameLogic.Strategy.Interface;
using System.Collections.Generic;

namespace CleanCodeLaboration.Model.GameLogic.Strategy.MooGameStrategy
{
    public class MooGameStrategy : IGameStrategy
    {
        private string goal = "";
        private int numberOfGuesses = 0;
        private bool isGameActive;
        private const string gameName = "MooGame";
        private IGameDAO gameDAO;
        private string userName = "";

        public void SetGameDAO(IGameDAO gameDAO)
        {
            this.gameDAO = gameDAO;
        }
        public void ActivateGame()
        {
            isGameActive = true;
        }
        public void SetPlayerName(string userName)
        {
            this.userName = userName;
        }
        public string GenerateRandomGoal()
        {
            string goal = "";
            Random random = new Random();
            for (int i = 0; i < 4; i++)
            {
                string randomDigit = "";
                do
                {
                    randomDigit = random.Next(10).ToString();
                }
                while (goal.Contains(randomDigit));
                goal += randomDigit;
            }
            return goal;
        }
        public void SetGoal(string goal)
        {
            this.goal = goal;
        }

        public string GetGameIntroduction()
        {
            return "New game:";
        }
        public string GetRightAnswer() //Get correctAnswer?
        {
            return "For practice, number is: " + goal;
        }
        public string EvaluateGuess(string guess) //Här skulle du kunna extrahera 2 metoder som tar ut cows och ut bulls. Kanske nån generisk metod? Eller delegat där du lägger in jämförelsen.
        {
            string padding = "    ";
            int lenghtOfGoal = 4;
            int cows = 0;
            int bulls = 0;
            guess += padding;

            for (int i = 0; i < lenghtOfGoal; i++)
            {
                if (goal[i] == guess[i])
                {
                    bulls++;
                }
                else if (goal.Contains(guess[i]))
                {
                    cows++;
                }
            }
            string bullsAndCows = new string('B', bulls) + "," + new string('C', cows); //Här har vi verkligen magiska ord alla 3 saker måste extraheras.
            return bullsAndCows;
        }
        public void IncrementGuess()
        {
            numberOfGuesses++;
        }
        public bool IsCorrectGuess(string evaluatedGuess)
        {
            const string correctEvaluatedAnswer = "BBBB,";
            return evaluatedGuess == correctEvaluatedAnswer;
        }
        public void DeactivateGame()
        {
            isGameActive = false;
        }
        public void SaveGame()
        {
            IPlayerScore playerScore = new PlayerScoreDTO(userName, numberOfGuesses);
            gameDAO.SavePlayerScore(gameName, playerScore);
        }

        public bool IsGameActive()
        {
            return isGameActive;
        }

        public string GetHighScore()
        {
            string spacing = "\n";
            string highScores = "Player   games average" + spacing;
            List<Player> players = GetSortedPlayers();
            string formatedPlayers = GetFormatedPlayerScores(players);
            highScores += formatedPlayers;

            return highScores;
        }
        private List<Player> GetSortedPlayers()
        {
            List<IPlayerScore> playerScores = GetPlayerScores();
            List<Player> players = StrategyUtilitys.ConvertToPlayer(playerScores);
            StrategyUtilitys.SortPlayersByScore(players);
            return players;
        }
        private List<IPlayerScore> GetPlayerScores()
        {

            List<IPlayerScore> playerScores = gameDAO.GetAllPlayerScores(gameName);

            return playerScores;
        }
        private string GetFormatedPlayerScores(List<Player> players)
        {
            string formatedPLayerScores = StrategyUtilitys.GetFormattedPlayerScores(players);
            return formatedPLayerScores;
        }

        public string GetFinishedGameMessage()
        {
            string gameOverMessages = "Correct, it took " + numberOfGuesses + " guesses";
            return gameOverMessages;
        }

    }
}
