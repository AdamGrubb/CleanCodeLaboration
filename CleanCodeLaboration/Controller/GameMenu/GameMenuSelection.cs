using CleanCodeLaboration.Controller.GameMenu.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLaboration.Controller.GameMenu
{
    public class GameMenuSelection : IGameMenuSelection
    {
        private readonly string description;
        private readonly IMenuCommand menuCommand;

        public GameMenuSelection(string description, IMenuCommand menuCommand)
        {
            this.description = description;
            this.menuCommand = menuCommand;
        }
        public string Description
        {
            get { return description; }
        }

        public IMenuCommand MenuCommand
        {
            get { return menuCommand; }
        }
    }
}
