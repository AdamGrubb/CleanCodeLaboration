using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLaboration.View.Interface
{
    public interface IIO
    {
        void GameOutput(string gameOutput);
        string GetUserInput();
    }
}
