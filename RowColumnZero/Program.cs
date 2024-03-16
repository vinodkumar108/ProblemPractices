using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RowColumnZero
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

            lstInput.Add(new List<int> { 51, 21, 90, 38, 57, 12, 11, 1, 68, 60 });
            lstInput.Add(new List<int> { 81, 24, 63, 97, 75, 70, 23, 91, 39, 84 });
            lstInput.Add(new List<int> { 0, 21, 97, 12, 46, 48, 50, 3, 57, 69 });
            lstInput.Add(new List<int> { 44, 8, 42, 34, 99, 0, 98, 10, 53, 67 });
            lstInput.Add(new List<int> { 23, 34, 43, 86, 31, 18, 9, 54, 61, 48 });
            lstInput.Add(new List<int> { 90, 61, 21, 87, 26, 67, 88, 28, 70, 45 });
            lstInput.Add(new List<int> { 98, 14, 5, 92, 1, 4, 44, 99, 67, 98 });
            lstInput.Add(new List<int> { 18, 42, 32, 61, 80, 64, 32, 89, 70, 93 });
            lstInput.Add(new List<int> { 89, 61, 7, 10, 0, 85, 29, 40, 13, 0 });
            lstInput.Add(new List<int> { 85, 63, 66, 43, 56, 67, 99, 0, 67, 66 });

            List<List<int>> lstOutput = solve(lstInput);

            Console.Read();
        }
        public static List<List<int>> solve(List<List<int>> A)
        {

            int N = A.Count;
            int M = A[0].Count;

            List<int> rowIndex = new List<int>();
            List<int> colIndex = new List<int>();

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (A[i][j] == 0)
                    {
                        rowIndex.Add(i);
                        colIndex.Add(j);
                    }
                }
            }

            foreach (var rowItem in rowIndex)
            {
                for (int l = 0; l < M; l++)
                {
                    A[rowItem][l] = 0;
                }
            }

            foreach (var colItem in colIndex)
            {
                for (int k = 0; k < N; k++)
                {
                    A[k][colItem] = 0;
                }
            }

            return A;
        }
    }
}
