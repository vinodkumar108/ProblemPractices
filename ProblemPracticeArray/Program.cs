using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemPracticeArray
{
    class Program
    {
        public static void Main(string[] args)
        {
        //int[] arrList = { 10, 20, 30, 40, 50 };
        //fun(arrList);

            string A= "GGGTGANAGGJGAG";
            long answer = solve(A);

            Console.WriteLine(answer);
            Console.ReadLine();
        }
        static void fun(int[] arr)
        {
            arr[3] = 98;
            return;
        }
        public static long solve(string A)
        {

            long answer = 0;
            long aCount = 0;

            for (int i = 0; i < A.Length - 1; i++)
            {
                if (A[i] == 'A')
                {
                    aCount++;
                }
                else if (A[i] == 'G')
                {
                    answer = answer + aCount;
                }
            }

            return answer;
        }
    }
}
