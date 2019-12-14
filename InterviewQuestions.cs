using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class InterviewQuestions
    {
         //find if string has all unique characters
        public bool isUnique(string s)
        {
            int[] count = new int[128];

            foreach(char c in s)
            {
                if (++count[c] > 1)
                    return false;
            }

            return true;
        }

        //Given two sorted arrays, A and B, where A has a large enough buffer at the end to hold B.
        //Merge B into A in sorted order
        //int[] L = { 1, 3, 5, null, null, null, null };
        //int[] R = { 2, 4, 6, 9 };
        public void MergeArray(int[] L, int[] R)
        {
            int m = L.Length; int n = R.Length; int k = 2;
            int i = m - 1; int j = n - 1;
            int lastIndex = k + n -1;
            
            while (j >= 0)
            {
                if (L[k] > R[j])
                {
                    L[lastIndex] = L[k];
                    k--;
                }
                else
                {
                    L[lastIndex] = R[j];
                    j--;
                }
                lastIndex--;
            }


            //for(int k =0; k < m; k++)
            //{
            //    Console.Write(L[k] + " ");
            //}
        }

        //Given a sorted array of strings which is intersepted with empty strings, 
        //Input :  arr[] =  {"for", "", "", "", "geeks", "ide", "", "practice", "" , "", "quiz", "", ""};
        // str = "quiz"
        //Output :   10
        //write a method to find the location of a given string
        public int FindString(string[] A, string x)
        {
            int n = A.Length; int start = 0; int end = n - 1;
            while(start <= end)
            {
                int mid = (start + end) / 2;
                if (A[mid] == "") mid = setMid(A, mid);

                if (A[mid] == x) return mid;
                if (A[mid].CompareTo(x) > 0) end = mid - 1;
                if (A[mid].CompareTo(x) < 0) start = mid + 1;                    
            }
            return - 1;
        }

        int setMid(string[] A, int mid)
        {
            int start = 0; int end = A.Length - 1;
            //if (A[mid] == "")
            //{
                int left = mid - 1; int right = mid + 1;
                while (true)
                {
                    if (left < start && right > end) return -1;
                    if (right <= end && A[right] != "")
                    {
                        mid = right;
                        return mid;
                    }
                    if (left >= start && A[left] != "")
                    {
                        mid = left;
                        return mid;
                    }
                    left--;
                    right++;
                }
            //}
            //return mid;
        }
        
        //below solution does not handle empty string, Above solution handles empty strings
        public int FindStrings(string[] A, int n, string x)
        {
            int low = 0; int high = n - 1;
            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (A[mid] == x)
                    return mid;
                else if (A[mid].CompareTo(x) > 0)
                    high = mid - 1;
                else if (A[mid].CompareTo(x) < 0)
                    low = mid + 1;
            }

            return -1;
        }
        
        //Find triplate whos XOR is 0
        public int FindTriplate(int[] A)
        {
            int n = A.Length; int count = 0;
            HashSet<int> hset = new HashSet<int>();
            for(int i = 0; i < n; i++)
            {
                hset.Add(A[i]);
            }
            // { 4, 7, 5, 8, 3, 9 };
            for (int i=0; i < n; i++)
            {
                for(int j = i + 1; j < n; j++)
                {
                    int xor = A[i] ^ A[j];

                    if (hset.Contains(xor) && xor != A[i] && xor != A[j])
                        count++;
                }
            }
            return count/3;
        }

        //Wirte function to rearrange array in O(1) space
        //Input : arr[] = {1, 3, 5, 7, 2, 4, 6, 8}
        //Output : {1, 2, 3, 4, 5, 6, 7, 8}
        public void Rearrange(int[] A)
        {
            int n = A.Length; int midIndex = (n -1) / 2;

            while (midIndex > 0)
            {
                int count = midIndex;
                int swapIndex = midIndex;
                while(count-- > 0)
                {
                    int temp = A[swapIndex + 1];
                    A[swapIndex + 1] = A[swapIndex];
                    A[swapIndex] = temp;
                    swapIndex++;
                  //Console.WriteLine(A[swapIndex + 1] + "  " + A[swapIndex]);
                }
                midIndex--;
            }
        }
        
        //find missing number from array
        public int FindMissingNumber(int[] A, int n)
        {
            int total = (n + 1) * (n + 2) / 2;
            for(int i = 0; i < n; i++)
                total = total - A[i];

            return total;
        }

        //Find duplicates in int array
        public void FindDuplicates(int[] A, int n)
        {
            HashSet<int> hset = new HashSet<int>();
            for (int i = 0; i < n; i++)
                if (!hset.Add(A[i]))
                    Console.Write(A[i] + " ");
        }
        
        //check if number exist in array
        public bool CheckNumber(int[] A, int n, int x)
        {
            HashSet<int> hset = new HashSet<int>(A);

            if (hset.Contains(x))
                return true;

            return false;
        }

        //Find two number from array whos sum is equal to x
        public void FindPairwithSum(int[] A, int n, int x)
        {
            //SortingAlgorithms sa = new SortingAlgorithms();
            //sa.QuickSort(A, 0, n - 1);
            //int l = 0; int r = n - 1;

            //This solution has Time complixity of O(n^2)
            //for(int i = 0; i < n; i++)
            //{
            //    int first = A[i];
            //    for(int j= i+1; j<n; j++)
            //    {
            //        int second = A[j];

            //        if(first + second == x)
            //            Console.WriteLine(first + " " + second);
            //    }
            //}

            //this solution require O(n) time
            HashSet<int> hset = new HashSet<int>();
            foreach(int i in A)
            {
                int y = x - i;
                if (hset.Contains(y))
                    Console.Write("{" + y + " " + i + "} ");
                else
                    hset.Add(i);
            }       
        }

        public void FindDivisors(int n)
        {
            for(int i = 1; i< Math.Sqrt(n) + 1; i++)
            {
                if (n%i == 0)
                    if(n/i == i)
                    {
                        Console.Write(i);
                    }
                    else
                    {
                        Console.Write(i + ", " + n / i + ", ");
                    }
                        
            }
        }

        //inverse the array position
        //input {2, 3, 4, 5, 1} 
        //output {5, 1, 2, 3, 4 }
        public void InversePosition(int[] A, int n)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            for(int i = 1; i < n+1; i++)
            {
                dic.Add(A[i-1], i);
                
            }
            for(int i = 0; i < n; i++)
            {
                A[i] = dic[i+1];
            }            
        }

        public void PrintSubset(char[] A)
        {
            //to handle duplicates - remove duplicates by calling method to remove duplicates
            int n = A.Length;
            for(int i = 0; i< (1<<n); i++)
            {
                Console.Write("{");

                for(int j = 0; j<n; j++)
                {
                    if((i & (1 << j)) > 0)
                    {
                        Console.Write(A[j] + " ");
                    }
                }
                Console.WriteLine("}");
            }
        }

        //Reverse the digit with handling overflow
        public int ReverseDigit(int num)
        {
            bool negativeFlag = false;
            if (num < 0)
            {
                negativeFlag = true;
                num = -num;
            }
            int pre_rev_num = 0; int rev_num = 0;
            while(num != 0)
            {
                int curr_digit = num % 10; // 
                rev_num = (rev_num * 10) + curr_digit;
                if((rev_num-curr_digit)/10 != pre_rev_num)
                {
                    Console.WriteLine("Warning Overflow !...");
                    return 0;
                }
                pre_rev_num = rev_num;
                num = num / 10;
            }
            return (negativeFlag == true) ? -rev_num : rev_num;
        }

        //Create ATOI
        public int MyAtoi(string str)
        {
            if (str == null) return 0;
            str = str.Trim();
            int result = 0; int sign = 1; int i = 0;
            if (str[0] == '-')
            {
                sign = -1;
                i++;
            }
            if (str[0] == '+')
            {
                sign = 1;
                i++;
            }
            
            for (; i < str.Length; ++i)
            {
                if (isNumeric(str[i]) == false) return 0;
                else
                    result = result * 10 + str[i] - '0';
            }

            //result = sign * result;
            if (result >= int.MaxValue) return int.MaxValue;
            if (result <= int.MinValue) return int.MinValue;

            return sign*result;
        }

        public bool isNumeric(char x)
        {
            return (x >= '0' && x <= '9') ? true : false;
        }

        public int LengthOfLongestSubstring(string input)
        {
            int n = input.Length; int max = 0; int i = 0; int j = 0;
            HashSet<char> hset = new HashSet<char>();

            while (j < n)
            {
                if (!hset.Contains(input[j]))
                {
                    hset.Add(input[j]);
                    j++;
                    max = Math.Max(max, j - i);
                }
                else
                {
                    hset.Remove(input[i]);
                    i++;
                }
            }
            return max;
        }

        //Reverse Array - this is not the best solution in terms of time complixity
        public void ReverseArray(int[] A)
        {
            int n = A.Length;
            for (int strt = 0, end = n - 1; strt <= end; strt++, end--)
            {
                int temp = A[strt];
                A[strt] = A[end];
                A[end] = temp;
            }
        }

        //maximum Water problem - given an array A = {3, 1, 2, 4, 5} - form a container like rectanlge on X and Y coordinate such that
        //it whould accomodate max water - Anser to above array is = 12
        public int FindMaxArea(int[] A)
        {
            int n = A.Length;
            int start = 0; int end = n - 1; int result = 0;
            while(start < end)
            {
                result = Math.Max(result, (end - start) * Math.Min(A[start], A[end]));
                //if (A[start] < A[end] || A[start] == A[end])
                if (A[start] <= A[end])
                {
                    start++;
                    continue;
                }
                if (A[start] > A[end])
                {
                    end--;
                    continue;
                }
            }
            return result;
        }

        //util function for parenthesis 
        private bool isMatchingPair(string str1, string str2)
        {
            if (str1 == "{" && str2 == "}") return true;
            else if (str1 == "(" && str2 == ")") return true;
            else if (str1 == "[" && str2 == "]") return true;

            return false;
        }

        public bool areParenthesisBalanced(string[] A)
        {
            int n = A.Length;
            Stack<string> stack = new Stack<string>();

            for(int i = 0; i < n; i++)
            {
                if(A[i] == "{" || A[i] == "(" || A[i] == "[")
                {
                    stack.Push(A[i]);
                }
                if (A[i] == "]" || A[i] == ")" || A[i] == "}")
                {
                    if (stack.Count == 0) return false;
                    else if (!isMatchingPair(stack.Pop(), A[i]))
                        return false;
                }
            }
            if (stack.Count == 0)
                return true;
            else
                return false;

        }

        //product of an array like  [1,2,3,4], return [24,12,8,6]
        //public int[] ProductOfArray(int[] A)
        //{
        //    int n = A.Length;
        //    for(int i = 0; i < n-1; i++)
        //    {

        //    }

        //}

            //answer is wrong
        //find pow(x,n) = x^n = pow(2, 3) = 2^3 = 8

        //find the power of x
        public int pow(int x, int n)
        {
            if (n == 0) return 1;
            int temp = pow(x, n / 2);
            if (n % 2 == 0)
                return temp * temp;
            else
                return x * temp * temp;
        }

        //Find max addition element of the array like [3, 5, 6, 1] = 5, 6
        //O(n) - this can be further improved
        public int maxSubArray(int[] A)
        {
            int n = A.Length; int start = 0; int end = n - 1;
            int result = 0;
            while(start < end)
            {
                result = Math.Max(result, A[start] * A[end]);
                if (A[start] < A[end]) start++;
                else end--;
            }
            return result;
        }

        //BElow DP solution need change in logic
        //[3, 5, 6, 1] 
        public int MaxSubArray_Dp(int[] A)
        {
            int n = A.Length;
            int max_by_far = A[0];
            int max_curr = A[0];

            for(int i = 1; i < n; i++)
            {
                max_curr = Math.Max(A[i], max_curr * A[i]);
                max_by_far = Math.Max(max_by_far, max_curr);
            }
            return max_by_far;

        }

        public void PrintFactors(int n)
        {
            //for(int i = 2; i < n/2; i+=2)
            //{
            //    if(n % i == 0)
            //    {
            //        int j = n / i;
            //        Console.WriteLine(j + " * " + i);
            //        //PrintFactors(i)
            //    }
            //}
            int temp = 0;
            for (int i = n - 1; i >= n / 2; i--)
            {
                if (n % i == 0)
                {
                    temp = n / i;
                    Console.WriteLine(temp + " * " + i);
                    if (IsPrime(i) == false)
                    {
                        Console.WriteLine(temp + " * ");
                        PrintFactors(i);
                    }
                }
            }
        }

        public bool IsPrime(int number)
        {   
            if (number == 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            //var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= (int)Math.Sqrt(number); i += 2)
            {
                if (number % i == 0) return false;
            }

            return true;
        }

        public void PrintArray(int[] A)
        {
            int n = A.Length;
            for(int i = 0; i < n; i++)
                Console.Write(A[i] + " ");
        }

        public void FindAllPrimeFactors(int n)
        {
            while(n%2 == 0)
            {
                Console.Write(2 + " ");
                n /= 2;
            }

            for(int i = 3; i <= Math.Sqrt(n); i += 2)
            {
                while (n % i == 0)
                {
                    Console.Write(i + " ");
                    n /= i;
                }
            }

            if(n > 2)
                Console.Write(n);
        }

        //Active and Inactive cells after k Days
        //Given a binary array of size n where n > 3. A true (or 1) value in the array means 
        //active and false (or 0) means inactive.Given a number k, the task is to find 
        //count of active and inactive cells after k days.After every day, status of i’th cell 
        //becomes active if left and right cells are not same and inactive if left and right 
        //cell are same (both 0 or both 1).
        //Since there are no cells before leftmost and after rightmost cells, 
        //the value cells before leftmost and after rightmost cells is always considered as 0 (or inactive
        public void CellCompetes(int[] states, int days)
        {
            int n = states.Length;
            int start = 0; int end = 0;
            int[] temp = new int[n];
            for(int j = 1; j<=days; j++)
            {
                for (int i = 0; i <= n; i++)
                {
                    if(i == n - 1)
                    {
                        temp[i] = start ^ end;
                        break;
                    }
                    else
                        temp[i] = start ^ states[i+1];

                    start = states[i];
                }
                Array.Copy(temp, states, n);
                //states = temp;
                start = 0;
            }
            for(int i = 0; i < temp.Length; i++)
            {
                Console.Write(temp[i] + " ");
            }
        }
        
        //Find Gretest Common Divisor
        public int GCD(int a, int b)
        {
            if (a == 0)
                return b;

            return GCD(b % a, a);
        }

        public void FindGCD(int[] A)
        {
            int n = A.Length;
            int result = A[0];

            for(int i = 1; i < n; i++)
            {
                result = GCD(A[i], result);
            }

            Console.Write(result);
        }


        //Given a positive integer N, count all possible distinct binary strings of 
        //length N such that there are no consecutive 1’s.
        //Input:  N = 2
        //Output: 3
        // The 3 strings are 00, 01, 10
        //Solution is simple fib series. as the solution is always going to be 
        //f(n) = f(n-1) + f(n-2)
        public int CountString(int n)
        {
            int[] a = new int[n];
            int[] b = new int[n];

            a[0] = b[0] = 1;

            for(int i = 1; i < n; i++)
            {
                a[i] = a[i - 1] + b[i - 1];
                b[i] = a[i - 1];
            }
            return a[n-1]+b[n-1];
        }

        //Reverser the word string
        //Input = "This is too good"
        //Output = "good too is this"
        public string ReverseWordsInString(string s)
        {
            if (s == "" || s.Length == 0)
                return string.Empty;
            string[] arr = s.Split(' ');
            string space = " ";
            StringBuilder sb = new StringBuilder();
            for(int i = arr.Length-1; i>=0; i--)
            {
                if (arr[i] == "")
                    continue;
                //sb.Append(space);
                sb.Append(arr[i]);
                if(i != 0)
                    sb.Append(space);
            }

            return sb.ToString();
        }

        //Divide two number without using divion and multiplication
        //9/3 = 3
        //if you pass dividend bigger than the int can handle then it thros system overflow excepction
        //didivend = -2147483648 - will throw error
        public int DivideTwoNumbers(long dividend, int divisor)
        {
            int sign = ((dividend < 0) || (divisor < 0)) ? -1 : 1;
            dividend = Math.Abs(dividend);
            divisor = Math.Abs(divisor);
            int quotent = 0;
            int result = 0;
            //while(dividend >= divisor)
            //{
            //    dividend = dividend - divisor;
            //    quotent++;
            //}
            while (dividend >= result)
            {
                result = result + divisor;
                quotent++;
            }

            return sign * (quotent - 1);
        }

        //Rotate Matrix
        public void RotateMatrix(int[,] A)
        {
            int m = A.Length;
            int n = (int)Math.Sqrt(m);

            for (int i = 0; i < n / 2; i++)
            {
                for (int j = i; j < n - i - 1; j++)
                {
                    //This will rotate to left
                    //int temp = A[i, j];
                    //A[i,j] = A[j, n-1-i]; //Moves values from top right to top left
                    //A[j, n - 1 - i] = A[n - 1 - i, n - 1 - j]; // moves from bottom right to top right
                    //A[n - 1 - i, n - 1 - j] = A[n - 1 - j, i]; //moves from bottom left to bottom right
                    //A[n - 1 - j, i] = temp; // moves from top left to bottom left

                    //this will rotate to right
                    int temp = A[i, j]; // [0,0] -> [0,1]
                    A[i, j] = A[n - 1 - j, i]; //[0,0] = [2,0] >> [0,1] = [1,0]
                    A[n - 1 - j, i] = A[n - 1 - i, n - 1 - j]; // [2,0] = [2,2] >> [1,0] = [2,1]
                    A[n - 1 - i, n - 1 - j] = A[j, n - 1 - i]; //[2,2] = [0,2] >> [2,1] = [1,2]
                    A[j, n - 1 - i] = temp;
                }
            }
        }

        public void PrintMatrix(int[,] A, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(A[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public void FindMyKFrequentWords(string A, int k)
        {
            //uncomment below line if of code in case want to read text file else read it through input parameter
            string[] words = File.ReadAllText(@"C:\Users\SHIVA\Desktop\test.txt", Encoding.ASCII).Split(' ');
            Dictionary<string, int> FrequencyDictionary = new Dictionary<string, int>();
            //string[] words = A.Split(' ');
            foreach (string word in words)
            {
                int freq = 1;
                if (FrequencyDictionary.ContainsKey(word))
                {
                    FrequencyDictionary.TryGetValue(word, out freq);
                    FrequencyDictionary[word] = freq + 1;
                }
                else
                    FrequencyDictionary.Add(word, freq);
            }

            var item = from pair in FrequencyDictionary
                       orderby pair.Value descending
                       select pair;

            foreach (KeyValuePair<string, int> pair in item)
            {
                Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
            }
        }
    }
}
