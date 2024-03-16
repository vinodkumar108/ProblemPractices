using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancedParenthses
{
    class Program
    {
        static void Main(string[] args)
        {
           
            int result = solve("))))))))");
            Console.Read();
        }
        public static int solve(string A)       
        {

            Stack<char> chStack = new Stack<char>();

            foreach (var ch in A)
            {
                if (ch == '(' || ch == '{' || ch == '[')
                {
                    chStack.Push(ch);
                }
                else if (ch == ')' || ch == '}' || ch == ']')
                {
                    if (chStack.Count > 0)
                    {
                        char topCh = chStack.Peek();
                        if (topCh == '(' && ch == ')'
                            || topCh == '{' && ch == '}'
                            || topCh == '[' && ch == ']')
                        {
                            chStack.Pop();
                        }
                    }
                    else
                    {
                        chStack.Push(ch);
                    }
                }
            }

            if (chStack.Count > 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }

        }
    }
}
