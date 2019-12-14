using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class SubsetMatchToSum
    {
        // returns true if there is triplet 
        // with sum equal to 'sum' present 
        // in A[]. Also, prints the triplet 

        static bool Find3Numbers(int[] A,
                                     int arr_size, int sum)
        {
            // Fix the first element as A[i] 
            for (int i = 0; i < arr_size - 2; i++)
            {

                // Find pair in subarray A[i+1..n-1] 
                // with sum equal to sum - A[i] 
                HashSet<int> s = new HashSet<int>();
                int curr_sum = sum - A[i];
                for (int j = i + 1; j < arr_size; j++)
                {
                    if (s.Contains(curr_sum - A[j]))
                    {
                        Console.Write("Triplet is {0}, {1}, {2}", A[i],
                                      A[j], curr_sum - A[j]);
                        return true;
                    }
                    s.Add(A[j]);
                }
            }

            // If we reach here, then no triplet was found 
            return false;
        }
        //public static void Main()
        //{
        //    int[] A = { 1, 4, 45, 6, 10, 8 };
        //    int sum = 22;
        //    int arr_size = A.Length;

        //    Find3Numbers(A, arr_size, sum);
        //}
    }
}
