using System;
using System.Linq;

namespace BalloonBoobsGame
{
    class Engine
    {
        private static BalloonBoobs engine = new BalloonBoobs();
        private static string[,] topFive = new string[5, 2];

        private static byte matrixRows = 5;
        private static byte matrixCols = 10;
        private static byte[,] matrix = engine.gen(matrixRows, matrixCols);

        private static char minUserInputValue = '0';
        private static char maxUserInputValue = '9';
        private static char[] separators = new char[] { ' ', '.', ',' };

        public static void ProcessGame(string userInput)
        {
            int userMoves = 0;

            switch (userInput)
            {
                case "RESTART":
                    matrix = engine.gen(matrixRows, matrixCols);
                    engine.printMatrix(matrix);
                    userMoves = 0;
                    break;
                case "TOP":
                    engine.PrintTopFiveChart(topFive);
                    break;
                default:
                    bool isValidUserInput = ValidateUserInput(userInput);
                    if (isValidUserInput)
                    {
                        int userRow = int.Parse(userInput[0].ToString());
                        if (userRow >= matrixRows)
                        {
                            Console.WriteLine("Wrong input ! Try Again ! ");
                            return;
                        }

                        int userColumn = int.Parse(userInput[2].ToString());
                        if (engine.change(matrix, userRow, userColumn))
                        {
                            Console.WriteLine("cannot pop missing ballon!");
                            return;
                        }

                        userMoves++;

                        if (engine.MakeAMove(matrix))
                        {
                            Console.WriteLine("Gratz ! You completed it in {0} moves.", userMoves);

                            if (engine.IsPlayerResultInTopFive(topFive, userMoves))
                            {
                                engine.PrintTopFiveChart(topFive);
                            }
                            else
                            {
                                Console.WriteLine("I am sorry you are not skillful enough for TopFive chart!");
                            }

                            matrix = engine.gen(5, 10);
                            userMoves = 0;
                        }

                        engine.printMatrix(matrix);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Wrong input ! Try Again ! ");
                        break;
                    }
            }
        }

        private static bool ValidateUserInput(string userInput)
        {
            bool hasCorrectRow = (userInput[0] >= minUserInputValue && userInput[0] <= maxUserInputValue);
            bool hasCorrectCol = (userInput[2] >= minUserInputValue && userInput[2] <= maxUserInputValue);
            bool hasLenghtThree = (userInput.Length == 3);
            bool hasCorrectSeparator = (userInput[1] == separators[0] ||
                userInput[1] == separators[0] || userInput[1] == separators[0]);

            bool isValidUserInput = hasCorrectRow && hasCorrectCol && hasLenghtThree && hasCorrectSeparator;
            return isValidUserInput;
        }
    }
}
