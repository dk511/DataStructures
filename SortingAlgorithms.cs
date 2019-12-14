using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class SortingAlgorithms
    {
        //Time Complixitiy - best case O(n), worst case O(n2)
        //Sort arrays with Selection method {7, 5, 4, 9}
        public void SelectionMethod(int[] A, int n)
        {
            for (int i = 0; i < n - 1; i++)
            {
                int iMin = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (A[j] < A[iMin])
                    {
                        iMin = j;
                    }
                }
                int temp = A[i];
                A[i] = A[iMin];
                A[iMin] = temp;
            }
            Console.WriteLine("{0} {1} {2} {3} {4}", A[0], A[1], A[2], A[3], A[4]);
        }

        //Time Complixitiy - best case O(n), worst case O(n2)
        public void BubbleMethod(int[] A, int n)
        {
            for (int k = 1; k < n - 1; k++)
            {
                for (int i = 0; i < n - k - 1; i++)
                {
                    if (A[i] > A[i + 1])
                    {
                        int temp = A[i + 1];
                        A[i + 1] = A[i];
                        A[i] = temp;
                    }
                }
            }
            foreach (int a in A)
            {
                Console.WriteLine(a);
            }
        }

        //Time Complixitiy - best case O(n), worst case O(n2), Avg case O(n2)
        public void InsertionMethod(int[] A, int n)
        {
            for (int i = 1; i < n; i++)
            {
                int value = A[i];
                int hole = i;
                while (hole > 0 && A[hole - 1] > value)
                {
                    int temp = A[hole - 1];
                    A[hole - 1] = A[hole];
                    A[hole] = temp;
                    hole--;
                }
                A[hole] = value;
            }
            Console.WriteLine("{0} {1} {2} {3} {4}", A[0], A[1], A[2], A[3], A[4]);
        }

        //Time complixity - worst case O(nlogn)
        //Space complisity - O(n)
        public void MergeSortMethod(int[] L, int[] R)
        {
            int nL = L.Length; int nR = R.Length;
            int[] A = new int[nL + nR];
            int i = 0; int j = 0; int k = 0;

            while (i < nL && j < nR)
            {
                if (L[i] <= R[j])
                {
                    A[k] = L[i];
                    i++;
                }
                else
                {
                    A[k] = R[j];
                    j++;
                }
                k++;
            }
            while (i < nL)
            {
                A[k] = L[i];
                k++;
                i++;
            }
            while (j < nR)
            {
                A[k] = R[j];
                k++;
                j++;
            }

            foreach (int a in A)
            {
                Console.Write(a + " ");
            }

        }

        //Time Complixity - Average case O(nlogn), Worst case O(n^2)
        public void QuickSort(int[] A, int start, int end)
        {
            if (start < end)
            {
                int pIndex = QuickSortUtil(A, start, end);
                QuickSort(A, start, pIndex - 1);
                QuickSort(A, pIndex + 1, end);
            }
        }

        public int QuickSortUtil(int[] A, int start, int end)
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
