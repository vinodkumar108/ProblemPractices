using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountDivisor
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> result = solve(new List<int> { 10, 20 });
            Console.Read();
        }
        public static List<int> solve(List<int> A)
        {

            int Max = 0;
            for (int k = 0; k < A.Count; k++)
            {
                Max = Math.Max(Max, A[k]);
            }

            int[] numFactors = new int[Max + 1];

            for (int i = 1; i <= Max; i++)
            {                
                for (int j = i; j <= Max; j = j + i)
                {
                    numFactors[j] = numFactors[j] + 1;
                }
            }

            for (int k = 0; k < A.Count; k++)
            {
                A[k] = numFactors[A[k]];
            }

            return A;
        }
    }
}
