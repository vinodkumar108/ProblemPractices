using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubarrayWithBitwiseOR
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> B = new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            long result = solve(100000, B);
            Console.Read();
        }
        public static long solve(int A, List<int> B)
        {

            long answer = 0;
            long prevZeroCount = 0;
            
            long totalSubarray = A;
            totalSubarray = (totalSubarray * (totalSubarray + 1))/2;
            long zeroCountArray = 0;
            for (int i = 0; i < B.Count; i++)
            {
                if (B[i] == 0)
                {
                    prevZeroCount++;
                }
                else
                {
                    zeroCountArray += prevZeroCount * (prevZeroCount + 1) / 2;
                    prevZeroCount = 0;
                }
            }
            zeroCountArray += prevZeroCount * (prevZeroCount + 1) / 2;
            answer = totalSubarray - zeroCountArray;

            return answer;
        }
    }
}
