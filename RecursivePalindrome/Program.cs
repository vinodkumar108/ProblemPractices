using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursivePalindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            string A = "naman";
            char[] charArr = A.ToCharArray();
            int res = Palindrome(charArr, 0, charArr.Length - 1);
            Console.Read();

        }
        public static int Palindrome(char[] chArr, int sIndex, int eIndex)
        {
            if (sIndex > eIndex) return 1;

            if (chArr[sIndex] == chArr[eIndex] && Palindrome(chArr, sIndex + 1, eIndex - 1) == 1)
            {
                return 1;
            }
            return 0;
        }
    }
}
