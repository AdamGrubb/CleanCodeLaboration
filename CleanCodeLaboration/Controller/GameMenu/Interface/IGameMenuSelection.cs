using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLaboration.Controller.GameMenu.Interface
{
    public interface IGameMenuSelection
    {
        string Description { get; }
        public IMenuCommand MenuCommand { get;}
    }
}
