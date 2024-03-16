using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnapSack
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution obj = new Solution();
            List<int> A = new List<int>() { 359, 963, 465, 706, 146, 282, 828, 962, 492 };
            List<int> B = new List<int>() { 96, 43, 28, 37, 92, 5, 3, 54, 93 };
            int answer = obj.solve(A,B, 383);

            Console.Read();
        }
    }

    class Solution
    {

        List<List<int>> DP = new List<List<int>>();
        public int solve(List<int> A, List<int> B, int C)
        {

            int N = A.Count;
            int W = C;

            for (int i = 0; i <= N; i++)
            {
                List<int> dpItem = new List<int>();
                for (int j = 0; j <= W; j++)
                {
                    dpItem.Add(-1);
                }

                DP.Add(dpItem);
            }



            int ans = MaxKnapSack(A, B, N, W);

            return ans;
        }
        public int MaxKnapSack(List<int> A, List<int> B, int i, int j)
        {
            if (i == 0 || j == 0)
            {
                return 0;
            }

            if (DP[i][j] != -1)
            {
                return DP[i][j];
            }

            int f1 = 0 + MaxKnapSack(A, B, i - 1, j);
            int f2 = 0;

            if (B[i - 1] <= j)
            {
                f2 = A[i - 1] + MaxKnapSack(A, B, i - 1, j - B[i-1]);
            }

            DP[i][j] = Math.Max(f1, f2);

            return DP[i][j];

        }
    }

}
