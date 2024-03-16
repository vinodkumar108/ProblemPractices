using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RusianDollEnvelope
{
    class Program
    {
        static void Main(string[] args)
        {
            List<List<int>> list = new List<List<int>>
            {
               new List<int> {5,4},
               new List<int> {6,4},
               new List<int>() {6,7},              
               new List<int>() {2,3}
            };

            Solution obj = new Solution();

            obj.solve(list);

            Console.Read();


        }
        class Solution
        {
            public int solve(List<List<int>> A)
            {

                A = A.OrderBy(x => x[0]).ToList();

                int[] DP = new int[A.Count];

                for (int i = 0; i < A.Count; i++)
                {
                    DP[i] = -1;
                }

                int ans = 1;

                for(int i=0;i<A.Count;i++)
                {
                    ans = Math.Max(ans, CalulateLIS(A, i, DP));
                }

                return ans;
            }
            public int CalulateLIS(List<List<int>> A,int i, int[] DP)
            {
                if(DP[i] != -1)
                {
                    return DP[i];
                }

                int max = 0;

                for(int j=0;j<i;j++)
                {
                    if(A[j][0] < A[i][0] && A[j][1] < A[i][1])
                    {
                        max = Math.Max(max, CalulateLIS(A, j, DP));
                    }
                    
                }

                DP[i] = max + 1;

                return max + 1;
            }
        }

    }
}
