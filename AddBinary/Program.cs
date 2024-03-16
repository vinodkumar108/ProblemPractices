using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            //A: "1010110111001101101000"
            //B: "1000011011000000111100110"
            string A = "1010110111001101101000";
            string B = "1000011011000000111100110";

            string result = addBinary(A, B);
            Console.Read();
        }
        public static string addBinary(string A, string B)
        {

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
                if ((aRR[m] + bRR[m] + remainder) == 2)
                {
                    remainder = 1;
                    cRR[m] = 0;
                }
                else if ((aRR[m] + bRR[m] + remainder) == 3)
                {
                    remainder = 1;
                    cRR[m] = 1;
                }
                else if ((aRR[m] + bRR[m] + remainder) == 1)
                {
                    remainder = 0;
                    cRR[m] = 1;
                }
                else
                {
                    remainder = 0;
                    cRR[m] = 0;
                }
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
    }
}
