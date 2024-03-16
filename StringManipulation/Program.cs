using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringManipulation
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        public static string solve(string A)
        {

            System.Text.StringBuilder sbResult = new System.Text.StringBuilder();
            string finalResult = string.Empty;

        foreach(char ch in A)
            {
                if ((int)ch >= 97 && (int)ch <= 122)
                {
                    if ((int)ch == 97 || (int)ch == 101 || (int)ch == 105 || (int)ch == 111 || (int)ch == 117)
                    {
                        sbResult.Append("#");
                    }
                    else
                    {
                        sbResult.Append(ch.ToString());
                    }
                }
            }

            finalResult = sbResult.ToString() + sbResult.ToString();

            return finalResult;


        }
    }
}
