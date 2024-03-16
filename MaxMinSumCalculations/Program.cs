using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxMinSumCalculations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputList = new List<int> { 4, 7, 3, 8 };
            int sum = solve(inputList);
            Console.Read();
        }
        public static int solve(List<int> A)
        {
            List<int> NSL = prevSmaller(A);
            List<int> NSR = nextSmaller(A);
            List<int> NGL = prevGreater(A);
            List<int> NGR = nextGreater(A);

            long maxsum = 0;
            long minsum = 0;
            for(int i=0;i<A.Count;i++)
            {
                maxsum = maxsum + (A[i] * (i - NGL[i]) * (NGR[i] - i));
            }

            for (int i = 0; i < A.Count; i++)
            {
                minsum = minsum + (A[i] * (i - NSL[i]) * (NSR[i] - i));
            }

            return (int)(maxsum - minsum);
        }
        public static List<int> prevSmaller(List<int> A)
        {

            Stack<int> objStack = new Stack<int>();
            List<int> result = new List<int>();

            for (int i = 0; i < A.Count; i++)
            {
                if (objStack.Count > 0)
                {
                    while (objStack.Count > 0 && A[objStack.Peek()] >= A[i])
                    {
                        objStack.Pop();
                    }

                    if (objStack.Count > 0 && A[objStack.Peek()] < A[i])
                    {
                        result.Add(objStack.Peek());
                        objStack.Push(i);
                    }
                    else
                    {
                        objStack.Push(i);
                        result.Add(-1);
                    }
                }
                else
                {
                    objStack.Push(i);
                    result.Add(-1);
                }
            }

            return result;
        }
        public static List<int> nextSmaller(List<int> A)
        {

            Stack<int> objStack = new Stack<int>();
            List<int> result = new List<int>();

            for (int i = A.Count - 1; i >= 0; i--)
            {
                if (objStack.Count > 0)
                {
                    while (objStack.Count > 0 && A[objStack.Peek()] >= A[i])
                    {
                        objStack.Pop();
                    }

                    if (objStack.Count > 0 && A[objStack.Peek()] < A[i])
                    {
                        result.Add(objStack.Peek());
                        objStack.Push(i);
                    }
                    else
                    {
                        objStack.Push(i);
                        result.Add(A.Count);
                    }
                }
                else
                {
                    objStack.Push(i);
                    result.Add(A.Count);
                }
            }

            result.Reverse();

            return result;
        }
        public static List<int> nextGreater(List<int> A)
        {
            Stack<int> objStack = new Stack<int>();
            List<int> result = new List<int>();

            for (int i = A.Count - 1; i >= 0; i--)
            {
                if (objStack.Count > 0)
                {
                    while (objStack.Count > 0 && A[objStack.Peek()] <= A[i])
                    {
                        objStack.Pop();
                    }

                    if (objStack.Count > 0 && A[objStack.Peek()] > A[i])
                    {
                        result.Add(objStack.Peek());
                        objStack.Push(i);
                    }
                    else
                    {
                        objStack.Push(i);
                        result.Add(A.Count);
                    }
                }
                else
                {
                    objStack.Push(i);
                    result.Add(A.Count);
                }
            }

            result.Reverse();

            return result;

        }
        public static List<int> prevGreater(List<int> A)
        {

            Stack<int> objStack = new Stack<int>();
            List<int> result = new List<int>();

            for (int i = 0; i < A.Count; i++)
            {
                if (objStack.Count > 0)
                {
                    while (objStack.Count > 0 && A[objStack.Peek()] <= A[i])
                    {
                        objStack.Pop();
                    }

                    if (objStack.Count > 0 && A[objStack.Peek()] > A[i])
                    {
                        result.Add(objStack.Peek());
                        objStack.Push(i);
                    }
                    else
                    {
                        objStack.Push(i);
                        result.Add(-1);
                    }
                }
                else
                {
                    objStack.Push(i);
                    result.Add(-1);
                }
            }

            return result;
        }
    }
}
