using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "crulgzfkif gg ombt vemmoxrgf qoddptokkz op xdq hv ";
            string result = solve(input);
            Console.Read();
        }
        public static string solve(string A)
        {

            int N = A.Length;
            string strResult = string.Empty;
            string setTempString = string.Empty;
            System.Text.StringBuilder sbResult = new System.Text.StringBuilder();
            System.Text.StringBuilder sbTmpResult = new System.Text.StringBuilder();

            sbResult.Append(A[N - 1]);

            if (N > 1)
            {
                for (int i = N - 2; i >= 0; i--)
                {
                    if ((A[i]).ToString() == " " && (A[i + 1]).ToString() == " ")
                    {

                    }
                    else if ((A[i]).ToString() == " " && (A[i + 1]).ToString() != " ")
                    {
                        //SET reverse string in final result
                        setTempString = ReverseString(sbTmpResult.ToString());
                        sbTmpResult = new System.Text.StringBuilder();
                        sbResult.Append(setTempString + " ");
                    }
                    else
                    {
                        sbTmpResult.Append(A[i]);
                    }
                }
            }

            setTempString = ReverseString(sbTmpResult.ToString());

            if (setTempString != "")
            {
                sbTmpResult = new System.Text.StringBuilder();
                sbResult.Append(setTempString + " ");
            }

            strResult = sbResult.ToString().Trim();

            return strResult;

        }

        public static string ReverseString(string inputStr)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            for (int j = inputStr.Length - 1; j >= 0; j--)
            {
                sb.Append((inputStr[j]).ToString());
            }

            return sb.ToString();
        }
    }
}
