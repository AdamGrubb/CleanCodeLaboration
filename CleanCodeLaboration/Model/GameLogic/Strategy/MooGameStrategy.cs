using CleanCodeLaboration.Model.GameDAO;
using CleanCodeLaboration.Model.GameDAO.Interface;
using CleanCodeLaboration.Model.GameLogic.Strategy.Interface;

namespace CleanCodeLaboration.Model.GameLogic.Strategy
{
    public class MooGameStrategy : IGameStrategy
    {
        private string goal = "";
        private int numberOfGuesses = 0;
        private bool IsGameActive { get; set; }
        private const string gameName = "MooGame";
        private IGameDAO gameDAO;
        private string userName = "";

        public void SetGameDAO(IGameDAO gameDAO)
        {
            this.gameDAO = gameDAO;
        }
        public void StartGame()
        {
            IsGameActive = true;
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

        public string GetGameIntroduction() //Här får du kolla upp, antagligen så lägger du den tillsammans med GetPracticeRun så att de blir på samma console.writeline
        {
            return "New game:\n";
        }
        public string GetPracticeRun() //Vad skulle den kunna heta?
        {
            return "For practice, number is: " + goal + "\n";
        }
        public string EvaluateGuess(string guess)
        {
            string padding = "    ";
            int lenghtOfGoal = 4;
            int cows = 0;
            int bulls = 0;
            guess += padding;     // if player entered less than 4 chars.

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
            string bullsAndCows = new string('B', bulls) + "," + new string('C', cows);
            return bullsAndCows;
        }
        public void IncrementGuess()
        {
            numberOfGuesses++;
        }
        public bool IsCorrectGuess(string evaluatedGuess)
        {
            string correctEvaluatedAnswer = "BBBB,";
            return evaluatedGuess == correctEvaluatedAnswer;
        }
        public void EndGame()
        {
            IsGameActive = false;
        }
        public void SaveGame()
        {
            IPlayerScore playerScore = new PlayerScoreDTO(userName, numberOfGuesses);
            gameDAO.SavePlayerScore(gameName, playerScore);
        }

        public bool GetGameStatus()
        {
            return IsGameActive;
        }


        public string GetHighScore()
        {
            string highScores = "Player   games average\n";
            highScores += GetPlayerTopList();

            return highScores;
        }
        private string GetPlayerTopList()
        {
            string formatedPlayerScores = "";

            List<IPlayerScore> players = gameDAO.GetAllPlayerScores(gameName);

            List<Player> highScore = ConvertToPlayer(players);

            formatedPlayerScores = FormatPlayerScores(highScore);

            return formatedPlayerScores;
        }
        private List<Player> ConvertToPlayer(List<IPlayerScore> playersDTO)
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
        private string FormatPlayerScores(List<Player> highScore)
        {
            string formatedPlayerScores = "";
            highScore.Sort((p1, p2) => p1.GetAverageScore().CompareTo(p2.GetAverageScore()));

            foreach (Player player in highScore)
            {
                formatedPlayerScores += FormatPlayer(player);
            }
            return formatedPlayerScores;
        }
        private string FormatPlayer(Player player)
        {
            return string.Format("{0,-9}{1,5:D}{2,9:F2}\n", player.Name, player.NumberOfGames, player.GetAverageScore());
        }
        public string GetFinishedGameMessage()
        {
            string gameOverMessages = "Correct, it took " + numberOfGuesses + " guesses";
            return gameOverMessages;
        }
        public string GetGoal()
        {
            return goal;
        }
    }
}
