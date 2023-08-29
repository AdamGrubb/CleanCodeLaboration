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
        string spacing = "\n";
        public void GameOutput(string gameOutput)
        {
            Console.WriteLine(gameOutput + spacing);
        }

        public string GetUserInput()
        {
            return Console.ReadLine();
        }
    }
}
