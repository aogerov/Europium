using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalloonBoobsGame
{
    public class Program
    {
        public static void Main()
        {
            string userInput = string.Empty;

            while (userInput != "EXIT")
            {
                Console.WriteLine("Enter a row and column: ");
                userInput = Console.ReadLine();

                Engine.ProcessGame(userInput);
            }

            Console.WriteLine("Good Bye! ");
        }
    }
}
