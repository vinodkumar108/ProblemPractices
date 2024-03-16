using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubArraySum
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lst = new List<int> { 2, 9, 5 };

            long result = subarraySum(lst);

            Console.WriteLine(result);
            Console.Read();
        }

        public static long subarraySum(List<int> A)
        {

            
            long finResult = 0;

            for (int i = 0; i < A.Count; i++)
            {
                long result = 0;

                for (int j = i; j < A.Count; j++)
                {
                    result += A[j];
                    finResult += result;
                }
               
            }

            return finResult;
        }
    }
}

