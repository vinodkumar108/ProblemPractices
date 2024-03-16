using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackQueues
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
    class UserQueue
    {
        Stack<int> stackA ;
        Stack<int> stackB ;

        public UserQueue()
        {
            stackA = new Stack<int>();
            stackB = new Stack<int>();
        }

        public void Push(int x)
        {
            stackA.Push(x);
        }

        public int Pop()
        {
            if(stackA.Count > 0)
            {
                while(stackA.Count > 0)
                {
                    int val = stackA.Pop();
                    stackB.Push(val);
                }

                return stackB.Pop();
            }
            else
            {
                return stackB.Pop();
            }
        }

        public int Peek()
        {
            if (stackA.Count > 0)
            {
                while (stackA.Count > 0)
                {
                    int val = stackA.Pop();
                    stackB.Push(val);
                }

                return stackB.Peek();
            }
            else
            {
                return stackB.Peek();
            }
        }

        public bool IsEmpty()
        {
            if(stackB.Count > 0 || stackA.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


    }
    class NearestSmaller
    {
        public List<int> solve(List<int> A)
        {
            List<int> ansLst = new List<int>();
            Stack<int> stk = new Stack<int>();

            foreach(int intVal in A)
            {
                if(stk.Count > 0)
                {
                    while(stk.Peek() >= intVal)
                    {
                        stk.Pop();
                    }

                    if(stk.Count == 0)
                    {
                        ansLst.Add(-1);
                    }
                    else
                    {
                        ansLst.Add(stk.Peek());                        
                    }

                    stk.Push(intVal);

                }
                else  //Stack is empty
                {
                    ansLst.Add(-1);
                    stk.Push(intVal);
                }
            }

            return ansLst;
        }
    }

    class BalanceParenthesis
    {
        public bool solve(string A)
        {
            
            Stack<char> stCh = new Stack<char>();

            foreach(char ch in A)
            {
                if(ch == '(' || ch == '{' || ch == '[')
                {
                    stCh.Push(ch);
                }
                else if(ch == ')' || ch == '}' || ch == ']')
                {
                    if(stCh.Count > 0)
                    {
                        char ch1 = stCh.Peek();

                        if ((ch == ')' && ch1 == '(') || (ch == '}' && ch1 == '{') || (ch == ']' && ch1 == '['))
                        {
                            stCh.Pop();
                        }                        
                    }
                    else
                    {
                        stCh.Push(ch);
                    }
                    
                }
            }

            if(stCh.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}
