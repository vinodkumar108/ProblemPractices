using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursionsBackTrackings
{
    class Program
    {
        static void Main(string[] args)
        {
            //PowerFun obj = new PowerFun();
            //long ans = obj.Solve(2, 33);
            //Console.WriteLine("ANNWER:" + ans);

            Solution sol = new Solution();

            List<String> ans = sol.generateParenthesis(3);

            Console.WriteLine("Method Call Completed, Find Below Result:");
            foreach(String st in ans)
            {
                Console.WriteLine(st);
            }

            Console.Read();
        }
    }
    class PowerFun
    {
        public long Solve(int n,int pow)
        {
            long number = n;
            long powerVal = pow;

            long ans = Power(number, powerVal);
            return ans;
        }
        public long Power(long n, long pow)
        {
            if(pow == 1)
            {
                return n;
            }
            else
            {
                return n * Power(n, pow - 1);
            }
        }
    }
    class Solution
    {
        public List<string> generateParenthesis(int A)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            List<string> result = new List<string>();
            Generate(A, A, sb, result);
            return result;
        }

        private void Generate(int open, int close, System.Text.StringBuilder sb, List<string> result)
        {
            if (open == 0 && close == 0) // Base Case, add to result only if we’ve used up all Open and Close.
                result.Add(sb.ToString());

            if (open > 0) // Append Open only if Open > 0
            {
                sb.Append("(");
                Generate(open - 1, close, sb, result); // Used up an Open, so reduce Open count and perform recursive call.
                sb.Length--; // Drop Last Char
            }

            if (close > 0 && open < close) // Add a Close only if we had already appended an Open.
            {
                sb.Append(")");
                Generate(open, close - 1, sb, result); // Used up a Close, reduce Close count and perform recursive call.
                sb.Length--;
            }
        }
    }
}
