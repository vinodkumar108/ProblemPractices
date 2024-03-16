using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JosephTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Joseph problem 2");
            int result = solve(9);
            Console.Read();
        }
        public static int solve(int A)
        {

            int maxTwoMultiple = 2;

            while (maxTwoMultiple < A)
            {
                maxTwoMultiple = maxTwoMultiple * 2;
            }

            if (A % (maxTwoMultiple / 2) == 0)
                return 1;
            else
                return ((A - (maxTwoMultiple / 2)) * 2) + 1;

        }
    }
}
