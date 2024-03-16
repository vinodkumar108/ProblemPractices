using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnapsackFlipArray
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> A = new List<int> { 8, 4, 5, 7, 6, 2 };
            Solution obj = new Solution();
            int res =obj.solve(A);
            Console.Read();
        }
    }
    class Solution
    {
        public int solve(List<int> A)
        {

            int sum = 0;
            int N = A.Count;

            for (int i = 0; i < N; i++)
            {
                sum += A[i];
            }

            int W = sum / 2;

            //Make tuple list with N+1 * W+1 dimension and set all value with 0
            //First tumple item is sum and second item is count of items included
            List<List<Tuple<int, int>>> listAll = new List<List<Tuple<int, int>>>();

            for (int j = 0; j <= N; j++)
            {
                List<Tuple<int, int>> listRow = new List<Tuple<int, int>>();
                for (int k = 0; k <= W; k++)
                {
                    Tuple<int, int> tuple = new Tuple<int, int>(0, 0);
                    listRow.Add(tuple);
                }

                listAll.Add(listRow);
            }

            for (int j = 1; j <= N; j++)
            {
                for (int k = 1; k <= W; k++)
                {
                    if (A[j-1] > k)
                    {
                        listAll[j][k] = listAll[j - 1][k];
                    }
                    else
                    {
                        Tuple<int, int> tuple1 = listAll[j - 1][k];
                        Tuple<int, int> tuple2 = listAll[j - 1][k - A[j-1]];
                        Tuple<int, int> finalCalTuple = new Tuple<int, int>(tuple2.Item1 + A[j-1], tuple2.Item2 + 1); ;

                        listAll[j][k] = CompareFinalDP(tuple1, finalCalTuple, W);
                    }
                }
            }

            Tuple<int, int> finalTupleItem = listAll[N][W];

            return finalTupleItem.Item2;
        }

        public Tuple<int, int> CompareFinalDP(Tuple<int, int> T1, Tuple<int, int> T2, int W)
        {
            if (T1.Item1 == T2.Item1)
            {
                if (T1.Item2 < T2.Item2)
                {
                    return T1;
                }
                else
                {
                    return T2;
                }
            }
            else
            {

                if (T2.Item1 <= W && T2.Item1 > T1.Item1)
                {
                    return T2;
                }
                else
                {
                    return T1;
                }

            }
        }
    }

}
