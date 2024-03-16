using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGreaterProblem
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        public List<int> nextGreater(List<int> A)
        {
            Stack<int> objStack = new Stack<int>();
            List<int> result = new List<int>();            

            for (int i = A.Count - 1; i >= 0; i--)
            {
                if (objStack.Count > 0)
                {
                    while (objStack.Count > 0 && objStack.Peek() <= A[i])
                    {
                        objStack.Pop();
                    }

                    if (objStack.Count > 0 && objStack.Peek() > A[i])
                    {
                        objStack.Push(objStack.Peek());
                        result.Add(A[i]);
                    }
                    else
                    {
                        objStack.Push(A[i]);
                        result.Add(-1);
                    }
                }
                else
                {
                    objStack.Push(A[i]);
                    result.Add(-1);
                }
            }

            result.Reverse();

            return result;

        }
    }
}
}
