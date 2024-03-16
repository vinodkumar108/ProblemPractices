using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListRev
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    class Node
    {
        public Node next;
        public int data;

        public Node(int d)
        {
            this.data = d;
            this.next = null;
        }
    }
    class DNode
    {
        public DNode prev;
        public DNode next;
        public int key;  
        
        public DNode(int k)
        {
            this.key = k;
            this.prev = null;
            this.next = null;
        }

    }

    class LRUCache
    {
        DNode head = null;
        DNode tail = null;
        Dictionary<int, DNode> dicLRU = new Dictionary<int, DNode>();
        int capacity = 5;

        //Search and found, then remove that item and insert it in head
        //Search and not found - 1: already capacity reach - Remove from tail and Insert at head
        //                       2: Insert at head
        public void RemoveFromTail()
        {
            KeyValuePair<int,DNode> nodeToDelete = dicLRU.ElementAt(capacity - 1);
            RemoveItem(nodeToDelete.Key);
        }

        public void RemoveItem(int x)
        {
            DNode nodeToDelete = dicLRU[x];
            if(dicLRU.Count > 0)
            {
                DNode prev = nodeToDelete.prev;
                DNode next = nodeToDelete.next;

                prev.next = next;
                next.prev = prev;
            }

            dicLRU.Remove(x);

        }

        public void InsertAtHead(int x)
        {
            DNode newNode = new DNode(x);

            newNode.next = head;
            newNode.prev = null;
            head.prev = newNode;
            head = newNode;

            dicLRU.Add(x, newNode);
        }

        public bool Search(int x)
        {
            if(dicLRU.Count > 0)
            {
                return (dicLRU.ContainsKey(x));
            }

            return false;
        }
        
        public void Insert(int x)
        {
            bool isItemFound = Search(x);

            if(isItemFound)
            {
                RemoveItem(x);
                InsertAtHead(x);
            }
            else 
            {
                if(dicLRU.Count == capacity)
                {
                    RemoveFromTail();
                    InsertAtHead(x);
                }
                else
                {
                    InsertAtHead(x);
                }
            }
        }


    }

    class MiddleElement
    {
        public int Solve(Node A)
        {
            Node fhead = A;
            Node shead = A;

            while(fhead != null && fhead.next != null)
            {
                shead = shead.next;
                fhead = fhead.next.next;
            }

            return shead.data;

        }
    }
}
