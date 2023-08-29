using CleanCodeLaboration.Model.GameLogic.Strategy.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLaboration.Model.GameMenu.Interface
{
    public interface ICommand
    {
        string Description { get; }
        IGameStrategy Execute();
    }
}
