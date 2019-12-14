using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class DiagnolMatrix
    {
        static void printMatrixDiagonal(int[,] mat, int rows, int columns)
        {
            int i, j;
            for (int k = 0; k <= rows - 1; k++)
            {
                i = k;
                j = 0;
                while (i >= 0)
                {
                    Console.WriteLine(mat[i, j]);
                    i = i - 1;
                    j = j + 1;
                }
            }
            for (int k = 1; k <= columns - 1; k++)
            {
                i = rows - 1;
                j = k;
                while (j <= columns - 1)
                {
                    Console.WriteLine(mat[i, j]);
                    i = i - 1;
                    j = j + 1;
                }
            }
        }

        // Driver code 
        //public static void Main()
        //{
        //    int[,] mat = { { 1, 2, 3 },
        //                { 4, 5, 6 },
        //                { 7, 8, 9 } };

        //    int rows = 3;
        //    int columns = 3;
        //    printMatrixDiagonal(mat, rows, columns);
        //    Console.ReadLine();
        //}
    }
}
