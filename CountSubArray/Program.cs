using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountSubArray
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lstInput = new List<int> { 30, -30, 30, -30 };
            int res = solve(lstInput);
            Console.Read();

        }
        public static int solve(List<int> A)
        {

            Dictionary<long, int> hashMapList = new Dictionary<long, int>();
            List<long> aPrefSum = new List<long>();
            long sum = 0;
            int resCount = 0;

            if (A.Count == 1 && A[0] == 0) return 1;

            for (int i = 0; i < A.Count; i++)
            {
                sum = sum + A[i];

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
                
                if (key == 0)
                {
                    int countPlus = hashMapList[key]+(hashMapList[key]-1);
                    resCount = (resCount + countPlus) % (1000000000 + 7);
                }
                else if (hashMapList[key] > 1)
                {
                    int countPlus = hashMapList[key] - 1;
                    resCount = (resCount + countPlus) % (1000000000 + 7);
                }
            }

            return resCount;
        }
    }
}
