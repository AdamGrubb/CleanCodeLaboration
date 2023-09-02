using CleanCodeLaboration.Model.GameLogic.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLaboration.Model.GameLogic.Interface
{
    public interface IHigScoreFormatter
    {
        string FormatHighScores(List<IPlayer> players);
    }
}
