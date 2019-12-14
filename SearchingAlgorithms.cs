using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class SearchingAlgorithms
    {
        //Itetrative approach - Time complexity is O(logn)
        public bool BinarySearch(int[] A, int n, int x)
        {
            int start = 0;
            int end = n - 1;

            while (start <= end)
            {
                int mid = (start + end) / 2;
                if (A[mid] == x)
                {
                    return true;
                }
                else if (x < A[mid])
                {
                    end = mid - 1;
                }
                else if (x > A[mid])
                {
                    start = mid + 1;
                }

            }

            return false;
        }

        //Recursive approach - Time complexity is O(logn)
        public bool BinarySearch(int[] A, int low, int high, int x)
        {
            
            if (low > high) return false;
            int mid = low + (high - low) / 2; //calculated this way to avoid overflow
            if (mid == x)
            {
                return true;
            }
            else if (x < A[mid])
            {
                return this.BinarySearch(A, low, mid - 1, x);
            }
            else if (x > A[mid])
            {
                return this.BinarySearch(A, mid + 1, high, x);
            }

            return false;
        }

        //A = {12, 14, 15, 21, 3, 6, 8, 9}
        //find x in circular or rotated array using binary search
        public bool CircularArrayBinarySearch(int[] A, int n, int x)
        {
            int low = 0; int high = n - 1;

            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (x == A[mid]) return true;

                if (A[mid] < A[high])
                {
                    if (x > A[mid] && x < A[high])
                        low = mid + 1;
                    else
                        high = mid - 1;

                }
                if (A[low] < A[mid])
                {
                    if (x > A[low] && x < A[mid])
                        high = mid - 1;
                    else
                        low = mid + 1;
                }
            }

            return false;
        }

        //Interpolation search is the improvement version of the Binary Search
        public int InterpolationSearch(int[] A, int n, int x)
        {
            int start = 0; int end = n - 1; int pos;

            while (start < end && x >= A[start] && x <= A[end])
            {
                pos = start + (((int)(end - start) / (A[end] - A[start])) * (x - A[start]));
                //decimal pos1 = ((decimal)(6 - 0)/(17 - 3));
                if (A[pos] == x) return pos;

                if (x > A[pos])
                    start = pos + 1;
                else
                    end = pos - 1;
            }
            return -1;
        }
    }
}
