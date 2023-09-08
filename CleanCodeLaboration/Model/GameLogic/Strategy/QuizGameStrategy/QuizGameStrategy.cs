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
        private IQuizQuestion quizQuestion;
        private string goal;
        private const string correctResponse = "Correct Answer!";
        private int numberOfGuesses = 0;
        private bool isGameActive;
        private IGameDAO gameDAO;
        private readonly IQuizQuestionDAO questionDAO;
        private const string gameName = "QuizGame";

        public QuizGameStrategy(IGameDAO gameDAO, IQuizQuestionDAO questionDAO)
        {
            this.gameDAO = gameDAO;
            this.questionDAO = questionDAO;
        }

        public void ActivateGame()
        {
            isGameActive = true;
        }

        public string GenerateGoal()
        {
            SetQuizQuestion();
            string goal = GetQuizAnswer();
            return goal;
        }
        private void SetQuizQuestion()
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
            const string incorrectResponse = "Incorrect Answer, try again";
            string response = CompareGuessToGoal(guess) ? correctResponse : incorrectResponse;
            return response;
        }
        private bool CompareGuessToGoal(string guess)
        {
            return goal.ToLower() == guess.ToLower();
        }

        public void IncrementGuessCount()
        {
            numberOfGuesses++;
        }

        public bool IsCorrectGuess(string evaluatedGuess)
        {
            bool isCorrect = evaluatedGuess == correctResponse;
            return isCorrect;
        }

        public void DeactivateGame()
        {
            isGameActive = false;
        }

        public string GetFinishedGameMessage()
        {
            string winMessage = "You won!! You guessed : " + numberOfGuesses + " times!";

            return winMessage;
        }

        public bool IsGameActive()
        {
            return isGameActive;
        }

        public List<IPlayerScore> GetPlayerScores()
        {

            List<IPlayerScore> playerScores = gameDAO.GetAllPlayerScores(gameName);

            return playerScores;
        }

        public string GetRightAnswer()
        {
            string rightAnswer = "The right answer is: " + goal;
            return rightAnswer;
        }

        public void SaveGame(string playerName)
        {
            gameDAO.SavePlayerScore(gameName, new PlayerScoreDTO(playerName, numberOfGuesses));
        }

        public void SetGameDAO(IGameDAO gameDAO)
        {
            this.gameDAO = gameDAO;
        }
    }
}
