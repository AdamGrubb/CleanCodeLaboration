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
        private Random randomIndex;
        private IQuizQuestion[] quizQuestions = new IQuizQuestion[]
{
            new QuizQuestionDTO("What is the real name of the actor who played Han Solo?", "Harrison Ford" ),
            new QuizQuestionDTO("Which famous director directed 'Star Wars: A New Hope'?", "George Lucas"),
            new QuizQuestionDTO("What planet is the home of Chewbacca and the Wookiees?", "Kashyyyk"),
            new QuizQuestionDTO("Who is Luke Skywalker's twin sister?", "Princess Leia Organa"),
            new QuizQuestionDTO("What is the Sith name of Emperor Palpatine?", "Darth Sidious"),
            new QuizQuestionDTO("What color is Mace Windu's lightsaber?", "Purple"),
            new QuizQuestionDTO("What is the name of the crime lord who is the leader of the Hutt Clan?", "Jabba the Hutt"),
            new QuizQuestionDTO("What year did the first Star Wars movie come out", "1977"),
            new QuizQuestionDTO("What's the name of Boba Fett's ship?", "Slave I"),
            new QuizQuestionDTO("According to Yoda, there are always how many Sith Lords...no more, no less?", "Two"),
            new QuizQuestionDTO("On Tatooine, what name did Obi-Wan go by?", "Ben"),
            new QuizQuestionDTO("What species is Jar Jar Binks?", "Gungan"),
            new QuizQuestionDTO("Who killed Mace Windu?", "Darth Sidious"),
            new QuizQuestionDTO("Which actor played Lando Calrissian?", "Billy Dee Williams"),
            new QuizQuestionDTO("According to Luke, confronting what is the destiny of a Jedi?", "Fear"),
            new QuizQuestionDTO("What is the name of the desert planet that is home to Anakin Skywalker?", "Tatooine"),
            new QuizQuestionDTO("What is the subtitle of Episode VI in the Star Wars saga?", "Return of the Jedi"),
            new QuizQuestionDTO("What is the main weapon used by Jedi and Sith?", "Lightsaber"),
            new QuizQuestionDTO("Who trained Obi-Wan Kenobi as a Jedi?", "Qui-Gon Jinn"),
};
        public StarWarsQuestionDAO()
        {
            randomIndex = new Random();
        }

        public IQuizQuestion GetRandomQuizQuestion()
        {
            int indexOfQuestion = randomIndex.Next(0, quizQuestions.Length);
            IQuizQuestion randomQuestion = quizQuestions[indexOfQuestion];
            return randomQuestion;
        }
    }
}
