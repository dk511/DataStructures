using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class PatternMatching
    {
        //Best approach will be updated soon
        //This is Naive approce to find string pattern - TC = O(n)
        public void NaiveApproach(string text, string pat)
        {
            int m = pat.Length; int n = text.Length;

            for (int i = 0; i < n - m; i++)
            {
                int j;
                for (j = 0; j < m; j++)
                {
                    if (text[i + j] != pat[j])
                        break;
                }

                if (j == m)
                    Console.Write(i + " ");
            }
        }
    }
}
