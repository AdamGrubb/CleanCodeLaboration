using CleanCodeLaboration.Model.GameLogic.Strategy.QuizGameStrategy.QuizQuestionDAO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLaboration.Model.GameLogic.Strategy.QuizGameStrategy.QuizQuestionDAO
{
    public class StarWarsQuestionDAO : IQuizQuestionDAO
    {
        private IQuizQuestion[] quizQuestions = new IQuizQuestion[]
        {
            new QuizQuestionDTO("What is the real name of the actor who played Han Solo?", "Harrison Ford" ),
            new QuizQuestionDTO("Which famous director directed 'Star Wars: A New Hope'?", "George Lucas"),
            new QuizQuestionDTO("What planet is the home of Chewbacca and the Wookiees?", "Kashyyyk"),
            new QuizQuestionDTO("Who is Luke Skywalker's twin sister?", "Princess Leia Organa"),
            new QuizQuestionDTO("What is the Sith name of Emperor Palpatine?", "Darth Sidious"),
            new QuizQuestionDTO("What color is Mace Windu's lightsaber?", "Purple"),
            new QuizQuestionDTO("What is the name of the crime lord who is the leader of the Hutt Clan?", "Jabba the Hutt"),
        };

        public IQuizQuestion GetQuizRandomQuestion()
        {
            Random randomIndex = new Random();
            int indexOfQuestion = randomIndex.Next(0, quizQuestions.Length);
            IQuizQuestion randomQuestion = quizQuestions[indexOfQuestion];
            return randomQuestion;

        }
    }
}
