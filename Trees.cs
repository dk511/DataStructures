using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace DataStructures
{
    public class QItem
    {
        public Node hNode;
        public int hd;

        public QItem(Node n, int h)
        {
            this.hNode = n;
            this.hd = h;
        }
    }
    public class Tree
    {
        private Node headNode;
        private int size;

        public Tree()
        {
            headNode = null;
            size = 0;
        }

        public bool isEmpty
        {
            get { return size == 0; }
        }

        public int Count
        {
            get { return this.size; }
        }

        public Node HeadNode
        {
            get { return this.headNode; }
            set { this.headNode = value; }
        }

        public int AddNode(int index, int data)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException("Index did not find" + index);

            if (index > this.size)
                index = size;

            if (this.isEmpty || index == 0)
            {
                headNode = new Node(data);
                size++;
                return data;
            }

            Node current = this.headNode;
            bool added = false;

            do
            {
                if (data <= current.Data)
                {
                    if (current.Left == null)
                    {
                        Node LNode = new Node(data);
                        current.Left = LNode;
                        added = true;
                    }
                    else
                    {
                        current = current.Left;
                    }
                }
                if (data > current.Data)
                {
                    if (current.Right == null)
                    {
                        Node RNode = new Node(data);
                        current.Right = RNode;
                        added = true;
                    }
                    else
                    {
                        current = current.Right;
                    }
                }
            } while (!added);
            size++;
            return data;
        }

        public int AddNode(int data)
        {
            return this.AddNode(size, data);
        }

        //not working
        public void PritntTree()
        {
            Node current = this.headNode;
            while (current.Left != null)
            {
                Console.WriteLine(current.Data + " ");
                current = current.Next;
            }
            while (current.Right != null)
            {
                Console.WriteLine(current.Data + " ");
                current = current.Next;
            }
        }

        //FindMin = recursive solution 
        public int FindMinValue(Node headNode)
        {
            if (headNode == null)
            {
                return -1;
            }
            else if (headNode.Left == null)
            {
                return headNode.Data;
            }
            return this.FindMinValue(headNode.Left);
        }

        //FindMax = Iterative solution
        public int FindMaxValue()
        {
            if (headNode == null)
            {
                return -1;
            }
            Node current = this.headNode;
            if (current.Right == null)
            {
                return current.Data;
            }
            while (current.Right != null)
                current = current.Right;

            return current.Data;
        }

        //Find height/depth of the tree
        //Time = 0(n)
        public int FindHeight(Node headNode)
        {
            if (headNode == null)
            {
                return 0;
            }

            return Math.Max(this.FindHeight(headNode.Left), this.FindHeight(headNode.Right)) + 1;

        }

        //Find diameter of the tree
        //Diameter of the tree = height of left subtree + height of right subtree
        public int DiameterOfTree(Node headNode)
        {
            if (headNode == null) return 1;

            return (DiameterOfTree(headNode.Left) + DiameterOfTree(headNode.Right)) + 1;
        }

        //Find minimum depth of three
        //to find Depth of the tree just find max instead of min
        public int MinDepth(Node headnode)
        {
            if (headnode == null) return 0;
            if (headnode.Left == null && headnode.Right == null) return 1;
            //if left subtree is null
            if (headnode.Left == null) return MinDepth(headnode.Right);
            //if right subtree is null
            if (headnode.Right == null) return MinDepth(headnode.Left);

            return Math.Min(MinDepth(headnode.Left), MinDepth(headnode.Right)) + 1;
        }

        #region BFS/VOT/DFS - VerticleOrder - Preorder - inorder - Postorder - SpiralOrder - 

        //BFS
        public void LevelOrderTraversal(Node headNode)
        {
            if (headNode == null) return;
            Queue<Node> Q = new Queue<Node>();
            Q.Enqueue(headNode);

            while (Q.Count != 0)
            {
                Node current = Q.First();
                Console.Write(current.Data + " ");
                if (current.Left != null) Q.Enqueue(current.Left);
                if (current.Right != null) Q.Enqueue(current.Right);
                Q.Dequeue(); // this will remove item front of queue
            }
        }

        //Verticle order traversal can be looked at it as top view of the tree
        public void VerticleOrderTraversal()
        {
            if (headNode == null) return;
            HashSet<int> hset = new HashSet<int>();
            Queue<QItem> q = new Queue<QItem>();

            q.Enqueue(new QItem(headNode, 0));

            while (q.Count > 0)
            {
                QItem qi = q.Dequeue();
                int hd = qi.hd;
                Node current = qi.hNode;

                if (!hset.Contains(hd))
                {
                    hset.Add(hd);
                    Console.Write(current.Data + " ");
                }
                if (current.Left != null)
                    q.Enqueue(new QItem(current.Left, hd - 1));

                if (current.Right != null)
                    q.Enqueue(new QItem(current.Right, hd + 1));
            }

        }
        public void Preorder(Node headNode)
        {
            if (headNode == null)
                return;
            Console.Write(headNode.Data + " ");
            this.Preorder(headNode.Left);
            this.Preorder(headNode.Right);
        }
        public void Inorder(Node headNode)
        {
            if (headNode == null)
                return;

            this.Inorder(headNode.Left);
            Console.Write(headNode.Data + " ");
            this.Inorder(headNode.Right);
        }
        public void Postorder(Node headNode)
        {
            if (headNode == null)
                return;

            this.Postorder(headNode.Left);
            this.Postorder(headNode.Right);
            Console.Write(headNode.Data + " ");
        }
        //spiral/zigzag order 
        public void SpiralOrder(Node headNode)
        {
            Stack<Node> s1 = new Stack<Node>();
            Stack<Node> s2 = new Stack<Node>();

            s1.Push(headNode);

            while (s1.Count > 0 || s2.Count > 0)
            {
                while (s1.Count > 0)
                {
                    Node top = s1.Pop();
                    Console.Write(top.Data + " ");
                    if (top.Left != null)
                        s2.Push(top.Left);
                    if (top.Right != null)
                        s2.Push(top.Right);
                }
                while (s2.Count > 0)
                {
                    Node top = s2.Pop();
                    Console.Write(top.Data + " ");
                    if (top.Right != null)
                        s1.Push(top.Right);
                    if (top.Left != null)
                        s1.Push(top.Left);
                }
            }
        }

        #endregion

        //This methond connects the left and right childs 
        public void ConnectLeftRightNodes(Node headNode)
        {
            if (headNode == null) return;
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(headNode);
            q.Enqueue(null);

            while (q.Count != 0)
            {
                Node x = q.Peek();
                //Console.WriteLine(x.Data + " ");
                q.Dequeue();

                if (x != null)
                {
                    x.NextRight = q.First();
                    if (x.Left != null)
                        q.Enqueue(x.Left);
                    if (x.Right != null)
                        q.Enqueue(x.Right);
                }
                else if (q.Count != 0)
                {
                    q.Enqueue(null);
                }
            }
        }

        //Need to correct CountBreadth function
        //check the max breadth of the tree
        public int CountBreadth()
        {
            Node current = this.headNode;
            if (current == null) return -1;
            Queue<Node> q = new Queue<Node>();
            int maxCount = 0;

            q.Enqueue(current);
            maxCount = q.Count;

            while (q.Count != 0)
            {
                current = q.First();
                if (current.Left != null)
                {
                    q.Enqueue(headNode.Left);
                }
                if (current.Right != null)
                {
                    q.Enqueue(headNode.Right);
                }
                q.Dequeue();
                if (q.Count > maxCount) maxCount = q.Count;
            }
            return maxCount;
        }

        //Time Complexity: O(n)
        //Auxiliary Space : O(1) if Function Call Stack size is not considered, otherwise O(n)
        public bool IsTreeBST()
        {
            return TreeBSTUtil(headNode, int.MinValue, int.MaxValue);
        }

        //Check if given tree is binary tree
        public bool TreeBSTUtil(Node headNode, int min, int max)
        {
            if (headNode == null)
                return true;
            if (headNode.Data >= min && headNode.Data < max
                && TreeBSTUtil(headNode.Left, min, headNode.Data)
                && TreeBSTUtil(headNode.Right, headNode.Data, max))
                return true;
            else
                return false;
        }

        //Find Node by node value
        public int SearchNode(Node headNode, int data)
        {
            if (headNode == null)
                return -1;
            if (headNode.Data == data)
            {
                return headNode.Data;
            }
            else if (headNode.Data > data)
            {
                return SearchNode(headNode.Left, data);
            }
            else
            {
                return SearchNode(headNode.Right, data);
            }
        }

        //check if data exists in Tree
        public bool CheckIfDataExists(Node headNode, int data)
        {
            if (headNode == null)
                return false;
            if (headNode.Data == data)
            {
                return true;
            }
            else if (headNode.Data > data)
            {
                CheckIfDataExists(headNode.Left, data);
            }
            else
            {
                CheckIfDataExists(headNode.Right, data);
            }
            return false;
        }

        //Delete Node from tree
        public Node Delete(Node headNode, int data)
        {
            if (headNode == null) return headNode;
            else if (data < headNode.Data) headNode.Left = Delete(headNode.Left, data);
            else if (data > headNode.Data) headNode.Right = Delete(headNode.Right, data);
            else
            {
                //Case 1 - no child
                if (headNode.Left == null && headNode.Right == null)
                {
                    headNode = null;
                    GC.Collect();
                    return headNode;
                }
                //case 2 - has only right child
                else if (headNode.Left == null)
                {
                    Node temp = headNode;
                    headNode = headNode.Right;
                    temp = null;
                    GC.Collect();
                    return headNode;
                }
                //case 3 - has only left child
                else if (headNode.Right == null)
                {
                    Node temp = headNode;
                    headNode = headNode.Left;
                    temp = null;
                    GC.Collect();
                    return headNode;
                }
                //case 4 - has both left & right child
                else
                {
                    Node temp = FindMin(headNode.Right);
                    headNode.Data = temp.Data;
                    headNode.Right = Delete(headNode.Right, temp.Data);
                }
            }
            return headNode;
        }

        //FindMin value in Tree
        public Node FindMin(Node headNode)
        {
            while (headNode.Left != null)
            {
                headNode = headNode.Left;
            }
            return headNode;
        }

        //FindMax value in Tree
        public Node FindMax(Node headNode)
        {
            while (headNode.Right != null)
            {
                headNode = headNode.Right;
            }
            return headNode;
        }

        //Create BST from the given sorted array A = {1, 2, 3, 4, 5, 6, 7, 8, 9}
        public Node CreateBST(int[] A, int start, int end)
        {
            if (start > end) return null;
            int mid = (start + end) / 2;

            Node headNode = new Node(A[mid]);
            headNode.Left = CreateBST(A, start, mid - 1);
            headNode.Right = CreateBST(A, mid + 1, end);

            return headNode;

        }

        //Check if given binary tree is full/complete binary tree
        public bool isFullBinaryTree(Node headNode)
        {
            if (headNode == null) return true;
            if (headNode.Left == null && headNode.Right == null) return true;

            if (headNode.Left != null && headNode.Right != null)
                return (isFullBinaryTree(headNode.Left) && isFullBinaryTree(headNode.Right));

            return false;
        }

        //Lowest common ancestor - recursive approach - Time com - o(n) and space com - o(n)
        public Node LCA_R(Node headNode, int x1, int x2)
        {
            if (headNode == null) return headNode;
            if (headNode.Data < x1 && headNode.Data < x2)
            {
                return LCA_R(headNode.Right, x1, x2);
            }
            else if (headNode.Data > x1 && headNode.Data > x2)
            {
                return LCA_R(headNode.Left, x1, x2);
            }

            return headNode;
        }

        //Lowest common ancestor - Iterative approach
        public Node LCA_I(Node headNode, int x1, int x2)
        {
            if (headNode == null) return headNode;
            while (headNode != null)
            {
                if (headNode.Data > x1 && headNode.Data > x2)
                    return headNode.Left;
                else if (headNode.Data < x1 && headNode.Data < x2)
                    return headNode.Right;
                else
                    break;
            }
            return headNode;
        }

        //Create mirror of the Binary Tree
        public void MirrorTree(Node headNode)
        {
            if (headNode == null) return;
            else
            {
                this.MirrorTree(headNode.Left);
                this.MirrorTree(headNode.Right);

                Node temp = headNode.Left;
                headNode.Left = headNode.Right;
                headNode.Right = temp;
            }

        }

        //check if Tree is symmetric/mirror 
        public bool isTreeSymmetric(Node nodeOne, Node nodeTwo)
        {
            if (nodeOne == null && nodeTwo == null)
                return true;

            if (nodeOne != null && nodeTwo != null && nodeOne.Data == nodeTwo.Data)
            {
                return (isTreeSymmetric(nodeOne.Left, nodeTwo.Right)
                    && isTreeSymmetric(nodeOne.Right, nodeTwo.Left));
            }

            return false;
        }

        //single tree if it is symmetric of not
        public bool isTreeSymmetric(Node headNode)
        {
            return isTreeSymmetric(headNode.Left, headNode.Right);
        }

        //check if two tree are same Node by Node
        public bool areTreeSame(Node headNodeOne, Node headNodeTwo)
        {
            if (headNodeOne == null && headNodeTwo == null) return true;

            if (headNodeOne != null && headNodeTwo != null && headNodeOne.Data == headNodeTwo.Data)
            {
                return (areTreeSame(headNodeOne.Left, headNodeTwo.Left)
                    && areTreeSame(headNodeOne.Right, headNodeTwo.Right));
            }

            return false;
        }

        //Below function need to be corrected 
        public int FindTreeTilt(Node headNode)
        {
            int tilt = 0;
            if (headNode == null) tilt = 1;

            if (headNode.Left != null && headNode.Right != null)
            {
                tilt += headNode.Left.Data - headNode.Right.Data;
            }

            while (headNode.Left != null && headNode.Right != null)
            {
                this.FindTreeTilt(headNode.Left);
                this.FindTreeTilt(headNode.Right);
            }

            return tilt;
        }

        ////Below solution is not correct
        ////print Tree in below format
        ////        Input:
        ////     2
        ////    / \
        ////   1   3

        //// Output:
        ////[["", "", "", "2", "", "", ""],
        //// ["", "1", "", "", "", "3", ""],
        //public void FormatedPrint(Node headNode)
        //{
        //    if (headNode == null)
        //    {
        //        Console.Write("+ ' ' + ");
        //        return;
        //    }

        //    Console.WriteLine(" " + headNode.Data);
        //    this.FormatedPrint(headNode.Left);
        //    this.FormatedPrint(headNode.Right);
        //}

        public int MaxDepthLeftTreeValue(Node headNode)
        {
            if (headNode == null)
            {
                return headNode.Data;
            }

            return Math.Max(this.FindHeight(headNode.Left), this.FindHeight(headNode.Right)) + 1;

        }

        //Serialize Tree
        //Pass your path below
        public void SerializeBST(Node headNode)
        {
            StringBuilder sb = new StringBuilder();
            string path = @"C:\Users\SHIVA\Documents\Visual Studio 2015\Projects\LinkedList_Test\LinkedList_Test\bin\Debug\SerializedTree.txt";
            if (File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.Write(SerializeUtil(headNode, sb));
                }
            }
        }

        public string SerializeUtil(Node headNode, StringBuilder s)
        {
            if (headNode == null)
                s.Append("# ");
            else
            {
                s.Append(headNode.Data + " ");
                SerializeUtil(headNode.Left, s);
                SerializeUtil(headNode.Right, s);
            }

            return s.ToString();
        }
    }
}
