using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellChecker
{
    
    class Program
    {
        public static Node root = new Node('1');

        static void Main(string[] args)
        {
        }

        public static void InsertWord(string word)
        {
            Node curr = root;

            for(int i=0;i<word.Length;i++)
            {
                char charVal = word[i];

                if(curr.childrens[charVal-'a'] == null)
                {
                    curr.childrens[charVal - 'a'] = new Node(charVal);                   
                }

                curr = curr.childrens[charVal - 'a'];
            }

            curr.IsEnd = true;

        }

        public static bool SearchWord(string word)
        {
            Node curr = root;

            for (int i = 0; i < word.Length; i++)
            {
                char charVal = word[i];

                if (curr.childrens[charVal - 'a'] == null)
                {
                    return false;
                }

                curr = curr.childrens[charVal - 'a'];
            }

            return curr.IsEnd ? true : false;
        }
    }
    class Node
    {
        public char val;
        public Node[] childrens;
        public bool IsEnd;

        public Node(char x)
        {
            val = x;
            IsEnd = false;
            this.childrens = new Node[26];
        }
    }
}
