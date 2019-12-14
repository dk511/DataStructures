using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class LinkedList
    {
        private Node headNode;
        private int size;

        public Node HeadNode
        {
            get { return this.headNode; }
            set { this.headNode = value; }
        }

        public LinkedList()
        {
            headNode = null;
            size = 0;
        }

        public bool IsEmpty
        {
            get { return size == 0; }
        }

        public int Count
        {
            get { return this.size; }
        }

        public int AddNode(int index, int data)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException("Index - " + index);

            if (index > size)
                index = size;

            Node current = this.headNode;

            if (this.IsEmpty || index == 0)
            {
                headNode = new Node(data, this.headNode);
            }
            else
            {
                //this loop will take the pointer to the last node
                for (int i = 0; i < index - 1; i++)
                    current = current.Next;

                current.Next = new Node(data, current.Next);
            }
            size++;
            return data;
        }

        public int AddNode(int data)
        {
            return this.AddNode(size, data);
        }

        //2 4 6 8 10 - insert 9 at sorted position
        public int AddSortedNode(int data)
        {
            Node current = this.headNode;
            if (current == null || current.Data >= data)
            {
                Node newNode = new Node(data, current.Next);
                newNode.Next = headNode;
                headNode = newNode;
            }
            else
            {
                while (current.Next != null && current.Next.Data < data)
                {
                    current = current.Next;
                }
                Node newNode = new Node(data, current.Next);
                current.Next = newNode;
            }

            return data;
        }

        //Remove data when index of the data as parameter
        //public void RemoveNode(int index)
        //{
        //    if (index == 0 || this.IsEmpty)
        //        throw new IndexOutOfRangeException("Index not found - " + index);

        //    if (index >= this.size)
        //        index = size;

        //    Node current = this.headNode;
        //    int? Result = null;

        //    if (index == 0)
        //    {
        //        Result = current.Data;
        //        this.headNode = current.Next;
        //    }
        //    else
        //    {
        //        for (int i = 0; i < index - 1; i++)
        //            current = current.Next;

        //        Result = current.Next.Data;

        //        current.Next = current.Next.Next;
        //    }
        //    size--;
        //}

        //Remove data when data as parameter
        public Node RemoveData(int data)
        {
            if (headNode == null)
                throw new Exception("Data does not exist- " + data);

            if (headNode.Data == data)
            {
                headNode = headNode.Next;
                return headNode;
            }

            Node current = this.headNode;
            while (current.Next != null)
            {
                if (current.Next.Data == data)
                {
                    current.Next = current.Next.Next;
                    return current;
                }
                current = current.Next;
            }

            size--;
            return current;
        }

        //Clear out Linked List
        public void ClearList()
        {
            this.headNode = null;
        }

        //Findout Index of the data - data provided as parameter
        public int IndexOf(int data)
        {
            if (headNode == null)
                throw new Exception("No Node found");

            Node current = this.headNode;

            for (int i = 0; i < this.Count; i++)
            {
                if (current.Data == data)
                    return i;

                current = current.Next;
            }
            return -1;
        }

        //Check whether data contains or not by passing data as input parameter
        public bool Contains(int data)
        {
            return IndexOf(data) >= 0;
        }

        //Get Node value by passing Index number
        public int GetNodeValue(int index)
        {
            if (index == 0 || this.IsEmpty)
                return -1;
            if (index > this.Count)
                index = this.Count;

            Node current = this.headNode;

            for (int i = 0; i < index; i++)
                current = current.Next;

            return current.Data;
        }

        //Indexer - works same like GetNodeValue method but this is not method
        public int this[int index]
        {
            get { return this.GetNodeValue(index); }
        }

        public void PrintLinkedList()
        {
            Node current = this.headNode;
            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }
        }

        //below are Interview question 
        //Remove duplicates using HashSet (Cracking Coding Interviews - 1)
        public void RemoveDuplicates()
        {
            Node current = this.headNode;
            HashSet<int> hSet = new HashSet<int>();
            Node previous = null;

            while (current != null)
            {
                if (hSet.Contains(current.Data))
                {
                    previous.Next = current.Next;
                }
                else
                {
                    hSet.Add(current.Data);
                    previous = current;
                }
                current = current.Next;
            }

        }

        //Remove duplicates like A = {1, 2, 3, 3, 4, 4, 5} then Output should be A = {1, 2, 5}
        public void RemoveDupsAllInstances()
        {
            Node dummy = new Node();

            dummy.Next = this.headNode;
            Node prev = dummy;
            Node current = headNode;

            while (current != null)
            {
                while (current.Next != null &&
                       prev.Next.Data == current.Next.Data)
                    current = current.Next;

                if (prev.Next == current)
                    prev = prev.Next;
                else
                    prev.Next = current.Next;

                current = current.Next;
            }

            headNode = dummy.Next;
        }

        //Below approach is using haset
        public void RemoveDupAllInstances()
        {
            Node current = this.headNode;
            Node previous = null;
            HashSet<int> hset = new HashSet<int>();
            while (current != null)
            {
                if (!hset.Contains(current.Data))
                {
                    hset.Add(current.Data);
                    previous = current;
                }
                else
                {
                    hset.Remove(current.Data);
                }

                current = current.Next;
            }
            Console.Write(string.Join(" ", hset));
        }

        //print kth to last element from list (Cracking Coding Interviews - 2)
        public void PrintKtoendElements(int index)
        {
            if (headNode == null)
                throw new Exception("LinkedList is empty !...");
            Node current = this.headNode;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }
        }

        //Print middle element of the LinkedList (Cracking Coding Interviews  -3)
        public void PrintMiddleElement()
        {
            if (headNode == null)
                throw new Exception("LinkedList is empty !...");

            Node current = this.headNode;
            int midelement = this.Count / 2;
            for (int i = 0; i < midelement; i++)
            {
                current = current.Next;
            }
            Console.WriteLine(current.Data);
        }

        ////Delete middle element of the LinkedList (Cracking Coding Interviews - 3)
        public void DeleteMidElement()
        {
            if (headNode == null)
                throw new Exception("LinkedList is empty...");

            Node current = this.headNode;
            int midelement = this.Count / 2;
            for (int i = 0; i < midelement - 1; i++)
            {
                current = current.Next;
            }
            current.Next = current.Next.Next;
        }

        //not working - fix it
        //Partition LinkedList such that all the elements less than x should come before x and
        //greated than x should come after x (Cracking Coding Interviews - 4)
        //public Node PartitionByX(int x)
        //{
        //    Node current = this.headNode;
        //    Node head = this.headNode;
        //    Node tail = this.headNode;

        //    while(current != null)
        //    {
        //        Node next = current.Next;
        //        if(current.Data < x)
        //        {
        //            current.Next = head;
        //            head = current;
        //        }
        //        else
        //        {
        //            tail.Next = current;
        //            tail = current;
        //        }
        //        current = next;
        //    }
        //    tail.Next = null;

        //    return head;
        //}

        //above one is not working - below one is perfect solution
        //Partition Linked List such that all the numbers less than x should be before x and greater after x
        public void PartitionLinkedListByX(Node headNode, Node start, int x, int n)
        {
            Node pIndex = start;
            Node pivot = FindIndex(headNode, x);
            //{1, 7, 2, 5, 9, 3, 6}
            for (int i = 0; i < n; i++)
            {
                if (start.Data < x)
                {
                    int temp = start.Data;
                    start.Data = pIndex.Data;
                    pIndex.Data = temp;

                    pIndex = pIndex.Next;
                }
                start = start.Next;
            }
            if (pivot.Data == x)
            {
                int temp1 = pivot.Data;
                pivot.Data = pIndex.Data;
                pIndex.Data = temp1;
            }
            //Print Linked List
            while (headNode != null)
            {
                Console.Write(headNode.Data + " ");
                headNode = headNode.Next;
            }
        }

        //Reverse the list - when pointer is given to headNode
        public Node ReverseLinkedList(Node headNode)
        {
            Node current = headNode;
            Node previous = null;
            Node nxt = null;

            while (current != null)
            {
                nxt = current.Next;
                current.Next = previous;
                previous = current;
                current = nxt;
            }
            return previous;
        }

        //Reverse linkedlist with kth node
        public Node ReverseLinkedListKthNode(Node headNode, int k)
        {
            Node current = headNode;
            Node previous = null;
            Node nxt = null;
            int count = 0;

            while (count < k && current != null)
            {
                nxt = current.Next;
                current.Next = previous;
                previous = current;
                current = nxt;
                count++;
            }

            if (current != null)
                headNode.Next = ReverseLinkedListKthNode(current, k);

            HeadNode = previous;
            return HeadNode;
        }

        //Find pair with sum x in LinkedList int[] B = {5, 4, 1, 3, 7};
        public void PairwithSum(int x)
        {
            Node current = this.headNode;
            HashSet<int> hset = new HashSet<int>();
            while (current != null)
            {
                int y = x - current.Data;
                //if (hset.Contains(y) && current.Data != x)
                if (hset.Contains(y))
                {
                    Console.Write("{" + y + " " + current.Data + "} ");
                }
                else
                {
                    hset.Add(current.Data);
                }

                current = current.Next;
            }
        }

        //Add two Linked Lists (Cracking Coding Interviews - 5)
        public void AddTwoLinkedList(Node headnodeone, Node headnodetwo)
        {
            Node result;
            if (headnodeone == null)
            {
                result = headnodetwo;
                return;
            }
            if (headnodetwo == null)
            {
                result = headnodeone;
                return;
            }

            Node headone = ReverseLinkedList(headnodeone);
            Node headtwo = ReverseLinkedList(headnodetwo);

            Node dummy = new Node();
            Node current = dummy;

            int carry = 0;
            while (headone != null && headtwo != null)
            {
                int sum = headone.Data + headtwo.Data + carry;
                int reminder = sum % 10;
                carry = sum / 10;
                Node n = new Node(reminder);
                current.Next = n;
                current = current.Next;

                headone = headone.Next;
                headtwo = headtwo.Next;
            }

            while (headone != null)
            {
                int sum = headone.Data + carry;
                int reminder = sum % 10;
                carry = sum / 10;
                Node n = new Node(reminder);
                current.Next = n;
                current = current.Next;

                headone = headone.Next;
            }

            while (headtwo != null)
            {
                int sum = headtwo.Data + carry;
                int reminder = sum % 10;
                carry = sum / 10;
                Node n = new Node(reminder);
                current.Next = n;
                current = current.Next;

                headtwo = headtwo.Next;
            }

            if (carry > 0)
            {
                Node n = new Node(1);
                current.Next = n;
            }
            headNode = headNode.Next;
            dummy = dummy.Next;
            result = ReverseLinkedList(dummy);


            while (result != null)
            {
                Console.Write(result.Data + " ");

                result = result.Next;
            }

        }

        //Check if string is palindrome 3-5-8-2-8-5-3 (Cracking Coding Interviews - 6)
        //time complixity O(n), space complixity O(n)
        //Space complixity can be reduced by reversing the half string and comparing it to the rest of the half
        public bool isPalindrome()
        {
            Node current = this.headNode;
            int mid = Count / 2;
            Stack<int> st = new Stack<int>();
            for (int i = 0; i < mid; i++)
            {
                st.Push(current.Data);
                current = current.Next;
            }
            //below case will handle odd number of Palindrome string
            if (Count % 2 != 0)
                current = current.Next;

            while (current != null)
            {
                int top = st.Pop();

                if (current.Data == top)
                    current = current.Next;
                else
                    return false;
            }

            return true;
        }


        //Find the intersection point (merge point) of the two Linked Lists
        //A = {5, 6, 7, 8, 9, 10} B = {1, 2, 3, 9, 10} - merge point is 9 (Cracking Coding Interviews - 7)
        //Brute force approach (by running two loops) will take O(m+n) where m is length of A and n is length of B
        public Node FindMergePoint(Node headNodeOne, Node headNodeTwo)
        {
            HashSet<int> hset = new HashSet<int>();
            while (headNodeOne != null)
            {
                hset.Add(headNodeOne.Data);
                headNodeOne = headNodeOne.Next;
            }
            while (headNodeTwo != null)
            {
                if (hset.Contains(headNodeTwo.Data))
                {
                    return headNodeTwo;
                }
                headNodeTwo = headNodeTwo.Next;
            }

            return null;
        }

        public Node FindIndex(Node headNode, int x)
        {
            if (headNode == null) throw new Exception("Please provide correct Index");
            while (headNode != null)
            {
                if (headNode.Data == x)
                    return headNode;

                headNode = headNode.Next;
            }
            return null;
        }

        //Compare two strings and written 
        //0 if both strings are same
        //1 if first linked list is lexicographically greater
        //-1 if second string is lexicographically greater
        public int CompareStrings(Node one, Node two)
        {
            if (one == null && two == null)
                return 1;

            while (one != null && two != null && one.Data == two.Data)
            {
                one = one.Next;
                two = two.Next;
            }

            if (one != null && two != null)
                return (one.Data > two.Data ? 1 : -1);

            if (one != null && two == null)
                return 1;

            if (one == null && two != null)
                return -1;

            return 0;
        }

        //Merge K linked list - O(nk logk)
        //this logic works only when individual linked lists are sorted else it fails
        public Node MergeKLists(Node[] lists)
        {
            int n = lists.Length;
            int last = n - 1;
            while (last != 0)
            {
                int i = 0; int j = last;
                while (i < j)
                {
                    lists[i] = SortedMerge(lists[i], lists[j]);

                    i++; j--;

                    if (i >= j)
                        last = j;
                }
            }
            return lists[0];
        }

        public Node SortedMerge(Node a, Node b)
        {
            Node result = null;

            if (a == null) return b;
            else if (b == null) return a;

            if (a.Data <= b.Data)
            {
                result = a;
                result.Next = SortedMerge(a.Next, b);
            }
            else
            {
                result = b;
                result.Next = SortedMerge(a, b.Next);
            }

            return result;
        }

        //Swap node values
        public void SwapNodeValuess(int x, int y)
        {
            if (x == y)
                Console.WriteLine("X & Y can not be same");

            Node current = this.headNode;

            for (int i = 0; i < Count; i++)
            {
                if (current.Data == x)
                    current.Data = y;
                else if (current.Data == y)
                    current.Data = x;

                current = current.Next;

            }
        }

        void swapNodes(Node a, Node b)
        {
            Node temp = a;
            a = b;
            b = temp;
        }

        //check if loop exists in LinkedList 2-3-4-5-2 - in this case 5 is again connecting to 2 so loop exixts
        public bool CheckLoop(Node headNode)
        {
            Node slow = headNode; Node fast = headNode;
            while (slow != null && fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;

                if (slow.Data == fast.Data)
                    return true;
            }
            return false;
        }
    }

    public class dLinkedList
    {
        private Node headNode;
        private int size;

        public dLinkedList()
        {
            this.headNode = null;
            this.size = 0;
        }

        public Node HeadNode
        {
            get { return this.headNode; }
            set { this.headNode = value; }
        }
        public bool IsEmpty
        {
            get { return size == 0; }
        }
        public int Count
        {
            get { return this.size; }
        }

        //below function adds new node at the begning of the list
        public int addDLLNode_front(int data)
        {
            Node new_Node = new Node(data);

            new_Node.Next = headNode;
            new_Node.Previous = null;

            if (headNode != null)
                headNode.Previous = new_Node;

            headNode = new_Node;

            return data;
        }

        //below method adds new node after the node that is provided in the method as parameter 
        public int addDLLNode_mid(Node Prev_node, int data)
        {
            if (Prev_node == null)
                Console.WriteLine("Previous Node can not be null...");

            Node new_node = new Node(data);

            new_node.Next = Prev_node.Next;
            Prev_node.Next = new_node;
            new_node.Previous = Prev_node;

            if (new_node.Next != null)
                new_node.Next.Previous = new_node;


            return data;
        }

        //this method adds new node at the end of the list
        public int addDLLNode_end(int data)
        {
            Node new_Node = new Node(data);
            Node current = headNode;

            new_Node.Next = null;
            if (current == null)
            {
                new_Node.Previous = null;
                new_Node = headNode;
                return data;
            }

            while (current.Next != null)
                current = current.Next;

            current.Next = new_Node;
            new_Node.Previous = current;

            return data;
        }

        //Coding for deletion is not yet completed
        public void DeleteDLLNode(Node headNode, int data)
        {
            if (headNode == null) return;
            if (headNode.Data == data)
            {
                headNode = headNode.Next;
                headNode.Previous = null;
            }




        }

        public void PrintDLinkeList(Node headNode)
        {
            Node last = null;
            Console.Write("Forward order -" + " ");
            while (headNode != null)
            {
                Console.Write(headNode.Data + " ");
                last = headNode;
                headNode = headNode.Next;
            }
            Console.WriteLine();
            Console.Write("Reverse Order -" + " ");
            while (last != null)
            {
                Console.Write(last.Data + " ");
                last = last.Previous;
            }
        }

        //Clone Doubly linked list where one pointer will be pointed to next node and 
        //the other Node will be pointed to any arbitary Node
        public Node CloneDLL(Node headNode)
        {
            Node current = headNode, temp;
            while (current != null)
            {
                temp = current.Next;

                current.Next = new Node(current.Data);
                current.Next.Next = temp;
                current = temp;
            }
            current = headNode;
            while (current != null)
            {
                current.Next.Random = current.Random.Next;

                current = current.Next;
            }

            Node original = headNode;
            Node copy = headNode.Next;

            temp = copy;

            while (original != null && copy != null)
            {
                original = original.Next.Next;
                copy = copy.Next.Next;

                original = original.Next;
                copy = copy.Next;
            }
            return temp;
        }

        public void PrintClonedDLL(Node headNode)
        {
            Node current = headNode;
            while (current != null)
            {
                Console.WriteLine("Data :{0} Random: {1}:", current.Data, current.Random.Data);
            }
        }
    }
}
