using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoPointers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lstItems = new List<int> { 8, 5, 1, 10, 5, 9, 9, 3, 5, 6, 6, 2, 8, 2, 2, 6, 3, 8, 7, 2, 5, 3, 4, 3, 3, 2, 7, 9, 6, 8, 7, 2, 9, 10, 3, 8, 10, 6, 5, 4, 2, 3 };

            int countResult = solve(lstItems, 3);

            Console.Read();
        }
        public static int solve(List<int> A, int B)
        {

            if (A.Count == 1) return 0;

            int i = 0;
            int j = 1;
            int totalCount = 0;

            A.Sort();

            while (j < A.Count)
            {
                if (i > 0 && A[i] == A[i- 1] && A[j] == A[j - 1])
                {
                    // this condition is for test cases like [1,1,1,1,1,1] , [1,1,2, 2, 2] to avoid ArrayIndexOutofBound and extra count value
                    i++;
                    j++;
                    continue;
                }


                if (Math.Abs(A[j] - A[i]) == B)
                {
                    totalCount++;

                    if (i < A.Count) i++;
                    if (j < A.Count) j++;
                }

                if (Math.Abs(A[j] - A[i]) > B)
                {
                    i++;
                    if (i == j) { j++; }

                }
                else
                {
                    j++;
                }

                
            }

            return totalCount;
        }
    }
}
