using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class MinHeap
    {
        int[] arr;
        int arrSize; int heapSize;
        //below constructror is commeted because i want user to provide the size of the heap
        //public MinHeap()
        //{
        //    arrSize = 0;
        //    heapSize = 0;
        //    arr = new int[arrSize];
        //}

        public MinHeap(int size)
        {
            arr = new int[size];
            arrSize = size;
        }

        //property to find the count of the Minheap
        public int Count
        {
            get { return heapSize; }
        }

        //property to find if heap is empty
        public bool isHeapEmpty
        {
            get { return heapSize == 0; }
        }

        //property to find if heap is full
        public bool isHeapFull
        {
            get { return arrSize == heapSize; }
        }

        //public void setheapSize(int size)
        //{
        //    this.arrSize = size;
        //    arr = new int[size];
        //}


        //Method to Insert new item in MinHeap
        public void Insert(int data)
        {
            if (heapSize == arrSize)
            {
                Console.WriteLine("Excepction: Heap overflow");
            }
            else
            {
                arr[heapSize] = data;
                heapSize++;
                shiftUp(heapSize - 1);
            }
        }

        //Method to Remove item from MinHeap
        public void Remove(int data)
        {
            for (int i = 0; i < heapSize - 1; i++)
            {
                if (arr[i] == data)
                {
                    arr[i] = arr[heapSize - 1];
                    heapSize--;
                    shiftDown(i);
                    break;
                }
            }
        }

        //Method to check if value is present in heap
        public bool Contains(int data)
        {
            for (int i = 0; i < heapSize - 1; i++)
            {
                if (arr[i] == data)
                    return true;
            }

            return false;
        }

        //Method to remove Min value from MinHeap
        public void RemoveMin()
        {
            if (heapSize < 0)
            {
                Console.WriteLine("Humty..Dumpty...Heap is empty !...");
            }
            else
            {
                arr[0] = arr[heapSize - 1];
                heapSize--;
                if (heapSize > 0)
                {
                    shiftDown(0);
                }
            }
        }

        private void shiftUp(int index)
        {
            int parentIndex, temp;
            if (index != 0)
            {
                parentIndex = getParentIndex(index);
                if (arr[parentIndex] > arr[index])
                {
                    temp = arr[parentIndex];
                    arr[parentIndex] = arr[index];
                    arr[index] = temp;

                    shiftUp(parentIndex);
                }
            }
        }

        private void shiftDown(int index)
        {
            int leftChildIndex, rightChildIndex, minIndex;

            leftChildIndex = getLeftChildIndex(index);
            rightChildIndex = getRightChildIndex(index);

            if (rightChildIndex >= heapSize)
            {
                if (leftChildIndex >= heapSize)
                {
                    return;
                }
                else
                {
                    minIndex = leftChildIndex;
                }
            }
            else
            {
                if (arr[leftChildIndex] <= arr[rightChildIndex])
                    minIndex = leftChildIndex;
                else
                    minIndex = rightChildIndex;
            }

            if (arr[index] > arr[minIndex])
            {
                int temp = arr[index];
                arr[index] = arr[minIndex];
                arr[minIndex] = temp;

                shiftDown(index);
            }
        }

        private int getParentIndex(int index)
        {
            return (index - 1) / 2;
        }

        private int getLeftChildIndex(int index)
        {
            return (index * 2) + 1;
        }
        private int getRightChildIndex(int index)
        {
            return (index * 2) + 2;
        }

        public void PrintHeap()
        {
            for (int i = 0; i < heapSize; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }
    }
}
