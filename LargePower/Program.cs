using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargePower
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = solve(2, 27);
            Console.Read();
        }
        public static int solve(int A, int B)
        {

            long pow = B;
            int result = A;
            int mod = 1000000007;

            while (B > 1)
            {
                pow = (pow % mod * (B - 1) % mod) % mod;
                B--;
            }

            result = fastFact(A, (int)pow, mod);

            return result;
        }
        public static int fastFact(int a, int b, int mod)
        {
            if (b == 0) return 1;
            int x = fastFact(a, b / 2, mod);

            if (b % 2 == 0)
            {
                return (x * x) % mod;
            }
            else
            {
                return ((x * x) % mod * a) % mod;
            }
        }
    }
}
