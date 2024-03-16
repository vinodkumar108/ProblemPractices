using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxOne
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputStr = "11010110000000000";
            int result = solve(inputStr);
            Console.Read();
        }
        public static int solve(string A)
        {

            int maxOnecount = 0;
            int answer = 0;

            foreach (char c in A)
            {
                if (c.ToString() == "1") maxOnecount++;
            }

            int index = 0;
            foreach (char d in A)
            {
                int leftOneCount = 0;
                int rightOneCount = 0;

                if (d.ToString() == "0")
                {

                    //Calculate Left One Count
                    if (index == 0)
                    {
                        leftOneCount = 0;
                    }
                    else
                    {
                        for (int i = index - 1; i >= 0; i--)
                        {
                            if (A[i].ToString() == "1") leftOneCount++;
                            else
                                break;
                        }
                    }
                    //Calculate right one count
                    if (index == A.Length - 1)
                    {
                        rightOneCount = 0;
                    }
                    else
                    {
                        for (int j = index + 1; j < A.Length; j++)
                        {
                            if (A[j].ToString() == "1") rightOneCount++;
                            else
                                break;
                        }
                    }
                }

                if ((leftOneCount + rightOneCount) == maxOnecount)
                {
                    answer = System.Math.Max((leftOneCount + rightOneCount), answer);
                }
                else if ((leftOneCount + rightOneCount) < maxOnecount)
                {
                    answer = System.Math.Max((leftOneCount + rightOneCount + 1), answer);
                }

                index++;
            }

            return answer;
        }
    }
}
