using System;
using System.Collections.Generic;

// kolko me cepi glavata, piqna sym ot vcera, sha vyrna li vodkata ili sha ya poema, dajte mi bira, da iztrezneyaaa
// test changes by Alexander
// Test - Fani

namespace BalloonBoobsGame
{
    public class BalloonBoobs : Game
    {
        public void checkLeft(byte[,] matrix, int row, int column, int searchedItem)
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

        public void checkRight(byte[,] matrix, int row, int column, int searchedItem)
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
        public void checkUp(byte[,] matrix, int row, int column, int searchedItem)
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

        public void checkDown(byte[,] matrix, int row, int column, int searchedItem)
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
                else
                {
                    return;
                }
            }

            catch (IndexOutOfRangeException)
            { 
                return; 
            }
        }

        public bool change(byte[,] matrixToModify, int rowAtm, int columnAtm)
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

        public bool MakeAMove(byte[,] matrix)
        {
            bool isWinner = true;
            Stack<byte> stek = new Stack<byte>();
            int columnLenght = matrix.GetLength(0);
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                for (int i = 0; i < columnLenght; i++)
                {
                    if (matrix[i, j] != 0)
                    {
                        isWinner = false;
                        stek.Push(matrix[i, j]);
                    }
                }

                for (int k = columnLenght - 1; k >= 0; k--)
                {
                    matrix[k, j] = stek.Pop();
                    //try
                    //{
                        //matrix[k, j] = stek.Pop();
                    //}

                    //catch (Exception)
                    //{
                    //    matrix[k, j] = 0;
                    //}
                }
            }

            return isWinner;
        }

        public void PrintTopFiveChart(string[,] playerResult)
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
            Console.WriteLine("---------TOP FIVE CHART-----------");
            for (int i = 0; i < topResults.Count; ++i)
            {
                NameValuePair slot = topResults[i];
                Console.WriteLine("{2}.   {0} with {1} moves.", slot.Name, slot.Value, i + 1);
            }
            Console.WriteLine("----------------------------------");
        }

        public bool IsPlayerResultInTopFive(string[,] Chart, int points)
        {
            bool isInTopFive = false;
            int worstMoves = 0;
            int worstMovesChartPosition = 0;
            for (int i = 0; i < 5; i++)
            {
                if (Chart[i, 0] == null)
                {
                    Console.WriteLine("Type in your name.");
                    string currentPlayerName = Console.ReadLine();
                    Chart[i, 0] = points.ToString();
                    Chart[i, 1] = currentPlayerName;
                    isInTopFive = true;
                    break;
                }
            }

            if (isInTopFive == false)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (int.Parse(Chart[i, 0]) > worstMoves)
                    {
                        worstMovesChartPosition = i;
                        worstMoves = int.Parse(Chart[i, 0]);
                    }
                }
            }

            if (points < worstMoves && isInTopFive == false)
            {
                Console.WriteLine("Type in your name.");
                string tempUserName = Console.ReadLine();
                Chart[worstMovesChartPosition, 0] = points.ToString();
                Chart[worstMovesChartPosition, 1] = tempUserName;
                isInTopFive = true;
            }

            return isInTopFive;
        }
    }
}
