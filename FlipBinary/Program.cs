using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> result = flip("0111000100010");
            Console.Read();
        }
        public static List<int> flip(string A)
        {

            int currentIndex = 0;
            int maxZero = 0;
            int maxStartIndex = -1;
            int zeroCounter = 0;
            int strIndex = -1;
            int endIndex = -1;

            foreach (char ch in A)
            {
                if (ch.ToString() == "0")
                {
                    zeroCounter++;
                    
                }
                else if (ch.ToString() == "1" && strIndex > -1)
                {
                    zeroCounter--;
                    if (zeroCounter < 0)
                    {
                        maxStartIndex = strIndex;
                        strIndex = -1;
                        zeroCounter = 0;
                    }
                }

                if (zeroCounter > maxZero)
                {
                    if (strIndex == -1)
                    {
                        strIndex = currentIndex;
                        maxStartIndex = strIndex;
                    }
                    maxZero = zeroCounter;
                    endIndex = currentIndex;
                }

                currentIndex++;
            }

            if (maxStartIndex == -1 && endIndex == -1)
            {
                return new List<int>();
            }
            else
            {
                return new List<int> { maxStartIndex , endIndex + 1 };
            }

        }
    }
}
