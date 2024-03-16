using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistinctWindow
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = new List<int> { 1, 2, 1, 3, 4, 3 };
            List<int> result = dNums(input, 3);
            Console.Read();
        }
        public static List<int> dNums(List<int> A, int B)
        {

            int N = A.Count;
            Dictionary<int, int> aDictList = new Dictionary<int, int>();
            List<int> result = new List<int>();

            if (B > N) return result;

            for (int i = 0; i < B; i++)
            {
                if (aDictList.ContainsKey(A[i]))
                {
                    aDictList[A[i]] = aDictList[A[i]] + 1;
                }
                else
                {
                    aDictList[A[i]] = 1;
                }
            }

            if (aDictList.Count > 0)
            {
                result.Add(aDictList.Count);
            }

            for (int j = 1; j < N - B + 1; j++)
            {
                if (aDictList.ContainsKey(A[j - 1]))
                {
                    aDictList[A[j-1]] = aDictList[A[j-1]] - 1;

                    if (aDictList[A[j-1]] == 0) aDictList.Remove(A[j-1]);
                }

                if (aDictList.ContainsKey(A[j + B - 1]))
                {
                    aDictList[A[j + B - 1]] = aDictList[A[j + B - 1]] + 1;
                }
                else
                {
                    aDictList[A[j + B - 1]] = 1;
                }

                result.Add(aDictList.Count);
            }

            return result;
        }
    }
}
