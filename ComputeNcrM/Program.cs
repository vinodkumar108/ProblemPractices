using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputeNcrM
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        public static int solve(int A, int B, int C)
        {

            int[] prev = new int[B + 1];
            int[] curr = new int[B + 1];

            prev[0] = 1;
            curr[0] = 1;

            for (int i = 1; i <= A; i++)
            {
                for (int j = 1; j <= B; j++)
                {
                    curr[j] = ((prev[j] % C) + (prev[j - 1] % C)) % C;
                }

                prev = curr.Clone() as int[];
            }

            return curr[B];

        }
    }
}
