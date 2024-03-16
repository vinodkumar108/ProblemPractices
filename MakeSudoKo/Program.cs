using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeSudoKo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = new List<string> { "53..7....", "6..195...", ".98....6.", "8...6...3", "4..8.3..1", "7...2...6", ".6....28.", "...419..5", "....8..79" };
            Solution obj = new Solution();
            List<string> ans= obj.solve(input);
            Console.Read();
        }
    }

    class Solution
    {
        List<string> answer = new List<string>();

        public List<string> solve(List<string> A)
        {

            char[][] result = new char[9][];
            for (int i = 0; i < A.Count; i++)
            {
                result[i] = new char[9];
                result[i] = A[i].ToCharArray();
            }

            MakeSudoKo(result, 0, 0, 9);

            return answer;

        }
        public bool MakeSudoKo(char[][] mat, int x, int y, int N)
        {
            if (x < N)
            {
                x++;
                y = 0;
            }

            if (x == N)
            {
                for (int i = 0; i < N; i++)
                {
                    answer.Add(new string(mat[i]));
                }
                return true;
            }

            if (mat[x][y] != '.')
            {
                if (MakeSudoKo(mat, x, y + 1, N) == true)
                {
                    return true;
                }
            }
            else
            {
                for (int i = 1; i <= 9; i++)
                {
                    if (IsValid(mat, x, y, i) == true)
                    {
                        mat[x][y] = (char)i;
                        if (MakeSudoKo(mat, x, y + 1, N) == true)
                        {
                            return true;
                        }
                        mat[x][y] = '.';
                    }
                }
            }

            return false;
        }
        public bool IsValid(char[][] mat, int row, int col, int x)
        {
            for (int i = 0; i < 9; i++)
            {
                if (mat[row][i] == x || mat[i][col] == x)
                {
                    return false;
                }
            }

            row = row - (row % 3);
            col = col - (col % 3);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (mat[row + i][col + j] == x)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
