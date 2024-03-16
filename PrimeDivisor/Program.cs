using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeDivisor
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = solve(8);
            Console.Read();
        }
        public static int solve(int A)
        {

            //8 - 2,3,5,7,
            //12 - 2,3,5,7,11
            List<int> lstPrime = new List<int>();

            for (int i = 2; i <= A; i++)
            {
                if (GetPrime(i) > 1)
                {
                    lstPrime.Add(i);
                }
            }

            int answer = 0;
            for (int i = 2; i <= A; i++)
            {
                //checking i
                //divCount
                int divCount = 0;
                for (int j = 0; j < lstPrime.Count; j++)
                {
                    if (i % lstPrime[j] == 0) divCount++;
                }

                if (divCount == 2) answer++;
            }

            return answer;


        }
        public static int GetPrime(int A)
        {
            int maxDiv = 0;
            for (int i = 1; i <= Math.Sqrt(A); i++)
            {
                if (A % i == 0)
                {
                    if (A / i == i)
                    {
                        maxDiv++;
                    }
                    else
                    {
                        maxDiv = maxDiv + 2;
                    }

                }
            }

            if (maxDiv == 2) return A;
            else return 0;
        }
    }
}
