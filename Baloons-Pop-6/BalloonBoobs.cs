﻿using System;
using System.Collections.Generic;

// kolko me cepi glavata, piqna sym ot vcera, sha vyrna li vodkata ili sha ya poema, dajte mi bira, da iztrezneyaaa
// test changes by Alexander
// Test - Fani

namespace BalloonBoobsGame
{
    //stupid tool
    //Balloon Boobs
    public class BalloonBoobs : Game
    {
        private void checkLeft(byte[,] matrix, int row, int column, int searchedItem)
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
            }
            catch (IndexOutOfRangeException)
            { return; }

        }

        private void checkRight(byte[,] matrix, int row, int column, int searchedItem)
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

        private void checkUp(byte[,] matrix, int row, int column, int searchedItem)
        {
            int newRow = row + 1;
            int newColumn = column;
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

        private void checkDown(byte[,] matrix, int row, int column, int searchedItem)
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

        public bool BoobsPopper(byte[,] matrixToModify, int rowAtm, int columnAtm)
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

        public void PrintTopChart(string[,] playerResult)
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
  
        private List<NameValuePair> SortChart(string[,] playerResult)
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

        public bool IsPlayerResultInTopFive(string[,] chart, int points)
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
  
        private void EnterPlayerName(string[,] chart, int rank, int points)
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
    }
}
