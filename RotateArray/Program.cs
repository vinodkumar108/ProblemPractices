using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotateArray
{
    class Program
    {
        static void Main(string[] args)
        {
            List<List<int>> lstInput = new List<List<int>>();
            //lstInput.Add(new List<int> { 1, 2 });
            //lstInput.Add(new List<int> { 3, 4 });

            lstInput.Add(new List<int> { 1, 2, 3 });
            lstInput.Add(new List<int> { 4, 5, 6 });
            lstInput.Add(new List<int> { 7, 8, 9 });

            List<List<int>> lstOutput = rotate(lstInput);

            Console.Read();

        }
        public static List<List<int>> rotate(List<List<int>> A)
        {
            int N = A.Count;
            int M = A[0].Count;

            List<List<int>> lstTranArray = new List<List<int>>();

            for (int i = 0; i < M; i++)
            {
                //Add each row
                List<int> rowItem = new List<int>();
                for (int j = N - 1; j >= 0; j--)
                {
                    rowItem.Add(A[j][i]);
                }

                lstTranArray.Add(rowItem);
            }

            return lstTranArray;
        }



    }
}
