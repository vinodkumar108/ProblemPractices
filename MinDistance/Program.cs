using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinDistance
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution obj = new Solution();
            int ans = obj.minDistance("aac", "abac");
            Console.Read();

        }
        class Solution
        {

            List<List<int>> DP = new List<List<int>>();
            public int minDistance(string A, string B)
            {

                int N = A.Length;
                int M = B.Length;

                if (N == 1 && M == 1 && A != B)
                {
                    return 1;
                }

                for (int i = 0; i < N; i++)
                {
                    List<int> dpRow = new List<int>();
                    for (int j = 0; j < M; j++)
                    {
                        dpRow.Add(-1);
                    }

                    DP.Add(dpRow);
                }

                int ans = CalculateMinSteps(A, B, N - 1, M - 1);

                return ans;
            }

            public int CalculateMinSteps(string S1, string S2, int i, int j)
            {
                if (i < 0 && j < 0)
                {
                    return 0;
                }
                else if (i < 0)
                {
                    return (j + 1);
                }
                else if (j < 0)
                {
                    return (i + 1);
                }

                if (DP[i][j] != -1)
                {
                    return DP[i][j];
                }

                if (S1[i] == S2[j])
                {
                    DP[i][j] = CalculateMinSteps(S1, S2, i - 1, j - 1);
                }
                else
                {
                    int f1 = Math.Min((1+CalculateMinSteps(S1, S2, i, j - 1)), (1+CalculateMinSteps(S1, S2, i - 1, j)));
                    int f2 = 1+CalculateMinSteps(S1, S2, i - 1, j - 1);
                    DP[i][j] = Math.Min(f1, f2);
                }

                return DP[i][j];
            }
        }

    }
}
