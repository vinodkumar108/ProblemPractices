using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumEvenIndices
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lst = new List<int> {13, 11, 15, 7, 15, 2};
            List<List<int>> lstB = new List<List<int>>();
            lstB.Add(new List<int> { 0, 2 });

            List<int> result = oddSolve(lst, lstB);

            Console.Read();

        }
        public static List<int> solve(List<int> A, List<List<int>> B)
        {

            int N = B.Count;
            int M = A.Count;
            List<int> resArray = new List<int>();
            List<long> lstAPrefix = new List<long>();

            lstAPrefix.Add((long)A[0]);
            if (M >= 2)
            {
                lstAPrefix.Add(0);
            }

            for (int i = 2; i < M; i++)
            {
                if (i % 2 == 0)
                {
                    lstAPrefix.Add((long)A[i] + lstAPrefix[i - 2]);
                }
                else
                {
                    lstAPrefix.Add(0);
                }
            }

            for (int j = 0; j < N; j++)
            {
                int startIndex = B[j][0];
                int endIndex = B[j][1];

                if (startIndex == 0)
                {
                    if (endIndex % 2 != 0)
                    {
                        endIndex = endIndex - 1;
                    }

                    resArray.Add((int)lstAPrefix[endIndex]);
                }
                else
                {

                    if (startIndex % 2 == 0)
                    {
                        startIndex = startIndex - 2;
                    }
                    else
                    {
                        startIndex = startIndex - 1;
                    }

                    if (endIndex % 2 != 0)
                    {
                        endIndex = endIndex - 1;
                    }

                    resArray.Add((int)(lstAPrefix[endIndex] - lstAPrefix[startIndex]));

                }
            }

            return resArray;
        }
        public static List<int> oddSolve(List<int> A, List<List<int>> B)
        {

            int N = B.Count;
            int M = A.Count;
            List<int> resArray = new List<int>();
            List<long> lstAPrefix = new List<long>();

            lstAPrefix.Add(0);
            if (M >= 2)
            {
                lstAPrefix.Add((long)A[1]);
            }

            for (int i = 2; i < M; i++)
            {
                if (i % 2 == 0)
                {
                    lstAPrefix.Add(0);
                }
                else
                {                   
                    lstAPrefix.Add((long)A[i] + lstAPrefix[i - 2]);
                }
            }

            for (int j = 0; j < N; j++)
            {
                int startIndex = B[j][0];
                int endIndex = B[j][1];

                
                if(startIndex == 0 && endIndex == 0)
                {
                    resArray.Add((int)lstAPrefix[0]);
                }
                else if (startIndex == 0 || startIndex == 1)
                {
                    if (endIndex % 2 == 0)
                    {
                        endIndex = endIndex - 1;
                    }
                    resArray.Add((int)lstAPrefix[endIndex]);
                }
                else
                {

                    if (startIndex % 2 == 0)
                    {
                        startIndex = startIndex - 1;                        
                    }
                    else
                    {                       
                        startIndex = startIndex - 2;
                    }

                    if (endIndex % 2 == 0)
                    {
                        endIndex = endIndex - 1;
                    }

                    resArray.Add((int)(lstAPrefix[endIndex] - lstAPrefix[startIndex]));

                }
            }

            return resArray;
        }
    }
}
