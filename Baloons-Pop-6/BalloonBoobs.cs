﻿using System;
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
                else return;
            }
            catch (IndexOutOfRangeException)
            { return; }

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
            for (int j=0;j<matrix.GetLength(1) ;j++ )
            {
                for (int i = 0; i < columnLenght; i++)
                {
                    if(matrix[i,j]!=0)
                    {
                        isWinner = false;
                        stek.Push(matrix[i, j]);
                    }                        
                }
                for (int k = columnLenght-1; (k >= 0); k--)
                {
                    try
                    {
                        matrix[k, j] = stek.Pop(); 
                    }
                    catch (Exception)
                    {
                        matrix[k, j] = 0;
                    }
                }
            }
                return isWinner;
        }

        public void sortAndPrintChartFive(string[,] tableToSort)
        {
            
            List<NameValuePair> klasirane = new List<NameValuePair>();

            for (int i = 0; i < 5; ++i)
            {
                if (tableToSort[i, 0] == null) 
                { 
                    break; 
                }
                
                klasirane.Add(new NameValuePair(tableToSort[i, 0],int.Parse(tableToSort[i,1])));
               
            }
            
            klasirane.Sort();
            Console.WriteLine("---------TOP FIVE CHART-----------");
            for (int i = 0; i<klasirane.Count; ++i)
            {
                NameValuePair slot = klasirane[i];
                Console.WriteLine("{2}.   {0} with {1} moves.", slot.Name, slot.Value,i+1);
            }
            Console.WriteLine("----------------------------------");

            
        }

        public bool signIfSkilled(string[,] Chart, int points) 
        {
            bool Skilled = false;
            int worstMoves=0;
            int worstMovesChartPosition=0;
            for (int i = 0; i < 5; i++)
            {      
                if (Chart[i, 0] == null)
                {
                    Console.WriteLine("Type in your name.");
                    string tempUserName = Console.ReadLine();
                    Chart[i, 0] = points.ToString();
                    Chart[i, 1] = tempUserName;
                    Skilled = true;
                    break;
                 }
            }
            if (Skilled == false) 
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
            if (points < worstMoves && Skilled == false) 
            {
                Console.WriteLine("Type in your name.");
                string tempUserName = Console.ReadLine();
                Chart[worstMovesChartPosition, 0] = points.ToString();
                Chart[worstMovesChartPosition, 1] = tempUserName;
                Skilled = true;
            }
            return Skilled;
        }
    }
}
