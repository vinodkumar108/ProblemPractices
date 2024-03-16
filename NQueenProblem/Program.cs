using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQueenProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution obj = new Solution();
            List<List<string>> ans = obj.solveNQueens(4);

            Console.Read();

        }
    }
    class Solution
    {

        List<List<string>> result = new List<List<string>>();

        public List<List<string>> solveNQueens(int A)
        {

            if (A == 1)
            {
                result.Add(new List<string> { "Q" });
                return result;
            }

            char[][] mat = new char[A][];

           for(int i=0;i<mat.Length; i++)
            {
                mat[i] = new char[A];
            }

            Nqueen(mat, 0, A);

            return result;
        }

        public void Nqueen(char[][] mat, int row, int N)
        {
            if (row == N)
            {
                //print all and set into result

                List<string> lstStr = new List<string>();
                for (int i = 0; i < mat.Length; i++)
                {
                    string str = new string(mat[i]);
                    lstStr.Add(str);
                }

                result.Add(lstStr);

                return;
            }

            for (int col = 0; col < N; col++)
            {
                if (isQueenSafe(mat, row, col))
                {
                    mat[row][col] = 'Q';
                    Nqueen(mat, row + 1, N);
                    mat[row][col] = '.';
                }
            }
        }
        public bool isQueenSafe(char[][] mat, int row, int col)
        {
            for (int i = 0; i < row; i++)
            {
                if (mat[i][col] == 'Q')
                {
                    return false;
                }
            }

            for (int rowInd = row, colInd = col; rowInd >= 0 && colInd >= 0; rowInd--, colInd--)
            {
                if (mat[rowInd][colInd] == 'Q')
                {
                    return false;
                }
            }

            for (int rowInd = row, colInd = col; rowInd >= 0 && colInd < mat.Length; rowInd--, colInd++)
            {
                if (mat[rowInd][colInd] == 'Q')
                {
                    return false;
                }
            }

            return true;
        }
    }
}
