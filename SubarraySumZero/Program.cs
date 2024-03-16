using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubarraySumZero
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lstArr = new List<int> { 96, -71, 18, 66, -39, -32, -16, -83, -11, -92, 55, 66, 93, 5, 50, -45, 66, -28, 69, -4, -34, -87, -32, 7, -53, 33, -12, -94, -80, -71, 48, -93, 62 };

            int res = solve(lstArr, lstArr.Count);
            Console.Read();

        }
        public static int solve(List<int> A, int B)
        {
            // Just write your code below to complete the function. Required input is available to you as the function arguments.
            // Do not print the result or any output. Just return the result via this function.
            Dictionary<int, int> hashMapList = new Dictionary<int, int>();
            List<int> aPrefSum = new List<int>();
            int sum = 0;
            for (int i = 0; i < A.Count; i++)
            {
                sum = sum + A[i];

                if (sum == 0)
                    return 1;

                aPrefSum.Add(sum);

                if (hashMapList.ContainsKey(sum))
                {
                    int count = hashMapList[sum];
                    hashMapList[sum] = count + 1;
                }
                else
                {
                    hashMapList[sum] = 1;
                }
            }

            foreach (var key in hashMapList.Keys)
            {
                if (hashMapList[key] > 0)
                {
                    return 1;
                }
            }

            return 0;
        }
    }
}
