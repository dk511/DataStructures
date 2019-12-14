using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class MaxHeap
    {
        int[] arr;
        int arrsize; int heapsize;

        public MaxHeap(int size)
        {
            arr = new int[size];
            arrsize = size;
        }

        //property to find the count of the MaxHeap
        public int Count
        {
            get { return heapsize; }
        }

        //property to find if heap is empty
        public bool isHeapEmpty
        {
            get { return heapsize == 0; }
        }

        //property to find if heap is full
        public bool isHeapFull
        {
            get { return arrsize == heapsize; }
        }

        //Method to insert new value in MaxHeap
        public void Insert(int data)
        {
            if (heapsize == arrsize)
            {
                Console.WriteLine("Excepction: Heap overflow");
            }
            else
            {
                arr[heapsize] = data;
                heapsize++;
                ShiftUp(heapsize - 1);
            }
        }

        //Method to remove value from MaxHeap
        public void Remove(int data)
        {
            for (int i = 0; i < heapsize - 1; i++)
            {
                if (arr[i] == data)
                {
                    arr[i] = arr[heapsize - 1];
                    heapsize--;
                    ShiftDown(i);
                    break;
                }
            }
        }

        //Method to check if value is present in MaxHeap
        public bool Contains(int data)
        {
            for (int i = 0; i < heapsize - 1; i++)
            {
                if (arr[i] == data)
                    return true;
            }
            return false;
        }

        public void ShiftUp(int index)
        {
            int parentIndex, temp;
            if (index != 0)
            {
                parentIndex = getParentIndex(index);
                if (arr[index] > arr[parentIndex])
                {
                    temp = arr[parentIndex];
                    arr[parentIndex] = arr[index];
                    arr[index] = temp;

                    ShiftUp(parentIndex);
                }
            }
        }

        public void ShiftDown(int index)
        {

        }

        public int getParentIndex(int index)
        {
            return index / 2;
        }

        public int getLeftChildIndex(int index)
        {
            return (index * 2) + 1;
        }

        public int getRightChildIndex(int index)
        {
            return (index * 2) + 2;
        }
    }
}
