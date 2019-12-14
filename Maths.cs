using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class Maths
    {
        //string st = "a+b*c-d*e"; a+b*c-d*e
        public string InfixToPostfix(string s)
        {
            int n = s.Length;
            string result = string.Empty;
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < n; i++)
            {
                if (isOperand(s[i]))
                    result += s[i];
                else if (isOperator(s[i]))
                {
                    while (stack.Count > 0 && HigherPrecendence(stack.Peek(), s[i]))
                    {
                        result += stack.Peek(); ;
                        stack.Pop();
                    }
                    stack.Push(s[i]);
                }
            }
            while (stack.Count != 0)
            {
                result += stack.Peek();
                stack.Pop();
            }
            return result;
        }

        private bool HigherPrecendence(char char1, char char2)
        {
            if (char2 == '+' || char2 == '-' && char1 == '*' || char1 == '/')
                return true;
            else
                return false;
        }

        private bool isOperand(char c)
        {
            if (c >= '0' && c <= '9') return true;
            if (c >= 'a' && c <= 'z') return true;
            if (c >= 'A' && c <= 'Z') return true;

            return false;
        }

        private bool isOperator(char c)
        {
            if (c == '+' || c == '-' || c == '*' || c == '/' || c == '%' || c == '$')
                return true;

            return false;
        }
    }
}
