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

                try
                {
                    ProcessGame(userInput, ref matrix, chart, ref userMoves);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Wrong input! Try Again!" + ex.Message);
                }
            }
        }

        public static void ProcessGame(string userInput, ref int[,] matrix, IChart chart, ref int userMoves)
        {
            if (userInput == null || userInput == string.Empty
                || matrix == null || chart == null)
            {
                throw new ArgumentNullException("Input is null or with with empty value.");
            }

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
                    ValidateInput(userInput, matrix);
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
            if (matrix == null)
            {
                throw new NullReferenceException("Matrix input can't have null value.");
            }

            string matrixAsString = Board.AsString(matrix);
            Console.WriteLine(matrixAsString);
        }

        public static void ValidateInput(string userInput, int[,] matrix)
        {
            if (userInput == null || matrix == null)
            {
                throw new ArgumentNullException("Input can't have null value.");
            }

            if (userInput == string.Empty)
            {
                throw new ArgumentException("User input is empty.");
            }

            if (userInput.Length != 3)
            {
                throw new ArgumentException("Row and col selection should have lenght 3.");
            }

            if (userInput[0] < '0' || userInput[0] > '9')
            {
                throw new ArgumentOutOfRangeException("Row need has to be in the range 0 to 9 incl.");
            }

            if (userInput[2] < '0' && userInput[2] > '9')
            {
                throw new ArgumentOutOfRangeException("Col need has to be in the range 0 to 9 incl.");
            }

            if (!(userInput[1] != ' ' || userInput[1] != '.' || userInput[1] != ','))
            {
                throw new ArgumentException("Invalid user separator, allowed values are ' ' , ',' and '.'");
            }

            int row = int.Parse(userInput[0].ToString());
            if (row > matrix.GetLength(0))
            {
                throw new ArgumentOutOfRangeException("Row value should be lower than matrix row length.");
            }
            
            int col = int.Parse(userInput[2].ToString());
            if (col > matrix.GetLength(1))
            {
                throw new ArgumentOutOfRangeException("Col value should be lower than matrix row length.");
            }
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
