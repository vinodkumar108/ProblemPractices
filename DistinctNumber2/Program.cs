using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistinctNumber2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = new List<int>() { 186, 256,102,377,186,377 };

            List<int> result = solve(input);
            Console.Read();
        }
        public static List<int> solve(List<int> A)
        {

            int xOR = 0;
            for (int i = 0; i < A.Count; i++)
            {
                xOR = xOR ^ A[i];
            }

            //find digit having 1 in xOR
            int onePosition = 0;

            while (xOR > 0)
            {
                if ((xOR & 1) == 1)
                {
                    break;
                }

                onePosition++;
                xOR = xOR >> 1;
            }

            int xOrA = 0; int xOrB = 0;

            for (int j = 0; j < A.Count; j++)
            {
                if (((A[j] >> onePosition) & 1) == 1)
                {
                    xOrA = xOrA ^ A[j];
                }
                else
                {
                    xOrB = xOrB ^ A[j];
                }
            }

            int min = Math.Min(xOrA, xOrB);
            int max = Math.Max(xOrA, xOrB);

            return new List<int>() { min, max };

        }
    }
}
