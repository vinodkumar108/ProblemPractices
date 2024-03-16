using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputeNCR
{
    class Program
    {
        static void Main(string[] args)
        {
            int Result = solve(3, 2, 33);
            Console.Read();
        }
        public static int solve(int A, int B, int C)
        {

            if (A == B) return 1;

            long X = FastFact(A) % C;
            long Y = FastFact(B) % C;
            long Z = FastFact(A - B) % C;

            Y = FastPower(Y, C - 2, C);
            Z = FastPower(Z, C - 2, C);

            long answer = (X * Y * Z) % C;

            return (int)answer;

        }
        public static long FastFact(long N)
        {
            if (N == 1) return 1;
            else
            {
                return N * FastFact(N - 1);
            }
        }
        public static long FastPower(long A, long B, long C)
        {
            if (B == 0) return 1;
            long X = FastPower(A, B / 2, C);
            if (B % 2 == 0)
            {
                return (X % C * X % C) % C;
            }
            else
            {
                return ((X % C * X % C) % C * A) % C;
            }
        }
    }
}
