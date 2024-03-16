using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lstStr = new List<string> { "hello", "scaler", "interviewbit" };
            string B = "adhbcfegskjlponmirqtxwuvzy";
            int result = solve(lstStr,B);
            Console.Read();
        }

        public static int solve(List<string> A, string B)
        {
            Dictionary<char, int> alphaDictionary = new Dictionary<char, int>();
            int index = 1;
            foreach (char ch in B)
            {
                alphaDictionary[ch] = index;
                index++;
            }

            for (int i = 0; i < A.Count - 1; i++)
            {
                string firstStr = A[i];
                string secondStr = A[i + 1];

                char[] chFirst = new char[firstStr.Length];
                int indChar = 0;
                foreach(char ch in firstStr)
                {
                    int charVal = alphaDictionary[ch] + 96;
                    chFirst[indChar] = (char)charVal;
                    indChar++;
                }
                firstStr = new string(chFirst);

                char[] chSecond = new char[secondStr.Length];
                indChar = 0;
                foreach(char ch in secondStr)
                {
                    int charVal = alphaDictionary[ch] + 96;
                    chSecond[indChar] = (char)charVal;
                    indChar++;
                }
                secondStr = new string(chSecond);

                if (Convert.ToBoolean(string.Compare(firstStr, secondStr)))
                {
                    return 0;
                }
            }

            return 1;
        }
    }
}
