using CleanCodeLaboration.Model.GameLogic.Strategy.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLaboration.Controller.GameMenu.Interface
{
    public interface IGameCommand
    {
        string Description { get; }
        void Execute();
    }
}
