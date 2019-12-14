using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class Stack
    {
        public static int max = 1000;
        int[] A;
        int top;

        public Stack()
        {
            A = new int[max];
            top = -1;
        }

        //property to find count of the stack
        public int Count
        {
            get { return top + 1; }
        }

        //property to check if stack is empty
        public bool isEmpty
        {
            get { return top == 0; }
        }

        //property to find top element in stack
        public int Top
        {
            get { return A[top]; }
        }

        //property to find is stack is full
        public bool isFull
        {
            get { return top == max; }
        }

        //method to push new element
        public bool Push(int x)
        {
            if (top == max - 1)
            {
                Console.WriteLine("Error: Stack Overflow !");
                return false;
            }
            A[++top] = x;
            int n = A.Length;
            //top++;
            return true;
        }

        //method to pop top element
        public int Pop()
        {
            int x = 0;
            if (top < 0)
                Console.Write("Stack is empty !");
            else
                x = A[top--];

            return x;
        }

        public void PrintStack()
        {
            Console.Write("Stack: ");
            for (int i = 0; i < Count; i++)
            {
                Console.Write(A[i] + " ");
            }
        }
    }
}
