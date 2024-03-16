using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnybaseToDecimal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Any base to Decimal");

            int result = solve(14,6);

            Console.Read();
        }

        public static int solve(int A, int B)
        {

            if (A == 0) return 0;

            int result = 0;
            string numberString = Convert.ToString(A);
            int length = numberString.Length;

            int basePowerValue = 1;

            for (int i = 1; i < length; i++)
            {
                basePowerValue = basePowerValue * B;
            }

            foreach (char ch in numberString)
            {
                if (ch == '0')
                {
                    result = result + 0;
                }
                else
                {
                    int intEquiv = int.Parse(ch.ToString());
                    result = result + intEquiv * basePowerValue;
                }

                basePowerValue = basePowerValue / B;

            }

            return result;

        }
    }
}
