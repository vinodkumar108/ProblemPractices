using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<int> A = new List<int> { 51, 6, 10, 8, 22, 61, 56, 48, 88, 85, 21, 98, 81, 76, 71, 68, 18, 6, 14, 23, 72, 18, 56, 30, 97, 100, 81, 5, 99, 2, 85, 67, 46, 32, 66, 51, 76, 53, 36, 31, 81, 56, 26, 75, 69, 54, 54, 54, 83, 41, 86, 48, 7, 32, 85, 23, 47, 23, 18, 45, 79, 95, 73, 15, 55, 16, 66, 73, 13, 85, 14, 80, 39, 92, 66, 20, 22, 25, 34, 14, 51, 14, 17, 10, 100, 35, 9, 83, 31, 60, 24, 37, 69, 62 };


            List<int> A = new List<int> { 51, 6, 6, 8 };
            List<int> lstInserted = new List<int>();
            for (int i = 0; i < A.Count; i++)
            {
                lstInserted = InsertElement(A[i], lstInserted);
            }

            for(int j=0;j< lstInserted.Count;j++)
            {
                Console.Write(lstInserted[j] + ", ");
            }

            int answer = 0;
            for (int j = 1; j < lstInserted.Count; j++)
            {
                if (lstInserted[j] == lstInserted[j - 1])
                {
                    answer = answer + 1;
                    lstInserted[j] = lstInserted[j] + 1;
                }
            }
            

            Console.Read();
        }
        public static List<int> InsertElement(int x, List<int> lstInteger)
        {
            int preCount = lstInteger.Count;
            lstInteger.Add(x);
            int i = preCount;
            for (; i > 0; i--)
            {
                if (lstInteger[i-1] >= x)
                {
                    lstInteger[i] = lstInteger[i - 1];
                }
                else
                {                    
                    break;
                }
            }

            if(i >= 0)
            {
                lstInteger[i] = x;
            }
            

            return lstInteger;
        }
    }
}
