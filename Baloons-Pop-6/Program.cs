using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalloonBoobsGame
{
    class Program
    {
        public static void Main(string[] args)
        {

            string userInput = string.Empty;

            while (userInput != "EXIT")
            {
                Console.WriteLine("Enter a row and column: ");
                userInput = Console.ReadLine();
                userInput = userInput.ToUpper().Trim();

                Engine.ProcessGame(userInput);
            }
            Console.WriteLine("Good Bye! ");
        }
    }
}
