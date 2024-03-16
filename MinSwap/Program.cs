using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinSwap
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> l = new List<int> { 52, 7, 93, 47, 68, 26, 51, 44, 5, 41, 88, 19, 78, 38, 17, 13, 24, 74, 92, 5, 84, 27, 48, 49, 37, 59, 3, 56, 79, 26, 55, 60, 16, 83, 63, 40, 55, 9, 96, 29, 7, 22, 27, 74, 78, 38, 11, 65, 29, 52, 36, 21, 94, 46, 52, 47, 87, 33, 87, 70 };
            int result = solve(l, 19);
            Console.Read();
        }
        public static int solve(List<int> A, int B)
        {

            int N = A.Count;
            int k = 0;
            int min = 0;
            int finalMin = 0;

            for (int i = 0; i < N; i++)
            {
                if (A[i] <= B)
                {
                    k++;
                }
            }

            for (int j = 0; j < k; j++)
            {
                if (A[j] > B)
                {
                    min++;
                }
            }

            finalMin = min;

            for (int l = k; l < N; l++)
            {
                if (A[l] > B)
                {
                    min++;
                }
                else
                {
                    min--;
                }

                if (A[l-k] <= B)
                {
                    min++;
                }
                

                finalMin = Math.Min(finalMin, min);
            }

            return finalMin;
        }
    }
}
