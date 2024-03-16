using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestPalindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputStr = "bb";
            string result = longestPalindrome(inputStr);
            Console.Read();
        }
        public static string longestPalindrome(string A)
        {

            int palindromIndex = 0;
            int palMaxLength = 0;
            bool IsEvenPalindrom = false;
            System.Text.StringBuilder sbResult = new System.Text.StringBuilder();

            //Calculate Maximum Odd palindromIndex
            for (int i = 1; i < A.Length - 1; i++)
            {
                int j = i - 1;
                int k = i + 1;
                int dynPalindromLength = 0;
                while (j >= 0 && k <= A.Length - 1)
                {
                    if (A[j] == A[k])
                    {
                        dynPalindromLength++;
                    }
                    else { break; }
                    j--; k++;
                }

                if (dynPalindromLength > palMaxLength)
                {
                    palMaxLength = dynPalindromLength;
                    palindromIndex = i;
                    IsEvenPalindrom = false;
                }
            }

            //Calculate Maximum even palindromIndex
            for (int l = 0; l <= A.Length - 1; l++)
            {
                int j = l;
                int k = l + 1;
                int dynPalindromLength = 0;
                while (j >= 0 && k <= A.Length-1)
                {
                    if (A[j] == A[k])
                    {
                        dynPalindromLength++;
                    }
                    else
                    {
                        break;
                    }
                    j--; k++;
                }

                if (dynPalindromLength > palMaxLength)
                {
                    palMaxLength = dynPalindromLength;
                    palindromIndex = l;
                    IsEvenPalindrom = true;
                }
            }

            if (IsEvenPalindrom)
            {
                for (int n = palindromIndex - palMaxLength + 1; n < palindromIndex + palMaxLength+1; n++)
                {
                    sbResult.Append(A[n].ToString());
                }
            }
            else
            {
                for (int n = palindromIndex - palMaxLength; n < palindromIndex + palMaxLength+1; n++)
                {
                    sbResult.Append(A[n].ToString());
                }
            }

            return sbResult.ToString();
        }
    }
}
