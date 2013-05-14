using System;
using System.Linq;

namespace BalloonBoobsGame
{
    public class Engine
    {
        private static BalloonBoobs game = new BalloonBoobs();
        private static string[,] topFive = new string[5, 2];
        private static int userMoves = 0;

        private static byte matrixRows = 5;
        private static byte matrixCols = 10;
        private static byte[,] matrix = game.gen(matrixRows, matrixCols);

        private static int minAllowedValue = 0;
        private static int maxAllowedValue = 9;
        private static char[] separators = new char[] { ' ', '.', ',' };

        public static void ProcessGame(string userInput)
        {
            userInput = userInput.ToUpper().Trim();

            switch (userInput)
            {
                case "RESTART":
                    RestartGame();
                    break;
                case "TOP":
                    game.PrintTopChart(topFive);
                    break;
                default:
                    bool validInput = ValidateUserInput(userInput);

                    if (validInput)
                    {
                        int userRow = int.Parse(userInput[0].ToString());
                        int userCol = int.Parse(userInput[2].ToString());

                        TryToPopBoobs(userRow, userCol);

                        userMoves++;

                        if (game.MakeAMove(matrix))
                        {
                            Console.WriteLine("Gratz ! You completed it in {0} moves.", userMoves);

                            if (game.IsPlayerResultInTopFive(topFive, userMoves))
                            {
                                game.PrintTopChart(topFive);
                            }
                            else
                            {
                                Console.WriteLine("I am sorry you are not skillful enough for TopFive chart!");
                            }

                            matrix = game.gen(5, 10);
                            userMoves = 0;
                        }

                        game.printMatrix(matrix);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Wrong input! Try Again!");
                        break;
                    }
            }
        }

        private static void RestartGame()
        {
            matrix = game.gen(matrixRows, matrixCols);
            game.printMatrix(matrix);
            userMoves = 0;
        }

        private static bool ValidateUserInput(string userInput)
        {
            int row = int.Parse(userInput[0].ToString());
            int col = int.Parse(userInput[2].ToString());
            char separator = userInput[1];

            bool isInRowRange = row >= 0 && row < matrixRows;
            bool isInColRange = col >= 0 && col < matrixCols;

            bool hasValidRowValue = row >= minAllowedValue && row <= maxAllowedValue;
            bool hasValidColValue = col >= minAllowedValue && col <= maxAllowedValue;

            bool hasLenghtThree = userInput.Length == 3;
            bool hasCorrectSeparator = separator == separators[0] ||
                separator == separators[1] || separator == separators[2];

            bool isValidUserInput = isInRowRange && isInColRange &&
                hasValidRowValue && hasValidColValue &&
                hasLenghtThree && hasCorrectSeparator;
            return isValidUserInput;
        }

        private static bool TryToPopBoobs(int userRow, int userCol)
        {
            bool boobsPopped = true;

            try
            {
                game.BoobsPopper(matrix, userRow, userCol);
            }
            catch (Exception)
            {
                Console.WriteLine("cannot pop missing ballon!");
                boobsPopped = false;
            }

            return boobsPopped;
        }
    }
}
