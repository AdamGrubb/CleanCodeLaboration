using CleanCodeLaboration.Model.GameDAO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace CleanCodeLaboration.Model.GameDAO
{
    public class PlayerScoreDTO : IPlayerScore
    {
        public string Name { get; set; }
        public int Guesses { get; set; }

        public PlayerScoreDTO(string name, int guesses)
        {
            Name = name;
            Guesses = guesses;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            PlayerScoreDTO other = (PlayerScoreDTO)obj;
            return Name == other.Name && Guesses == other.Guesses;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Guesses);
        }
    }

}
