﻿using CleanCodeLaboration.Model.GameDAO;
using CleanCodeLaboration.Model.GameDAO.Interface;
using CleanCodeLaboration.Model.GameLogic.Strategy.Interface;
using System.Collections.Generic;

namespace CleanCodeLaboration.Model.GameLogic.Strategy.MooGameStrategy
{
    public class MooGameStrategy : IGameStrategy
    {
        private const string gameName = "MooGame";
        private const int lenghtOfGoal = 4;
        private const char bullCharacter = 'B';
        private const char cowCharacter = 'C';
        private const char separator = ','; //Seperator? Lite oklart vad den ska användas för?
        private string playerName = string.Empty;
        private string goal;
        private int numberOfGuesses = 0;
        private bool isGameActive;
        private IGameDAO gameDAO;
 


        public void SetGameDAO(IGameDAO gameDAO)
        {
            this.gameDAO = gameDAO;
        }

        public void ActivateGame()
        {
            isGameActive = true;
        }
        public void SetPlayerName(string playerName)
        {
            this.playerName = playerName;
        }
        public string GenerateGoal()
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
            const string newGame = "New game:";
            return newGame;
        }
        public string GetRightAnswer() //Liite svajjig är detta metodnamn. GetCorrectAnswer kanske bättre?
        {
            string rightAnswer = "For practice, number is: " + goal;
            return rightAnswer;
        }
        public string GetEvaluatedGuess(string guess)
        {
            string bullsAndCows = EvaluateGuess(guess);
            return bullsAndCows;
        }

        private string EvaluateGuess(string guess)
        {
            guess = EnsureGuessLenght(guess);
            int cows = CountContainingNumbers(guess);
            int bulls = CountMatchingNumbers(guess);
            string formatedAnswer = FormatGuess(cows, bulls); //Lite osäker på denna
            return formatedAnswer;
        }
        private string EnsureGuessLenght(string guess)
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
            string formatedAnswer = new string(bullCharacter, bulls) + separator + new string(cowCharacter, cows);
            return formatedAnswer;
        }
        public void IncrementGuessCount()
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
            string correctBulls = new string(bullCharacter, lenghtOfGoal);
            correctBulls += separator;
            return correctBulls;
        }
        public void DeactivateGame()
        {
            isGameActive = false;
        }
        public void SaveGame()
        {
            IPlayerScore playerScore = new PlayerScoreDTO(playerName, numberOfGuesses);
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
            string formattedPlayersScores = GetFormattedPlayerScores(players);
            highScores += formattedPlayersScores;

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
        private string GetFormattedPlayerScores(List<Player> players)
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
