using System;
using System.Text;

namespace Balloons
{
    public class Board
    {
        public static int[,] Generate(int rows, int cols, int startValue, int endValue)
        {
            int[,] matrix = new int[rows, cols];
            Random randNumber = new Random();
            
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    int position = randNumber.Next(startValue, endValue);
                    matrix[row, col] = position;
                }
            }

            return matrix;
        }

        public static int[,] DropDownBaloons(int[,] matrix)
        {
            int rowLength = matrix.GetLength(0);
            int colLength = matrix.GetLength(1);

            int[,] newMatrix = new int[rowLength, colLength];

            for (int col = 0; col < colLength; col++)
            {
                int activeRow = rowLength - 1;

                for (int row = rowLength - 1; row >= 0; row--)
                {
                    if (matrix[row, col] != 0)
                    {
                        newMatrix[activeRow, col] = matrix[row, col];
                        activeRow--;
                    }
                }
            }

            return newMatrix;
        }

        public static string AsString(int[,] matrix)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("    ");
            for (int col = 0; col < matrix.GetLongLength(1); col++)
            {
                sb.Append(col + " ");
            }

            sb.Append("\r\n   ");
            for (int col = 0; col < ((matrix.GetLongLength(1) * 2) + 1); col++)
            {
                sb.Append("-");
            }

            sb.Append("\r\n");
            for (int i = 0; i < matrix.GetLongLength(0); i++)
            {
                sb.Append(i + " | ");
                for (int j = 0; j < matrix.GetLongLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        sb.Append("  ");
                        continue;
                    }

                    sb.Append(matrix[i, j] + " ");
                }

                sb.Append("| ");
                sb.Append("\r\n");
            }

            sb.Append("   ");
            for (int col = 0; col < ((matrix.GetLongLength(1) * 2) + 1); col++)
            {
                sb.Append("-");
            }

            sb.Append("\r\n");

            return sb.ToString();
        }
    }
}
