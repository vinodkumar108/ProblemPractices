using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerMod
{
    class Program
    {
        static void Main(string[] args)
        {
            int res11 = -1 % 20;
            int res = (int)powMode(-1, 1, 20);
            Console.Read();
        }
        public static long powMode(int N, int M, int L)
        {
            if (M == 0) return 1;
            long P = powMode(N, M / 2, L);

            if (M % 2 == 0)
            {
                return mod(P * P,L);
            }
            else
            {               
                return mod(mod(P * P, L) * N, L);               
            }
        }
        public static long mod(long x, long m)
        {
            return (x % m + m) % m;
        }
    }
}
