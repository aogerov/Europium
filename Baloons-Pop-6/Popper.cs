using System;

namespace Balloons
{
    public class Popper
    {
        public static void TryPopLeft(int[,] matrix, int row, int col, int searchedItem)
        {
            ValidateInput(matrix, row, col, searchedItem);

            int rowForPop = row;
            int colForPop = col - 1;

            if (colForPop >= 0)
            {
                if (matrix[rowForPop, colForPop] == searchedItem)
                {
                    matrix[rowForPop, colForPop] = 0;
                    TryPopLeft(matrix, rowForPop, colForPop, searchedItem);
                }
            }
        }

        public static void TryPopRight(int[,] matrix, int row, int col, int searchedItem)
        {
            ValidateInput(matrix, row, col, searchedItem);

            int rowForPop = row;
            int colForPop = col + 1;

            if (colForPop < matrix.GetLength(1))
            {
                if (matrix[rowForPop, colForPop] == searchedItem)
                {
                    matrix[rowForPop, colForPop] = 0;
                    TryPopRight(matrix, rowForPop, colForPop, searchedItem);
                }
            }
        }

        public static void TryPopUp(int[,] matrix, int row, int col, int searchedItem)
        {
            ValidateInput(matrix, row, col, searchedItem);

            int rowForPop = row - 1;
            int colForPop = col;

            if (rowForPop >= 0)
            {
                if (matrix[rowForPop, colForPop] == searchedItem)
                {
                    matrix[rowForPop, colForPop] = 0;
                    TryPopUp(matrix, rowForPop, colForPop, searchedItem);
                }
            }
        }

        public static void TryPopDown(int[,] matrix, int row, int col, int searchedItem)
        {
            ValidateInput(matrix, row, col, searchedItem);

            int rowForPop = row + 1;
            int colForPop = col;

            if (rowForPop < matrix.GetLength(0))
            {
                if (matrix[rowForPop, colForPop] == searchedItem)
                {
                    matrix[rowForPop, colForPop] = 0;
                    TryPopDown(matrix, rowForPop, colForPop, searchedItem);
                }
            }
        }

        public static void ValidateInput(int[,] matrix, int row, int col, int searchedItem)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException("Matrix can't have null value.");
            }

            if (row < 0 || row >= matrix.GetLength(0) ||
                col < 0 || col >= matrix.GetLength(1))
            {
                throw new IndexOutOfRangeException("Row and col indexes has to be in the range of the matrix.");
            }
        }
    }
}
