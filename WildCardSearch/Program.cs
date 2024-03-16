using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildCardSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution obj = new Solution();
            int answer = obj.isMatch("bcaccbabaa", "bb*c?c*?");
            Console.Read();
        }
    }
    class Solution
    {

        List<List<int>> DP = new List<List<int>>();
        public int isMatch(string A, string B)
        {

            int N = A.Length;
            int M = B.Length;

            for (int i = 0; i < N; i++)
            {
                List<int> dpRow = new List<int>();
                for (int j = 0; j < M; j++)
                {
                    dpRow.Add(-1);
                }

                DP.Add(dpRow);
            }

            int ans = CheckWildCard(A, N - 1, B, M - 1);

            return ans;

        }
        public int CheckWildCard(string s1, int i, string s2, int j)
        {
            if (i < 0 && j < 0)
            {
                return 1;
            }
            else if (i < 0 && j > 0 && s2[j] == '*')
            {
                string s3 = s2.Substring(0, j+1);

                int a = s3.Distinct().Count();

                if (a == 1)
                {
                    return 1;
                }
                else if (i < 0 || j < 0)
                {
                    return 0;
                }
            }
            else if (i < 0 || j < 0)
            {
                return 0;
            }
        

            if (DP[i][j] != -1)
            {
                return DP[i][j];
            }

            if (s1[i] == s2[j] || s2[j] == '?')
            {
                DP[i][j] = CheckWildCard(s1, i - 1, s2, j - 1);
            }
            else if (s2[j] == '*')
            {
                DP[i][j] = Math.Max(CheckWildCard(s1, i, s2, j - 1), CheckWildCard(s1, i - 1, s2, j));
            }
            else
            {
                DP[i][j] = 0;
            }

            return DP[i][j];
        }
    }

}
