using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class Queue
    {
        public static int max = 1000;
        int[] A;
        int top;

        public Queue()
        {
            A = new int[max];
            top = -1;
        }

        //property to find count of the queue
        public int Count
        {
            get { return top + 1; }
        }

        //property to check if quque is empty
        public bool isEmpty
        {
            get { return top == 0; }
        }

        //property to find top element in queue
        public bool isFull
        {
            get { return top == 100; }
        }

        //property to find front element in queue
        public int Front
        {
            get { return A[0]; }
        }

        //property to find rear element in queue
        public int Rear
        {
            get { return A[top]; }
        }

        //Method to Enqueue new element in queue
        public bool Enqueue(int x)
        {
            if(top == max - 1)
            {
                Console.WriteLine("Error: Stack Overflow !");
                return false;
            }

            A[++top] = x;
            return true;
        }

        //Method to Dequeue front element in queue
        public void Dequeue()
        {

        }

        public void PrintQueue()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.Write(A[i] + " ");
            }
        }
    }
}
