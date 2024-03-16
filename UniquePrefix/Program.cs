using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniquePrefix
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution objSol = new Solution();

            List<string> lstInput = new List<string> { "bearcat", "bert" };

            List<string> output = objSol.prefix(lstInput);

            Console.Read();

        }
    }

    class Solution
    {
        public Node head = new Node('1');
        public List<string> prefix(List<string> A)
        {

            List<string> ans = new List<string>();

            int n = A.Count;
            for (int i = 0; i < n; i++)
            {
                InsertChar(A[i]);
            }

            for (int i = 0; i < n; i++)
            {
                ans.Add(searchword(A[i]));
            }
            return ans;
        }
        public void InsertChar(string word)
        {
            int l = word.Length;
            Node cur = head;
            for (int j = 0; j < l; j++)
            {
                int idx = word[j] - 'a';
                if (cur.Children[idx] == null)
                {                    
                    cur.Children[idx] = new Node(word[j]);
                }
                cur = cur.Children[idx];
                cur.startCount = cur.startCount + 1;
            }
            cur.IsEnd = true;
        }

        public string searchword(string word)
        {
            string uniquPrefix = string.Empty;
            int l = word.Length;
            Node cur = head;
            for (int j = 0; j < l; j++)
            {
                int idx = word[j] - 'a';
                if (cur.startCount == 1)
                {
                    break;
                }
                cur = cur.Children[idx];
                uniquPrefix = uniquPrefix + Convert.ToString(cur.val);
            }

            return uniquPrefix;
        }
    }

    class Node
    {
        public char val;
        public Node[] Children;
        public bool IsEnd;
        public int startCount;
        public Node(char x)
        {
            this.val = x;
            this.IsEnd = false;
            this.Children = new Node[26];
        }
    }

}
