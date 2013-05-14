using System;
using System.Collections.Generic;

namespace Balloons_Pops_game
{
    class Balloons_Pops_game : Game
    {
        private static void checkLeft(byte[,] matrix, int row, int column, int searchedItem)
            {
                int newRow = row;
                int newColumn = column - 1;
                try
                {
                    if (matrix[newRow, newColumn] == searchedItem)
                    {
                        matrix[newRow, newColumn] = 0; checkLeft(matrix, newRow, newColumn, searchedItem);
                    }
                    else return;
                }catch(IndexOutOfRangeException)
                    {return;} 
                    
            }

        private static void checkRight(byte[,] matrix, int row, int column, int searchedItem)
        {
            int newRow = row;
            int newColumn = column + 1;
            try
            {
                if (matrix[newRow, newColumn] == searchedItem)
                {
                    matrix[newRow, newColumn] = 0;
                    checkRight(matrix, newRow, newColumn, searchedItem);
                }
                else return;
            }
            catch (IndexOutOfRangeException)
            { return; }

        }
        private static void checkUp(byte[,] matrix, int row, int column, int searchedItem)
        {
            int newRow = row+1;
            int newColumn = column ;
            try
            {
                if (matrix[newRow, newColumn] == searchedItem)
                {
                    matrix[newRow, newColumn] = 0;
                    checkUp(matrix, newRow, newColumn, searchedItem);
                }
                else return;
            }
            catch (IndexOutOfRangeException)
            { return; }
			        }

        private static void checkDown(byte[,] matrix, int row, int column, int searchedItem)
        {
            int newRow = row - 1;
            int newColumn = column;
            try
            {
                if (matrix[newRow, newColumn] == searchedItem)
                {
                    matrix[newRow, newColumn] = 0;
                    checkDown(matrix, newRow, newColumn, searchedItem);
                }
                else return;
            }
            catch (IndexOutOfRangeException)
            { return; }

        }          
        private static bool change(byte[,] matrixToModify, int rowAtm, int columnAtm)
        {
            if (matrixToModify[rowAtm, columnAtm] == 0)
            {
                 return true;
            }
            byte searchedTarget = matrixToModify[rowAtm, columnAtm];
            matrixToModify[rowAtm, columnAtm] = 0;
            checkLeft(matrixToModify, rowAtm, columnAtm, searchedTarget);
            checkRight(matrixToModify, rowAtm, columnAtm, searchedTarget);


            checkUp(matrixToModify, rowAtm, columnAtm, searchedTarget);
            checkDown(matrixToModify, rowAtm, columnAtm, searchedTarget);
            return false;
        }

        private static bool MakeAMove(byte[,] matrix)
        {
            bool isWinner = true;
            Stack<byte> stek = new Stack<byte>();
            int columnLenght = matrix.GetLength(0);
            int rowLenght = matrix.GetLength(1);
            for (int row = 0; row < rowLenght; row++)
            {
                for (int col = 0; col < columnLenght; col++)
                {
                    if (matrix[col, row] != 0)
                    {
                        isWinner = false;
                        stek.Push(matrix[col, row]);
                    }
                }

                for (int col = columnLenght - 1; col >= 0; col--)
                {
                    try
                    {
                        matrix[col, row] = stek.Pop();
                    }

                    catch (Exception)
                    {
                        matrix[col, row] = 0;
                    }
                }
            }

            return isWinner;
        }

        private static void PrintTopChart(string[,] playerResult)
        {
            var topResults = SortChart(playerResult);

            Console.WriteLine("---------TOP FIVE CHART-----------");
            for (int rank = 0; rank < topResults.Count; ++rank)
            {
                NameValuePair slot = topResults[rank];
                Console.WriteLine("{0}.   {1} with {2} moves.", rank + 1, slot.Name, slot.Value);
            }

            Console.WriteLine("----------------------------------");
        }

        private static List<NameValuePair> SortChart(string[,] playerResult)
        {
            List<NameValuePair> topResults = new List<NameValuePair>();
            for (int i = 0; i < 5; ++i)
            {
                if (playerResult[i, 0] == null)
                {
                    break;
                }

                topResults.Add(new NameValuePair(playerResult[i, 0], int.Parse(playerResult[i, 1])));
            }

            topResults.Sort();
            return topResults;
        }

        private static bool IsPlayerResultInTopFive(string[,] chart, int points)
        {
            bool isInTopFive = false;
            int worstMoves = 0;
            int worstMovesChartPosition = 0;
            for (int rank = 0; rank < 5; rank++)
            {
                if (chart[rank, 0] == null)
                {
                    EnterPlayerName(chart, rank, points);
                    isInTopFive = true;
                    break;
                }
            }

            if (isInTopFive == false)
            {
                for (int rank = 0; rank < 5; rank++)
                {
                    if (int.Parse(chart[rank, 0]) > worstMoves)
                    {
                        worstMovesChartPosition = rank;
                        worstMoves = int.Parse(chart[rank, 0]);
                    }
                }
            }

            if (points < worstMoves && isInTopFive == false)
            {
                EnterPlayerName(chart, worstMovesChartPosition, points);
                isInTopFive = true;
            }

            return isInTopFive;
        }

        private static void EnterPlayerName(string[,] chart, int rank, int points)
        {
            Console.WriteLine("Type in your name.");
            string currentPlayerName = Console.ReadLine();
            if (currentPlayerName == null)
            {
                currentPlayerName = "Anonymous";
            }
            chart[rank, 0] = points.ToString();
            chart[rank, 1] = currentPlayerName;
        }





































        public static void Main(string[] args)
        {
            string[,] topFive = new string[5,2];
            byte[,] matrix = gen(5, 10);

            printMatrix(matrix);
            string temp=null;
            int userMoves = 0;
            while (temp != "EXIT")
            {
                Console.WriteLine("Enter a row and column: ");                
                temp=Console.ReadLine();
                temp=temp.ToUpper().Trim();
                
                ProcessGame(temp, topFive, ref matrix, ref userMoves);
            }
            Console.WriteLine("Good Bye! ");
        }
  
        private static void ProcessGame(string temp, string[,] topFive, ref byte[,] matrix, ref int userMoves)
        {
            switch (temp) 
            {
                case "RESTART":
                    matrix = gen(5, 10);
                    printMatrix(matrix);
                    userMoves = 0;
                    break;
                case "TOP":
                    PrintTopChart(topFive);
                    break;
                default :
                    if ((temp.Length == 3) && (temp[0] >= '0' && temp[0] <= '9') && (temp[2] >= '0' && temp[2] <= '9') && (temp[1] == ' ' || temp[1] == '.' || temp[1] == ','))
                    {
                        int userRow, userColumn;
                        userRow = int.Parse(temp[0].ToString());
                        if (userRow > 4) 
                        {
                            Console.WriteLine("Wrong input ! Try Again ! ");
                            return;
                        }
                        userColumn = int.Parse(temp[2].ToString());
                              
                        if (change(matrix, userRow, userColumn))
                        {
                            Console.WriteLine("cannot pop missing ballon!");
                            return;
                        }
                        userMoves++;
                        if (MakeAMove(matrix))
                        {
                            Console.WriteLine("Gratz ! You completed it in {0} moves.", userMoves);
                            if (IsPlayerResultInTopFive(topFive, userMoves))
                            {
                                PrintTopChart(topFive);
                            }
                            else 
                            {
                                Console.WriteLine("I am sorry you are not skillful enough for TopFive chart!");
                            }
                            matrix = gen(5, 10);
                            userMoves = 0;
                        }
                        printMatrix(matrix);
                        break;
                    }
                    else
                    { 
                        Console.WriteLine("Wrong input ! Try Again ! ");
                        break;
                    }
            }
        }
    }
}
