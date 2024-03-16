using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnapSackUnlimited
{
    class Program
    {
        static void Main(string[] args)
        {
            //10
            //[5]
            //[10]

            List<int> B = new List<int> { 5 };
            List<int> C = new List<int> { 10 };
            int A = 10;

            Solution objSol = new Solution();
            int result = objSol.solve(A, B, C);

            Console.Read();

        }
    }
    class Solution
    {
        public int solve(int A, List<int> B, List<int> C)
        {
            int W = A;
            int N = B.Count;

            int[] DP = new int[W + 1];

            for (int i = 1; i <= W; i++)
            {
                for (int j = 1; j <= N; j++)
                {
                    if (C[j - 1] <= i)
                    {
                        DP[i] = Math.Max(DP[i], (B[j - 1] + DP[i - C[j - 1]]));
                    }
                }
            }

            return DP[W];

        }
    }

}
