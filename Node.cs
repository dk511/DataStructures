using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class Node
    {
        private int data;
        private Node next;
        private Node previous;
        private Node random;

        //These variables are for Tree
        private Node left;
        private Node right;
        private Node nextRight;
        private int height;

        //These variables are for Trie
        private int Alphabet_size = 26;
        private List<int> indices;
        public Node[] arr;
        private bool isEnd;
        private int countofWords;

        //These variables are for graph
        private Node vertex;
        int weight;

        #region - Constructors

        //public Node()
        //{

        //}

        //This constructor is for graph
        public Node(Node v, int w)
        {
            this.vertex = v;
            this.weight = w;
        }

        //This constructor is for Trees
        public Node(int data)
        {
            this.data = data;
            this.left = null;
            this.right = null;
            //Next right is used only when we want to connect left and right nodes
            this.nextRight = null;
            this.height = 1;
        }

        //This constructor is for Trie data structure
        public Node()
        {
            arr = new Node[Alphabet_size];
            isEnd = false;
            countofWords = 0;
            indices = new List<int>(0);
            for (int i = 0; i < Alphabet_size; i++)
                arr[i] = null;
        }

        //This constructor is for Linked List
        public Node(int data, Node next)
        {
            this.data = data;
            this.next = next;

        }

        //This constructor is for doubly Linked List
        //public Node(int data, Node prev, Node next)
        //{
        //    this.data = data;
        //    this.next = next;
        //    this.previous = prev;
        //}
        #endregion - Constructor End

        #region - Properties

        public Node Vertex
        {
            get { return this.vertex; }
            set { this.vertex = value; }
        }

        public int Weight
        {
            get { return this.weight; }
            set { this.weight = value; }
        }

        public int Data
        {
            get { return this.data; }
            set { this.data = value; }
        }

        public Node Next
        {
            get { return this.next; }
            set { this.next = value; }
        }

        public Node Previous
        {
            get { return this.previous; }
            set { this.previous = value; }
        }

        public Node Random
        {
            get { return this.random; }
            set { this.random = value; }
        }

        public Node Left
        {
            get { return this.left; }
            set { this.left = value; }
        }

        public Node Right
        {
            get { return this.right; }
            set { this.right = value; }
        }

        public int Height
        {
            get { return this.height; }
            set { this.height = value; }
        }

        public Node NextRight
        {
            get { return this.nextRight; }
            set { this.nextRight = value; }
        }

        public bool EndOfWord
        {
            get { return this.isEnd; }
            set { this.isEnd = value; }
        }

        public int WordCount
        {
            get { return this.countofWords; }
            set { this.countofWords = value; }
        }

        #endregion - Properties End

        #region Methods
        public Node getChild(int index)
        {
            if (index < 'a' || index > 'z')
                return null;

            return arr[index - 'a'];
        }

        public void addChild(int index)
        {
            if (index < 'a' || index > 'z')
                return;

            Node n = new Node();
            arr[index - 'a'] = n;
        }

        public List<int> getIndices()
        {
            return indices;
        }

        public void addIndex(int index)
        {
            indices.Add(index);
        }


        #endregion

        //    public void Print()
        //    {
        //        Console.Write(data + "--> ");
        //        if (next != null)
        //        {
        //            next.Print();
        //        }
        //    }

        //    public void AddToEnd(int data)
        //    {
        //        if (next == null)
        //        {
        //            next = new Node(data);
        //        }
        //        else
        //        {
        //            next.AddToEnd(data);
        //        }

        //    }

        //    public void AddToSorted(int data)
        //    {
        //        if (next == null)
        //        {
        //            next = new Node(data);
        //        }
        //        else if (data < next.data)
        //        {
        //            Node temp = new Node(data);
        //            temp.next = this.next;
        //            this.next = temp;
        //        }
        //        else
        //        {
        //            next.AddToSorted(data);
        //        }
        //    }
    }
}
