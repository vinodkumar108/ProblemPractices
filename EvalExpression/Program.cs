using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvalExpression
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        public int evalRPN(List<string> A)
        {
            Stack<string> stack = new Stack<string>();
            long result = 0;

            foreach (var str in A)
            {
                if (str.ToString() == "+"
                    || str.ToString() == "-"
                    || str.ToString() == "*"
                    || str.ToString() == "/")
                {
                    if (stack.Count > 1)
                    {
                        string num2 = stack.Pop();
                        string num1 = stack.Pop();
                        result = executeExp((long)Convert.ToDouble(num1), (long)Convert.ToDouble(num2), str);
                        stack.Push(result.ToString());
                    }
                    else
                    {
                        stack.Push(str.ToString());
                    }
                }
                else
                {
                    stack.Push(str);
                }
            }

            return (int)result;
        }
        public long executeExp(long num1, long num2, string exp)
        {
            if (exp == "+") return (num1 + num2);
            else if (exp == "-") return (num1 - num2);
            else if (exp == "*") return (num1 * num2);
            else if (exp == "/") return (num1 / num2);

            return 0;
        }
    }
}
