using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class Trie
    {
        private Node headNode;

        public Trie()
        {
            headNode = new Node();
        }

        public Node HeadNode
        {
            get { return this.headNode; }
            set { this.headNode = value; }
        }

        //Insert new Node
        public void InsertNode(string key)
        {
            Node current = this.headNode;
            int index;
            int n = key.Length;

            if (n == 0)
            {
                current.EndOfWord = true;
                return;
            }

            for (int i = 0; i < n; i++)
            {
                char c = key[i];
                index = c - 'a';
                if (current.arr[index] == null)
                    current.arr[index] = new Node();

                current = current.arr[index];

            }
            current.EndOfWord = true;
            current.WordCount++;
        }

        //Search Node in Trie
        public Node SearchNode(string s)
        {
            Node current = this.headNode;
            int n = s.Length;
            for (int i = 0; i < n; i++)
            {
                char c = s[i];
                int index = c - 'a';

                if (current.arr[index] != null)
                {
                    current = current.arr[index];
                }
                else
                {
                    return null;
                }
            }

            if (current == headNode)
                return null;

            return current;
        }

        //Return true if word is present in Trie
        public bool Search(string s)
        {
            Node current = this.SearchNode(s);

            if (current == null)
                return false;
            else if (current.EndOfWord)
                return true;

            return false;
        }

        //prefix search
        public bool PrefixSearch(string s)
        {
            Node current = this.SearchNode(s);
            if (current == null)
                return false;
            else
                return true;
        }

        //public void PrintTrie(Node headNode)
        //{
        //    if (headNode == null) return;
        //}      
    }
}
