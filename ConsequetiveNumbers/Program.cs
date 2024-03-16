using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsequetiveNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Solve(5);
            Console.Read();
        }
        public static void Solve(int A)
        {
            double maxVal = Math.Pow(2, A);

            for (double i = 1; i <= maxVal; i++)
            {
                if (checkConsequitive(Convert.ToInt32(i)))
                {
                    Console.Write(i + " ");
                }
                                  
            }
        }
        public static bool checkConsequitive(int val)
        {
            int prev = 0;
            while (val > 0)
            {
                if ((val & 1) % 2 == 0)
                {
                    prev = 0;
                }
                else
                {
                    if (prev == 1)
                    {
                        return false;
                    }
                    prev = 1;
                }
                val = val >> 1;
            }
            return true;
        }
    }
}
