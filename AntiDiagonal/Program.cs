using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiDiagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            List<List<int>> lstInput = new List<List<int>>();
            //lstInput.Add(new List<int> { 1, 2 });
            //lstInput.Add(new List<int> { 3, 4 });

            //lstInput.Add(new List<int> { 1, 2, 3 });
            //lstInput.Add(new List<int> { 4, 5, 6 });
            //lstInput.Add(new List<int> { 7, 8, 9 });

            lstInput.Add(new List<int> { 1,  2,   3,   4 });
            lstInput.Add(new List<int> { 5,  6,   7,   8 });
            lstInput.Add(new List<int> { 9,  10,  11, 12 });
            lstInput.Add(new List<int> { 13, 14,  15,  16 });

            List<List<int>> lstOutput = diagonal(lstInput);

            Console.Read();
        }

        public static List<List<int>> diagonal(List<List<int>> A)
        {

            int N = A.Count;
            List<List<int>> lstResult = new List<List<int>>();

            //Run loop to add all item from 0 col to N-1 col

            List<int> lstItem = new List<int>();

            for (int i = 0; i < N; i++)
            {
                lstItem = new List<int>();
                int rowX = 0;
                for (int j = 0; j <= i; j++)
                {
                    lstItem.Add(A[j][i - j]);
                    rowX++;
                }

                while(rowX < N)
                {
                    lstItem.Add(0);
                    rowX++;
                }

                lstResult.Add(lstItem);

            }


            //Run loop to add all item from 1 row to N -1 row          

            for (int k = 1; k < N; k++)
            {
                lstItem = new List<int>();
                int x = N - 1;

                int rowY = 0;

                for (int l=k;l<N;l++)
                {
                    lstItem.Add(A[l][x]);
                    x--;
                    rowY++;
                }

                while (rowY < N)
                {
                    lstItem.Add(0);
                    rowY++;
                }

                lstResult.Add(lstItem);

            }

            return lstResult;

        }
    }
}
