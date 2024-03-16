using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelToNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = titleToNumber("A");
            Console.Read();
        }
        public static int titleToNumber(string A)
        {

            int answer = 0;
            int index = A.Length - 1;
            foreach (char ch in A)
            {
                int intChar = (int)ch;
                int power = (intChar - 64) % 26;
                if (index > 0)
                {
                    answer = answer + 26 * index * power;
                }
                else
                {
                    answer = answer + power;
                }

                index--;
            }

            return answer;
        }
    }
}
