using CleanCodeLaboration.Model.GameDAO;
using CleanCodeLaboration.Model.GameDAO.Interface;
using CleanCodeLaboration.Model.GameLogic.Strategy.Interface;
using System.Collections.Generic;

namespace CleanCodeLaboration.Model.GameLogic.Strategy.MooGameStrategy
{
    public class MooGameStrategy : IGameStrategy
    {
        private const string gameName = "MooGame";
        private const int lenghtOfGoal = 4;
        private const char bull = 'B';
        private const char cow = 'C';
        private const char separator = ',';
        private string userName = "";
        private string goal = "";
        private int numberOfGuesses = 0;
        private bool isGameActive;
        private IGameDAO gameDAO;
 


        public void SetGameDAO(IGameDAO gameDAO)
        {
            this.gameDAO = gameDAO;
        }
        public void StartNewGame() //Borde denna kanske lyftas ut till GameContext och den har en metod som använder dessa? Tror det vore klokt
        {
            ActivateGame(); //Strategy nytt i interfacet
        }

        private void ActivateGame() //Ska jag ta bort denna och bara låta varje spel starta med en true?
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
            for (int i = 0; i < lenghtOfGoal; i++)
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
        public string GetEvaluatedGuess(string guess)
        {
            string bullsAndCows = EvaluateGuess(guess);//Här får du fundera på vad variabeln för B ska vara? istället för bull, bulls.
            return bullsAndCows;
        }

        private string EvaluateGuess(string guess) //EvaluateGuess?
        {
            guess = AddPadding(guess); //Vad säger man om "Add" padding? Har jag något liknande koncept men med annat "prefix"
            int cows = CountContainingNumbers(guess); //Ska det kanske vara så att calculateCow ska heta typ GetContainingNumber?
            int bulls = CountMatchingNumbers(guess); //Ska det kanske vara så att calculateCow ska heta typ GetMatchingNumber?
            string formatedAnswer = FormatGuess(cows, bulls); //Samma här, leta upp liknande koncept och välj ett ord. Har för mig att du haft Format sen tidigare.
            return formatedAnswer;
        }
        private string AddPadding(string guess)
        {
            guess += new string(' ', lenghtOfGoal);
            return guess;
        }
        private int CountContainingNumbers(string guess)
        {
            int containingNumber = 0;
            for (int i = 0; i < lenghtOfGoal; i++)
            {
                if (goal.Contains(guess[i]) && goal[i] != guess[i])
                {
                    containingNumber++;
                }
            }
            return containingNumber;
        }
        private int CountMatchingNumbers(string guess)
        {
            int matchingNumber = 0;
            for (int i = 0; i < lenghtOfGoal; i++)
            {
                if (goal[i] == guess[i])
                {
                    matchingNumber++;
                }
            }
            return matchingNumber;
        }
        private string FormatGuess(int cows, int bulls)
        {
            string formatedAnswer = new string(bull, bulls) + separator + new string(cow, cows);
            return formatedAnswer;
        }
        public void IncrementGuess()
        {
            numberOfGuesses++;
        }
        public bool IsCorrectGuess(string evaluatedGuess)
        {
            string correctEvaluatedAnswer = GetCorrectGuess();
            
            return evaluatedGuess == correctEvaluatedAnswer;
        }
        private string GetCorrectGuess()
        {
            string correctBulls = new string(bull, lenghtOfGoal);
            correctBulls += separator;
            return correctBulls;
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
