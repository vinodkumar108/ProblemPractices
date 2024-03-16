using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddBinaryString
{
    class Program
    {
        static void Main(string[] args)
        {
            string inp1 = "1010110111001101101000";
            string inp2 = "1000011011000000111100110";
            string result = addBinary2(inp1, inp2);
            Console.Read();
        }
        public static string addBinary(string A, string B)
        {

            if (A.Length == 0) return B;
            if (B.Length == 0) return A;
            if (B.Length == 0 && A.Length == 0) return A;

            int[] aRR = new int[106];
            int[] bRR = new int[106];
            int[] cRR = new int[106];

            for (int n = 0; n < 106; n++)
            {
                aRR[n] = 0;
                bRR[n] = 0;
                cRR[n] = 0;
            }

            int index = 105;

            for (int i = A.Length - 1; i >= 0; i--)
            {
                aRR[index] = Convert.ToInt32(A[i].ToString());
                index--;
            }

            index = 105;

            for (int j = B.Length - 1; j >= 0; j--)
            {
                bRR[index] = Convert.ToInt32(B[j].ToString());
                index--;
            }

            int remainder = 0;

            for (int m = aRR.Length - 1; m >= 0; m--)
            {
                int remCalculate = aRR[m] + bRR[m] + remainder;
                remainder = remCalculate % 2;
                cRR[m] = remCalculate / 2;
            }

            System.Text.StringBuilder sbResult = new System.Text.StringBuilder();

            for (int l = 0; l < cRR.Length; l++)
            {
                if (cRR[l] == 1)
                {
                    sbResult.Append(cRR[l].ToString());
                }
                else if (cRR[l] == 0 && sbResult.ToString() != "")
                {
                    sbResult.Append(cRR[l].ToString());
                }
            }

            return sbResult.ToString();
        }
        public static string addBinary2(string A, string B)
        {

            int N = A.Length - 1;
            int M = B.Length - 1;
            int carry = 0;
            System.Text.StringBuilder sbResult = new System.Text.StringBuilder();

            while (N >= 0 && M >= 0)
            {
                int total = (int)Char.GetNumericValue(A[N]) + (int)Char.GetNumericValue(B[M]) + carry;
                sbResult.Append(Convert.ToString(total % 2));
                carry = total / 2;
                N--;
                M--;
            }

            while (N >= 0)
            {
                int total = (int)Char.GetNumericValue(A[N]) + carry;
                sbResult.Append(Convert.ToString(total % 2));
                carry = total / 2;
                N--;
            }

            while (M >= 0)
            {
                int total = (int)Char.GetNumericValue(B[M]) + carry;
                sbResult.Append(Convert.ToString(total % 2));
                carry = total / 2;
                M--;
            }

            if (carry == 1) sbResult.Append(Convert.ToString(carry));

            string calculatedString = sbResult.ToString();
            char[] calArray = calculatedString.ToCharArray();

            Array.Reverse(calArray);
            return new string(calArray);

        }
    }
}
