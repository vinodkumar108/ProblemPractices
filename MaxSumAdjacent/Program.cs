using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxSumAdjacent
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    class Solution
    {
        public int adjacent(List<List<int>> A)
        {
            int n = A[0].Count;
            int[] DP = new int[n];
            int answer = Solve(A, DP, n);
            return answer;
        }
        public int Solve(List<List<int>> A, int[] dp, int n)
        {
            dp[0] = Math.Max(A[0][0], A[1][0]);

            if (A[0].Count > 1)
                dp[1] = Math.Max(dp[0], Math.Max(A[1][1], A[0][1]));

            for (int i = 2; i < n; i++)
            {
                int t = Math.Max(A[0][i], A[1][i]) + dp[i - 2];
                int dt = dp[i - 1];
                dp[i] = Math.Max(t, dt);
            }

            return dp[n - 1];

        }
    }

}
