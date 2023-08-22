using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLaboration.GameLogic.Strategy
{
    public class MooGameStrategy
    {
        private string goal = ""; //Här får du avgöra om en public GenerateGoal ska finnas
        private int numberOfGuesses = 0;
        public string GetGameIntroduction()
        {
            StringBuilder introductionMessage = new StringBuilder();
            introductionMessage.Append("New game:\n");
            introductionMessage.Append("For practice, number is "+goal+"\n");
            return introductionMessage.ToString();
        }
        public string GetRandomGoal()
        {
            string goal = "";
            Random random = new Random();
            for (int i = 0; i < 4; i++)
            {
                string randomDigit = "";
                do
                {
                    randomDigit = random.Next(10).ToString();
                }
                while (goal.Contains(randomDigit));
                goal += randomDigit;
            }
            return goal;
        }
        public string GetGuessFeedback(string guess)
        {
            numberOfGuesses++;
            string bullsAndCows = CalculateBullsAndCows(guess);
            ShouldGameContinue(bullsAndCows);

            return guess + "\n\n" + bullsAndCows + "\n"; //Om man får så skulle jag vilja ta bort guess här ifrån. 
        }
        private string CalculateBullsAndCows(string guess)
        {
                string padding = "    ";
                int cows = 0;
                int bulls = 0;
                guess += padding;     // if player entered less than 4 chars.

                for (int i = 0; i < 4; i++)
                {
                    if (goal[i] == guess[i])
                    {
                        bulls++;
                    }
                    else if (goal.Contains(guess[i]))
                    {
                        cows++;
                    }
                }
                return new String('B', bulls) + "," + new String('C', cows);
        }
    }
}
