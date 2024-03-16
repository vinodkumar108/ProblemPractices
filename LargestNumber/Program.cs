using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargestNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputList = new List<int> { 3, 30, 34, 5, 9 };

            string ans = largestNumber(inputList);
            Console.Read();
        }
        public static string largestNumber(List<int> A)
        {

            A.Sort();
            string answer = string.Empty;

            for (int i = A.Count - 1; i >= 0; i--)
            {
                answer = answer + Convert.ToString(A[i]);
            }

            return answer;

        }
    }
}
