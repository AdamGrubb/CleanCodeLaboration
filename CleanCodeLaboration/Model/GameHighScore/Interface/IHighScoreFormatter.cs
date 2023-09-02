using CleanCodeLaboration.Model.GameDAO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLaboration.Model.GameHighScore.Interface
{
    public interface IHighScoreFormatter
    {
        string FormatHighScores(List<IPlayerScore> players);
    }
}
