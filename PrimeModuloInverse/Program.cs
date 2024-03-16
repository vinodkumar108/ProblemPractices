using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeModuloInverse
{
    class Program
    {
        static void Main(string[] args)
        {
            int answer = solve(3, 5);
            Console.Read();
        }
        public static int solve(int A, int B)
        {

            long answer = fastPow(A, B - 2, B);
        int finalAnswer = (int)answer % B;

            return finalAnswer;
        }
        public static long fastPow(int A, int B, int mod)
        {
            if (B == 0) return 1;

            long x = fastPow(A, B / 2, mod);

            if (B % 2 == 0)
            {
                return (x * x) % mod;
            }
            else
            {
                return ((x * x) % mod * A) % mod;
            }
        }
    }
}
