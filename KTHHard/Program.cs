using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTHHard
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = solve(4, 6);
            Console.Read();

        }
        public static int solve(int A, long B)
        {
            string resultVal = GetKthSymbolUpdated("0", A-1);
            char[] charArr = resultVal.ToCharArray();
            return (int)charArr[B];
        }
        public static string GetKthSymbol(string inpStr, int level, int A)
        {
            System.Text.StringBuilder resultStr = new System.Text.StringBuilder();

            if (level >= A) return inpStr;

            foreach (char ch in inpStr)
            {
                if (ch.ToString() == "0")
                {
                    resultStr.Append("01");
                }
                else if (ch.ToString() == "1")
                {
                    resultStr.Append("10");
                }
            }

            return GetKthSymbol(resultStr.ToString(), level + 1, A);

        }

        public static string GetKthSymbolUpdated(string inpStr,int A)
        {
            System.Text.StringBuilder resultStr = new System.Text.StringBuilder();
            resultStr.Append(inpStr);

            if (A == 0) return inpStr;

            foreach (char ch in inpStr)
            {
                if (ch.ToString() == "0")
                {
                    resultStr.Append("1");
                }
                else if (ch.ToString() == "1")
                {
                    resultStr.Append("0");
                }
            }

            return GetKthSymbolUpdated(resultStr.ToString(), A-1);

        }
    }
}
