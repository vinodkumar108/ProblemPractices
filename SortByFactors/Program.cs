using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortByFactors
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lstItem = new List<int> {4,6,8,3,2 };

            lstItem.Sort(new CompareFactors());

            Console.Read();

        }
    }

    class CompareFactors : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            int xFactorCounts = CountFactors(x);
            int yFactorCounts = CountFactors(y);

            if(xFactorCounts == yFactorCounts)
            {
                if(x == y)
                {
                    return 0;
                }
                else if(x<y)
                {
                    return -1;
                }
                else { return 1; }
            }
            else if(xFactorCounts < yFactorCounts)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }

        int CountFactors(int num)
        {
            int count = 0;
            for (int i = 1; (i * i) <= num; i++)
            {
                if (num % i == 0)
                {
                    int q = num / i;

                    if (q == i)
                        count = count + 1;
                    else
                        count = count + 2;
                }
            }
            return count;
        }
    }
}
