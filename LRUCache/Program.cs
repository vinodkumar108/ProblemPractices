using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRUCache
{
    class Program
    {
        static void Main(string[] args)
        {
            //Solution objSol = new Solution(2);
            //objSol.set(1, 10);
            //objSol.set(5, 12);
            //var val = objSol.get(5);
            //val = objSol.get(1);
            //objSol.set(6, 15);//push out key 5
            //val = objSol.get(5);

            //6 1 S 2 1 S 2 2 G 2 S 1 1 S 4 1 G 2
            //5 1 S 2 1 G 2 S 3 2 G 2 G 3
            Solution objSol = new Solution(1);
            objSol.set(2, 1);
            var val = objSol.get(2);
            objSol.set(3, 2);
            val = objSol.get(2);
            val = objSol.get(3);
            
            Console.Read();

        }
    }
    class Solution
    {        
        Node head, tail;
        Dictionary<int, Node> lstDictionary;
        int mxCount = 0;

        public Solution(int capacity)
        {
            mxCount = capacity;           
            lstDictionary = new Dictionary<int, Node>(); 
            head = new Node(0, 0);
            tail = new Node(0, 0);
            head.next = tail;
            tail.prev = head;           
        }
        public void Remove(int key, int value)
        {
            Node nodeObj = (Node)lstDictionary[key];
            lstDictionary.Remove(key);
            nodeObj.next.prev = nodeObj.prev;
            nodeObj.prev.next = nodeObj.next;

        }
        public void AddToTail(int key, Node x)
        {
            lstDictionary.Add(key, x);
            x.next = tail;
            x.prev = tail.prev;
            tail.prev.next = x;
            tail.prev = x;
        }

        public int get(int key)
        {

            if (lstDictionary.ContainsKey(key))
            {
                Node nodeObj = (Node)lstDictionary[key];
                Remove(key, nodeObj.val);
                Node newNode = new Node(key, nodeObj.val);
                AddToTail(key, newNode);
                return nodeObj.val;
            }
            else
                return -1;
        }

        public void set(int key, int value)
        {

            if (lstDictionary.ContainsKey(key))
            {
                Node nodeObj = (Node)lstDictionary[key];
                Remove(key, nodeObj.val);
                Node newNode1 = new Node(key, value);
                AddToTail(key, newNode1);
            }
            else
            {
                if (lstDictionary.Count == mxCount)
                {
                    Remove(head.next.key, head.next.val);
                }

                Node newNode = new Node(key, value);
                AddToTail(key, newNode);
            }
           
        }
    }

    public class Node
    {
        public Node prev, next;
        public int key;
        public int val;
        public Node(int k, int v) { key = k; val = v; }
    }

}
