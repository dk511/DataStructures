using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

class GFG
{

    //static void printMatrixDiagonal(int[,] mat, int rows, int columns)
    //{
    //    int i, j;
    //    for(int k = 0;k<=rows-1; k++)
    //    {
    //        i = k;
    //        j = 0;
    //        while(i>=0)
    //        {
    //            Console.WriteLine(mat[i,j]);
    //            i = i - 1;
    //            j = j + 1;
    //        }
    //    }
    //    for (int k = 1; k <= columns - 1; k++)
    //    {
    //        i = rows-1;
    //        j = k;
    //        while (j <= columns-1)
    //        {
    //            Console.WriteLine(mat[i, j]);
    //            i = i - 1;
    //            j = j + 1;
    //        }
    //    }
    //}

    //// Driver code 
    //public static void Main()
    //{
    //    string inp = "hai how are you?";
    //    StringBuilder strb = new StringBuilder();
    //    List<char> charlist = new List<char>();
    //    for (int c = 0; c < inp.Length; c++)
    //    {

    //        if (inp[c] == ' ' || c == inp.Length - 1)
    //        {
    //            if (c == inp.Length - 1)
    //                charlist.Add(inp[c]);
    //            for (int i = charlist.Count - 1; i >= 0; i--)
    //                strb.Append(charlist[i]);

    //            strb.Append(' ');
    //            charlist = new List<char>();
    //        }
    //        else
    //            charlist.Add(inp[c]);
    //    }
    //    string output = strb.ToString();
    //}

    public static void QuickSort1(int[] A, int start, int end)
    {
        if (start < end)
        {
            int pIndex = QuickSortUtil(A, start, end);
            QuickSort1(A, start, pIndex - 1);
            QuickSort1(A, pIndex + 1, end);
        }
    }

    public static int QuickSortUtil(int[] A, int start, int end)
    {
        int pIndex = start;
        int pivot = A[end];

        for (int i = start; i < end; i++)
        {
            if (A[i] <= pivot)
            {
                int temp = A[pIndex];
                A[pIndex] = A[i];
                A[i] = temp;

                pIndex++;
            }
        }

        int temp1 = A[end];
        A[end] = A[pIndex];
        A[pIndex] = temp1;

        return pIndex;
    }

    static void Main(string[] args)
    {
        int[] arr = new int[] { 8, 4, 3,9, 6, 11 };
        QuickSort1(arr, 0, arr.Length - 1);
    }
}