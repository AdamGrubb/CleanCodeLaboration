using CleanCodeLaboration.GameDAO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLaboration.GameDAO
{
    public class PlayerDTO : IPlayer
    {
        public string Name { get; set; }
        public int Guesses { get; set ; }

        public PlayerDTO(string name, int guesses)
        {
            Name = name;
            Guesses = guesses;   
        }
    }

}
