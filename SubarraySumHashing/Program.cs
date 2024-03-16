using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubarraySumHashing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lstInput = new List<int> { -2, 16, -12, 5, 7, -1, 2, 12, 11 };
            int result = solve(lstInput,17);
            Console.Read();
        }
        public static int solve(List<int> A, int B)
        {
            int count = 0;
            Dictionary<int, int> hm = new Dictionary<int, int>();
            hm.Add(0, 1);

            for (int i = 1; i < A.Count; i++)
            {
                A[i] = A[i] + A[i - 1];
            }

            for (int j = 0; j < A.Count; j++)
            {
                if (hm.ContainsKey(A[j] - B))
                {
                    count += hm[A[j] - B];
                }

                if (hm.ContainsKey(A[j]))
                {
                    hm[A[j]] += 1;
                }
                else
                {
                    hm.Add(A[j], 1);
                }
            }
            return count;
        }
    }
}
