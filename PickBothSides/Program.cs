using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickBothSides
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lst = new List<int> { -969, -948, 350, 150, -59, 724, 966, 430, 107, -809, -993, 337, 457, -713, 753, -617, -55, -91, -791, 758, -779, -412, -578, -54, 506, 30, -587, 168, -100, -409, -238, 655, 410, -641, 624, -463, 548, -517, 595, -959, 602, -650, -709, -164, 374, 20, -404, -979, 348, 199, 668, -516, -719, -266, -947, 999, -582, 938, -100, 788, -873, -533, 728, -107, -352, -517, 807, -579, -690, -383, -187, 514, -691, 616, -65, 451, -400, 249, -481, 556, -202, -697, -776, 8, 844, -391, -11, -298, 195, -515, 93, -657, -477, 587 };
            int answer = solve1(lst, 81);
            Console.WriteLine(answer);
            Console.ReadLine();
        }

        public static int solve1(List<int> A, int B)
        {
            long finalSum = 0;
            long leftSum = 0;
            long rightSum = 0;
            int rightMostIndex = A.Count - 1;
            if (B == 0) return Convert.ToInt32(finalSum);

            List<long> prefixSumArr = new List<long>();
            prefixSumArr.Add(A[0]);

            for (int i = 1; i < A.Count; i++)
            {
                prefixSumArr.Add(prefixSumArr[i-1] + (long)A[i]);
            }

            for(int j=B;j>0;j--)
            {
                leftSum = prefixSumArr[j-1];
                if (j == B)
                {
                    rightSum = 0;
                }
                else
                {
                    rightSum = prefixSumArr[rightMostIndex] - prefixSumArr[rightMostIndex - (B - j)];
                }

                long sum = leftSum + rightSum;

                finalSum = Math.Max(sum, finalSum);

            }

            return Convert.ToInt32(finalSum);
        }

        public static int solve(List<int> A, int B)
        {

            long totalSum = 0;
            int leftIndex = 0;
            int rightIndex = A.Count - 1;

            if (B == 0) return Convert.ToInt32(totalSum);

            List<long> prefixSumArr = new List<long>();
            prefixSumArr.Add(A[0]);

            for (int i = 1; i < A.Count; i++)
            {
                prefixSumArr.Add(prefixSumArr[i - 1] + (long)A[i]);
            }

            long leftRangeValue = 0;
            long rightRangeValue = 0;

            for (int j = 1; j <= B; j++)
            {
                if (leftIndex == 0)
                {
                    leftRangeValue = prefixSumArr[B - j];
                }
                else
                {
                    leftRangeValue = prefixSumArr[leftIndex + B - j] - prefixSumArr[leftIndex - 1];
                }

                rightRangeValue = prefixSumArr[rightIndex] - prefixSumArr[rightIndex - (B - j + 1)];

                if (leftRangeValue == rightRangeValue)
                {
                    if (A[leftIndex] > A[rightIndex])
                    {
                        totalSum = totalSum + (long)A[leftIndex];
                        leftIndex++;
                    }
                    else
                    {
                        totalSum = totalSum + (long)A[rightIndex];
                        rightIndex--;
                    }
                }
                else if (leftRangeValue > rightRangeValue)
                {
                    totalSum = totalSum + (long)A[leftIndex];
                    leftIndex++;
                }
                else
                {
                    totalSum = totalSum + (long)A[rightIndex];
                    rightIndex--;
                }
            }

            return Convert.ToInt32(totalSum);
        }
    }
}
