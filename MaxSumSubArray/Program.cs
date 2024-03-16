using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxSumSubArray
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        public static int maxSubarray(int A, int B, List<int> C)
        {

            long maxArrSum = 0;
            long mxLimit = (long)B;

            for (int i = 0; i < A; i++)
            {
                long result = 0;

                for (int j = i; j < A; j++)
                {
                    result += (long)C[j];
                    if (result > maxArrSum && result < mxLimit)
                    {
                        maxArrSum = (long)result;
                    }
                }
            }
            return (int)maxArrSum;
        }
    }
}
