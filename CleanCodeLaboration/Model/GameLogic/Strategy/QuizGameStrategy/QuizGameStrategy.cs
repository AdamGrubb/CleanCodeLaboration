using CleanCodeLaboration.Model.GameDAO;
using CleanCodeLaboration.Model.GameDAO.Interface;
using CleanCodeLaboration.Model.GameLogic.Strategy.Interface;
using CleanCodeLaboration.Model.GameLogic.Strategy.QuizGameStrategy.QuizQuestionDAO;
using CleanCodeLaboration.Model.GameLogic.Strategy.QuizGameStrategy.QuizQuestionDAO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLaboration.Model.GameLogic.Strategy.QuizGameStrategy
{
    public class QuizGameStrategy : IGameStrategy
    {
        private string playerName;
        private IQuizQuestionDAO questionDAO = new StarWarsQuestionDAO();
        private IQuizQuestion quizQuestion;
        private string goal;
        private const string correctAnswerResponse = "Correct Answer!"; //Är de för långa, är "response" redundant?
        private const string incorrectAnswerResponse = "Incorrect Answer, try again";
        private int numberOfGuesses = 0;
        private bool isGameActive;
        private IGameDAO gameDAO;
        private const string gameName = "QuizGame";

        public void SetPlayerName(string playerName)
        {
            this.playerName = playerName;
        }
        public void StartNewGame()
        {
            ActivateGame();
        }

        private void ActivateGame()
        {
            isGameActive = true;
        }
        public string GenerateRandomGoal()
        {
            SetQuizQuestion();
            string goal = GetQuizAnswer();
            return goal;
        }

        private void SetQuizQuestion() //Här borde du ha en try catch.
        {
            quizQuestion = questionDAO.GetRandomQuizQuestion();
        }

        private string GetQuizAnswer()
        {
            string quizAnswer = quizQuestion.Answer;
            return quizAnswer;
        }

        public void SetGoal(string goal)
        {
            this.goal = goal;
        }

        public string GetGameIntroduction()
        {
            string question = GetQuestion();
            string introduction = "Welcome to QuizGame, the question is: " + question;
            return introduction;
        }

        private string GetQuestion()
        {
            return quizQuestion.Question;
        }

        public string GetEvaluatedGuess(string guess)
        {
            string response = CompareGuessToGoal(guess) ? correctAnswerResponse : incorrectAnswerResponse; //Är responsedelen ett noiceword?
            return response;
        }

        private bool CompareGuessToGoal(string guess)
        {
            return goal.ToLower() == guess.ToLower();
        }

        public void IncrementGuess()
        {
            numberOfGuesses++;
        }

        public bool IsCorrectGuess(string evaluatedGuess)
        {
            bool isCorrect = evaluatedGuess == correctAnswerResponse;
            return isCorrect;
        }


        public void DeactivateGame()
        {
            isGameActive = false;
        }


        public string GetFinishedGameMessage()
        {
            string winMessage = "You won!! You guessed : " + numberOfGuesses + "times!"; //winMessage är det rätt namn?

            return winMessage;
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

        public string GetRightAnswer()
        {
            string rightAnswer = "The right answer is: " + goal;
            return rightAnswer;
        }
        public void SaveGame()
        {
            gameDAO.SavePlayerScore(gameName, new PlayerScoreDTO(playerName, numberOfGuesses));
        }

        public void SetGameDAO(IGameDAO gameDAO)
        {
            this.gameDAO = gameDAO;
        }
    }
}
