using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeChars
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        public static int solve(string A, int B)
        {

            int minOccurance = 0;
            int[] charArr = new int[26];

            for (int j = 0; j < 26; j++)
            {
                charArr[j] = 0;
            }

            for (int i = 0; i < A.Length; i++)
            {
                if ((int)A[i] >= 97 && (int)A[i] <= 122)
                {
                    int index = ((int)A[i]) - 97;
                    charArr[index] = charArr[index] + 1;
                }
            }

            Array.Sort(charArr);

            int indexArr = 0;
            while (B > 0)
            {
                if (B > charArr[indexArr])
                {
                    B = B - charArr[indexArr];
                    charArr[indexArr] = 0;
                }
                else
                {
                    charArr[indexArr] = charArr[indexArr] - B;
                    B = 0;
                }
                indexArr++;
            }

            for (int k = 0; k < charArr.Length; k++)
            {
                if (charArr[k] > 0) minOccurance++;
            }

            if (A.Length == 1) return 1;
            else return minOccurance;

        }
    }
}
