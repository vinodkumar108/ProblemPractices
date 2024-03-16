using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleCharsTrouble
{
    class Program
    {
        static void Main(string[] args)
        {
            string result = solve("cddfeffe");
            Console.Read();
        }
        public static string solve(string A)
        {
            Stack<char> chStack = new Stack<char>();

            foreach (var ch in A)
            {
                if (chStack.Count > 0)
                {
                    var topCh = chStack.Peek();
                    if (topCh == ch)
                    {
                        chStack.Pop();
                    }
                    else
                    {
                        chStack.Push(ch);
                    }
                }
                else
                {
                    chStack.Push(ch);
                }
            }

            string result = string.Empty;
            int N = chStack.Count;
            for (int i = 0; i < N; i++)
            {
                char ch = chStack.Peek();
                chStack.Pop();
                result = ch.ToString() + result;
            }

            return result;
        }
    }
}
