using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lstInts = new List<int> { 13, 13, 21, 21, 27, 50, 50, 102, 102, 108, 108, 110, 110, 117, 117, 120, 120, 123, 123, 124, 124, 132, 132, 164, 164, 166, 166, 190, 190, 200, 200, 212, 212, 217, 217, 225, 225, 238, 238, 261, 261, 276, 276, 347, 347, 348, 348, 386, 386, 394, 394, 405, 405, 426, 426, 435, 435, 474, 474, 493, 493 };
            int ans = solve(lstInts);
            Console.Read();
        }

        public static int solve(List<int> A)
        {
            int L = 0;
            int R = A.Count-1;
            int N = A.Count;


            if (A.Count == 1)
            {
                return A[0];
            }
            else if (A[0] != A[1])
            {
                return A[0];
            }
            else if (A[R] != A[R - 1])
            {
                return A[R];
            }

            int mid = (L + R) / 2;

            while (L <= R)
            {
                mid = (L + R) / 2;

                if (A[mid - 1] != A[mid] && A[mid] != A[mid + 1])
                {//case 1 if the previous & next element is != to curr element then it is the unique element
                    return A[mid];
                }
                if (A[mid - 1] == A[mid])
                {
                    mid = mid - 1;
                }
                if (mid % 2 == 0)
                {
                    L = mid + 2;
                }
                else
                {
                    R = mid - 1;
                }
            }

            return -1;
        }
    }
}
