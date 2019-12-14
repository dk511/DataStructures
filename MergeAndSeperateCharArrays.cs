//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DataStructures
//{
//    class MergeAndSeperateCharArrays
//    {

//        public static char[] MergeCharArrays(char[] a, char[] b)
//        {
//            char[] mergedArray = { };
//            int k = 0;
//            mergedArray[0] = (char)a.Length;
//            for(int i=1;i<a.Length;i++)
//            {
//                mergedArray[i] = a[i];
//                k = i;
//            }
//            mergedArray[k + 1] = (char)b.Length;
//            for(int j=k; j<b.Length; j++)
//            {
//                mergedArray[j] = b[j-k];
//            }
//            return mergedArray;
//        }

//        static void Main(string[] args)
//        {
//            char[] a = { 'a', 'b', 'c', 'd' };
//            char[] b = { 'd', 'e', 'e', 'p', 'a', 'k' };

//            char[] ab = MergeCharArrays(a, b);
//        }
