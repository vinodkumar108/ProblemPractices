using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximomXor
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution objSol = new Solution();
            List<int> inputList = new List<int> { 5, 17, 100, 11 };
            int answer = objSol.solve(inputList);
            Console.Read();
        }
    }
    class Solution
    {

        public Node root = new Node(-1);

        public int solve(List<int> A)
        {

            //Get Maximum bit count
            int bitSize = GetMaxBitSize(A);
            int answer = 0;

            //Insert all items in Trie
            for (int j = 0; j < A.Count; j++)
            {
                InsertTrie(A[j], bitSize);
            }

            for (int i = 0; i < A.Count; i++)
            {
                int xor = 0;
                Node curr = root;
                int val = A[i];

                for (int k = bitSize - 1; k >= 0; k--)
                {
                    
                    int bitItem = val >> k;
                    if (bitItem == 1)
                    {
                        if (curr.childrens[0] != null)
                        {
                            xor = xor | (1 << k);
                            curr = curr.childrens[0];
                        }
                        else
                        {
                            curr = curr.childrens[1];
                        }
                    }
                    else
                    {

                        if (curr.childrens[1] != null)
                        {
                            xor = xor | (1 << k);
                            curr = curr.childrens[1];
                        }
                        else
                        {
                            curr = curr.childrens[0];
                        }
                    }

                    val = val >> 1;
                }

                answer = Math.Max(xor, answer);
            }

            return answer;
        }
        public int GetMaxBitSize(List<int> A)
        {
            int maxItem = Int16.MinValue;
            int bitSize = 0;

            foreach (int item in A)
            {
                if (item > maxItem)
                {
                    maxItem = item;
                }
            }

            while (maxItem > 0)
            {
                maxItem = maxItem >> 1;
                bitSize++;
            }

            return bitSize;

        }
        public void InsertTrie(int nodeVal, int bitSize)
        {
            Node curr = root;

            while (bitSize > 0)
            {
                int val = nodeVal >> (bitSize - 1);

                if (curr.childrens[val] == null)
                {
                    curr.childrens[val] = new Node(val);
                }

                curr = curr.childrens[val];
                nodeVal = nodeVal >> 1;
                bitSize--;
            }
        }
    }

    class Node
    {
        public int val;
        public Node[] childrens;
        public Node(int x)
        {
            this.val = x;
            this.childrens = new Node[2];
        }
    }

}
