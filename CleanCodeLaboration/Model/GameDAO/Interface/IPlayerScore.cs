using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLaboration.Model.GameDAO.Interface
{
    public interface IPlayerScore
    {
        public string Name { get; set; }
        public int Guesses { get; set; }
    }
}
