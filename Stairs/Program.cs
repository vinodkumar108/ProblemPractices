using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stairs
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution obj = new Solution();
            int ans=obj.climbStairs(5);
            Console.Read();
        }
    }
    class Solution
    {

        public int[] way;
        public int climbStairs(int A)
        {

            if (A == 1) return 1;

            way = new int[A + 1];
            int answer = CalcWays(A);

            return answer;

        }
        public int CalcWays(int A)
        {
            if (A == 0 || A==1 || A==2)
            {
                way[A] = A;
                return way[A];
            }
            
            if (A - 1 > 0 && way[A - 1] == 0)
            {
                CalcWays(A - 1);
            }

            if (A - 2 > 0 && way[A - 2] == 0)
            {
                CalcWays(A - 2);
            }

            way[A] = way[A - 1] + way[A - 2];

            return way[A];

        }
    }

}
