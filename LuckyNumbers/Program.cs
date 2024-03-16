using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int A = 21;
            int result = solve(A);
            Console.Read();
        }
        public static int solve(int A)
        {

            int N = A + 1;
            int[] primeList = new int[N];
            List<int> actPrimeList = new List<int>();

            for (int i = 0; i < N; i++)
            {
                primeList[i] = i;
            }
            primeList[1] = 0;

            //Set all prime number
            for (int j = 2; j <= Math.Sqrt(N); j++)
            {
                if (primeList[j] > 0)
                {
                    for (int k = j * j; k < N; k += j)
                    {
                        primeList[k] = 0;
                    }
                }
            }

            for (int i = 2; i < N; i++)
            {
                if (primeList[i] > 0)
                {
                    actPrimeList.Add(i);
                }
            }

            int answer = 0;
            for (int i = 6; i < N; i++)
            {
                if (IsLucky(i, actPrimeList, primeList))
                {
                    answer++;
                }
            }

            return answer;
        }
        public static bool IsLucky(int num, List<int> primeList,int[] sparcePrime)
        {
            int totalPrimeFact = 0;
            for (int i = 0; i < primeList.Count; i++)
            {
                if ((num % primeList[i] == 0))
                {
                    totalPrimeFact++;
                    num = num / primeList[i];

                    while (num % primeList[i] == 0)
                    {
                        num = num / primeList[i];
                    }                    
                }

                if (totalPrimeFact > 2) break;
            }

            if (totalPrimeFact == 2) return true;
            else return false;
        }
    }
}
