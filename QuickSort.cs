using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class QuickSort
    {

        //static void Main(string[] args)
        //{
        //    int[] arr = new int[] { 3, 6, 1, 9, 2, 8, 4 };
        //    QuickSort1(arr, 0, 6);
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

        public void Swap(int x, int y)
        {
            x ^= y ^= x ^= y;
            //int temp = x;
            //x = y;
            //y = temp;
        }
    }
}
