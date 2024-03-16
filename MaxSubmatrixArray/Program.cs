using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxSubmatrixArray
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        public long solve(List<List<int>> A)
        {
            int N = A.Count - 1;
            int M = A[0].Count - 1;          
            long max = -1000000000;            
            long[,] array2DS = new long[N+1, M+1];

            if (N == 0 && M == 0) return (long)A[N][M];

            for (int i = N; i >= 0; i--)
            {              

                for (int k = M; k >= 0; k--)
                {
                    if (i + 1 > N && k + 1 > M)
                    {
                        array2DS[i,k] = A[i][k];
                    }
                    else if (i + 1 > N)
                    {
                        array2DS[i,k] = (A[i][k] + array2DS[i,k + 1]);
                    }
                    else if (k + 1 > M)
                    {
                        array2DS[i,k] = (A[i][k] + array2DS[i + 1,k]);
                    }
                    else
                    {
                        array2DS[i,k] = (A[i][k] + array2DS[i,k + 1] + array2DS[i + 1,k] - array2DS[i + 1,k + 1]);
                    }

                    max = Math.Max(max, array2DS[i,k]);
                }
            }

            return max;

        }
    }
}
