using CleanCodeLaboration.View.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLaboration.View
{
    public class ConsoleView : IIO
    {
        public void GameOutput(string gameOutput)
        {
            Console.WriteLine(gameOutput);
        }

        public string GetUserInput()
        {
            return Console.ReadLine();
        }
    }
}
