using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortArray
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        public static List<int> solve(List<int> A)
        {

            List<int> result = new List<int>();
            int max = -1;

            for (int k = 0; k < A.Count; k++)
            {
                if (max < A[k])
                {
                    max = A[k];
                }
            }

            int[] countFrequency = new int[max + 1];
            for (int i = 0; i < max + 1; i++)
            {
                countFrequency[i] = 0;
            }

            for (int j = 0; j < A.Count; j++)
            {
                countFrequency[A[j]] = countFrequency[A[j]] + 1;
            }

            for (int l = 1; l < max + 1; l++)
            {
                if(countFrequency[l] > 0)
                result.Add(countFrequency[l]);
            }

            return result;
        }
    }
}
