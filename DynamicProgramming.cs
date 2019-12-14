using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class DynamicProgramming
    {
        /// <summary>
        /// there are two important properties of Dynamic programming
        /// 1 - Overlapping Subproblem
        /// 2 - Optimal Substructure
        /// If any given problem fits into these properties then
        /// these problems can be resolved by two ways
        ///     -> Memorization (Top Down approach)
        ///     -> Tabulation (Bottom up approach)
        /// </summary>


        int NIL = -1;
        int[] lookup = new int[100];
        int[,] lookups = new int[50, 50];

        //Memorization (Top Down) approach
        public void _Initialize()
        {
            for (int i = 0; i < 100; i++)
            {
                lookup[i] = NIL;
            }
        }

        public int Fib(int n)
        {
            if (lookup[n] == NIL)
            {
                if (n <= 1)
                {
                    lookup[n] = n;
                }
                else
                {
                    lookup[n] = Fib(n - 1) + Fib(n - 2);
                }
            }

            return lookup[n];
        }


        //Tabulisation (Bottom up) approach
        public int Fibb(int n)
        {
            int[] f = new int[n + 1];
            f[0] = 0; f[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                f[i] = f[i - 1] + f[i - 2];
            }

            return f[n];
        }


        #region DP problems
        //Given 3 numbers {1, 3, 5}, we need to tell
        //the total number of ways we can form a number 'N'
        //solved with memorization
        public int CheckCombination(int n)
        {
            //solution
            if (n < 0)
                return 0;
            if (n == 0)
                return 1;

            if (lookup[n] != -1)
                return lookup[n];

            return lookup[n] = CheckCombination(n - 1) + CheckCombination(n - 3) + CheckCombination(n - 5);

        }
        #endregion

        //longest common sequence
        //recursive solution
        public int LCS_R(char[] x, char[] y, int m, int n)
        {
            if (m == 0 || n == 0) return 0;
            if (x[m - 1] == y[n - 1])
                return 1 + LCS_R(x, y, m - 1, n - 1);
            else
                return Math.Max(LCS_R(x, y, m - 1, n), LCS_R(x, y, m, n - 1));

        }
        //memorization solution
        public int LCS_DP(char[] x, char[] y, int m, int n)
        {
            int[,] temp = new int[x.Length + 1, y.Length + 1];
            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (i == 0 || j == 0)
                        temp[i, j] = 0;
                    else if (x[i - 1] == y[j - 1])
                        temp[i, j] = temp[i - 1, j - 1] + 1;
                    else
                        temp[i, j] = Math.Max(temp[i - 1, j], temp[i, j - 1]);
                }
            }
            return temp[m, n];
        }

        //Binomial coefficient
        public int BinomialCoefficient_R(int n, int k)
        {
            if (k == 0 || k == n) return 1;

            return BinomialCoefficient_R(n - 1, k - 1) + BinomialCoefficient_R(n - 1, k);
        }
        //Memoization solution
        public int BinomialCoefficient_DP(int n, int k)
        {
            int[,] temp = new int[n + 1, k + 1];

            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= Math.Min(i, k); j++)
                {
                    if (j == 0 || j == i)
                    {
                        temp[i, j] = 1;
                    }
                    else
                    {
                        temp[i, j] = temp[i - 1, j - 1] + temp[i - 1, j];
                    }
                }
            }
            return temp[n, k];
        }

        //A child is running up a staircase with n steps and can hop eitheR 1 step, 2 steps, 3 steps at a time
        //implement solution to find a count of how many ways a child can run up the stairs
        public int CountWays(int n)
        {
            if (n < 0)
                return 0;
            else if (n == 0)
                return 1;
            else if (lookup[n] > NIL)
                return lookup[n];
            else
                lookup[n] = (CountWays(n - 1) + CountWays(n - 2) + CountWays(n - 3));

            return lookup[n];

        }

        //given two strings find out minimium opertaions required to perform to match up both the
        //strings
        //String1 = Cat, String2 = Rat = Output should be 1 as we need to replace C to R
        //Not working - correct find Min function
        public int StringOpertaions(string str1, string str2, int m, int n)
        {
            int[,] temp = new int[m + 1, n + 1];
            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (i == 0) temp[i, j] = j;
                    if (j == 0) temp[i, j] = i;
                    else if (str1[i - 1] == str2[j - 1])
                        temp[i, j] = temp[i - 1, j - 1];
                    else
                        temp[i, j] = 1 + FindMin(temp[i - 1, j], //Remove
                                                temp[i, j - 1], //Insert
                                                temp[i - 1, j - 1]); //Replace
                }

            }

            return temp[m, n];
        }
        int FindMin(int a, int b, int c)
        {
            int d = (a > b) ? a : b;
            return (d > c) ? d : c;
        }

        //given MxN array, find ways to reach from top left to bottom right
        //Recursive solution without Dynamic programming
        public int CountWaystoReach_R(int m, int n)
        {
            if (m == 1 || n == 1) return 1;

            return (CountWaystoReach_R(m - 1, n) + CountWaystoReach_R(m, n - 1));
        }

        public int CountWaystoReach_DP(int m, int n)
        {

            int[,] count = new int[m, n];

            for (int i = 0; i < m; i++)
            {
                count[i, 0] = 1;
            }

            for (int i = 0; i < n; i++)
            {
                count[0, i] = 1;
            }

            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    count[i, j] = count[i - 1, j] + count[i, j - 1];
                }
            }

            return count[m - 1, n - 1];
        }

        //given arrays of houses, find how much max value a robber can rob
        //robber can not rob adjucent houses - he has to go to alternate houses
        public int maxLoot(int[] hval)
        {
            int n = hval.Length;
            if (n == 0) return 0;
            if (n == 1) return hval[0];
            if (n == 2) return Math.Max(hval[0], hval[1]);

            int[] dp = new int[n + 1];
            dp[0] = hval[0];
            dp[1] = Math.Max(hval[0], hval[1]);

            for (int i = 2; i < n; i++)
            {
                dp[i] = Math.Max(hval[i] + dp[i - 2], dp[i - 1]);
            }

            return dp[n - 1];
        }

        #region - Find Permute - correct it - code is not working
        //find permutations - this is very famous recursion problem
        public ArrayList Permute(string s)
        {
            ArrayList result = new ArrayList();
            Dictionary<char, int> d = BuildFreqTable(s);
            PrintPermute(d, "", s.Length, result);
            return result;
        }

        public Dictionary<char, int> BuildFreqTable(string s)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();
            foreach (char c in s.ToCharArray())
            {
                if (!dic.ContainsKey(c))
                {
                    dic.Add(c, 0);
                }
                dic.Add(c, dic.Count + 1);
            }

            return dic;
        }

        public void PrintPermute(Dictionary<char, int> d, string prefix, int remaming, ArrayList result)
        {
            if (remaming == 0)
            {
                result.Add(prefix);
                return;
            }

            foreach (char c in d.Keys)
            {
                int count = d.Count;
                if (count > 0)
                {
                    d.Remove(c);
                    PrintPermute(d, prefix + c, remaming - 1, result);
                    d.Remove(c);
                }
            }
        }

        //Find Permutations of string - backtracking
        //O(n*n!) Note that there are n! permutations and it requires O(n) time to print a a permutation
        public void Permute(string s, int l, int r)
        {
            if (l == r) Console.WriteLine(s);
            else
            {
                for (int i = l; i <= r; i++)
                {
                    s = Swap(s, l, i);
                    Permute(s, l + 1, r);
                    s = Swap(s, l, i);
                }
            }
        }

        public string Swap(string s, int i, int j)
        {
            char temp;
            char[] charArray = s.ToCharArray();
            temp = charArray[i];
            charArray[i] = charArray[j];
            charArray[j] = temp;
            string s1 = new string(charArray);


            return s1;
        }

        #endregion

        //Fill Screen is not working - check it
        //public void FillScreenUtil(int[,]  screen, int x, int y, int previousCol, int newCol)
        //{
        //    int m = 8; int n = 8;
        //    screen = new int[m, n];

        //    if (x < 0 || x >= m || y < 0 || y >= n) return;
        //    if (screen[x, y] != previousCol) return;

        //    screen[x, y] = newCol;

        //    FillScreenUtil(screen, x+1, y, previousCol, newCol);
        //    FillScreenUtil(screen, x-1, y, previousCol, newCol);
        //    FillScreenUtil(screen, x, y+1, previousCol, newCol);
        //    FillScreenUtil(screen, x, y-1, previousCol, newCol);            
        //}
        //public void FillScreen(int[,] screen, int x, int y, int newCol)
        //{
        //    int prevCol = screen[x,y];
        //    FillScreenUtil(screen, x, y, prevCol, newCol);
        //}

        //egg drop problem
        public int EggDrop(int n, int k)
        {
            if (k == 0 || k == 1) return k;
            if (n == 1) return k;

            int min = int.MaxValue, res;
            for (int i = 1; i <= k; i++)
            {
                res = Math.Max(EggDrop(n - 1, i - 1), EggDrop(n, k - i));
                if (res < min) min = res;
            }

            return min + 1;
        }
    }
}
