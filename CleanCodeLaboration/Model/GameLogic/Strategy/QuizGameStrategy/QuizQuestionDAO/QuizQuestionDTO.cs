using CleanCodeLaboration.Model.GameLogic.Strategy.QuizGameStrategy.QuizQuestionDAO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLaboration.Model.GameLogic.Strategy.QuizGameStrategy.QuizQuestionDAO
{
    public class QuizQuestionDTO : IQuizQuestion
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public QuizQuestionDTO(string question, string answer)
        {
            Question = question;
            Answer = answer;
        }
    }
}
