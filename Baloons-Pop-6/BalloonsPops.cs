using System;
using System.Linq;

namespace Balloons
{
    public class BalloonsPops
    {
        public static void Main()
        {
            GameExecutor();
        }

        public static void GameExecutor()
        {
            IChart chart = new Chart();
            int[,] matrix = GenerateBoard();
            PrintBoard(matrix);
            int userMoves = 0;
            string userInput = string.Empty;

            while (userInput != "EXIT")
            {
                Console.WriteLine("Enter a row and column: ");
                userInput = Console.ReadLine();
                userInput = userInput.ToUpper().Trim();
                ProcessGame(userInput, ref matrix, chart, ref userMoves);
            }
        }

        public static void ProcessGame(string userInput, ref int[,] matrix, IChart chart, ref int userMoves)
        {
            switch (userInput)
            {
                case "RESTART":
                    matrix = GenerateBoard();
                    PrintBoard(matrix);
                    userMoves = 0;
                    break;

                case "TOP":
                    chart.PrintChart();
                    break;

                case "EXIT":
                    Console.WriteLine("Good Bye!");
                    break;

                default:
                    bool isValidInput = ValidateInput(userInput, matrix);
                    if (isValidInput)
                    {
                        userMoves++;

                        bool baloonExists = CheckForBaloon(userInput, matrix);
                        if (baloonExists)
                        {
                            PopBaloons(userInput, ref matrix);
                        }
                        else
                        {
                            Console.WriteLine("Cannot pop missing ballon!");
                        }

                        bool allBaloonsArePoped = CheckForGameOver(matrix);
                        if (allBaloonsArePoped)
                        {
                            Console.WriteLine("Gratz! You completed it in {0} moves.", userMoves);

                            bool isForChart = chart.GoodEnoughForChart(userMoves);
                            if (isForChart)
                            {
                                chart.AddToChart(userMoves);
                                chart.SortChart();
                                chart.PrintChart();
                            }
                            else
                            {
                                Console.WriteLine("I am sorry you are not skillful enough for TopFive chart!");
                            }

                            matrix = GenerateBoard();
                            userMoves = 0;
                        }

                        PrintBoard(matrix);
                        break;
                    }
                    else
                    {
                        //throw exeption
                        Console.WriteLine("Wrong input! Try Again!");
                        break;
                    }
            }
        }

        public static int[,] GenerateBoard()
        {
            int rows = 5;
            int cols = 10;
            int startValue = 1;
            int endValue = 5;

            int[,] matrix = Board.Generate(rows, cols, startValue, endValue);

            return matrix;
        }

        public static void PrintBoard(int[,] matrix)
        {
            string matrixAsString = Board.AsString(matrix);
            Console.WriteLine(matrixAsString);
        }

        public static bool ValidateInput(string userInput, int[,] matrix)
        {
            bool isValid = true;

            if (userInput.Length != 3)
            {
                isValid = false;
            }

            if (userInput[0] < '0' || userInput[0] > '9')
            {
                isValid = false;
            }

            if (userInput[2] < '0' && userInput[2] > '9')
            {
                isValid = false;
            }

            if (!(userInput[1] != ' ' || userInput[1] != '.' || userInput[1] != ','))
            {
                isValid = false;
            }

            if (isValid)
            {
                int row = int.Parse(userInput[0].ToString());
                int col = int.Parse(userInput[2].ToString());

                if (row > matrix.GetLength(0) || col > matrix.GetLength(1))
                {
                    isValid = false;
                }
            }

            return isValid;
        }

        public static bool CheckForBaloon(string userInput, int[,] matrix)
        {
            int row = int.Parse(userInput[0].ToString());
            int col = int.Parse(userInput[2].ToString());
            bool baloonExists = true;

            if (matrix[row, col] == 0)
            {
                baloonExists = false;
            }

            return baloonExists;
        }

        public static void PopBaloons(string userInput, ref int[,] matrix)
        {
            int row = int.Parse(userInput[0].ToString());
            int col = int.Parse(userInput[2].ToString());
            int searchedTarget = matrix[row, col];
            matrix[row, col] = 0;

            Popper.TryPopLeft(matrix, row, col, searchedTarget);
            Popper.TryPopRight(matrix, row, col, searchedTarget);
            Popper.TryPopUp(matrix, row, col, searchedTarget);
            Popper.TryPopDown(matrix, row, col, searchedTarget);

            matrix = Board.DropDownBaloons(matrix);
        }

        public static bool CheckForGameOver(int[,] matrix)
        {
            bool isWinner = true;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] != 0)
                    {
                        return false;
                    }
                }
            }

            return isWinner;
        }
    }
}
