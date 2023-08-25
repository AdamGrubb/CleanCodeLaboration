using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLaboration.Model.GameLogic.Strategy.QuizGameStrategy.QuizQuestionDAO.Interface
{
    public interface IQuizQuestionDAO
    {
        IQuizQuestion GetQuizRandomQuestion();
    }
}
