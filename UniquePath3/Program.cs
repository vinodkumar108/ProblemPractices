using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniquePath3
{
    class Program
    {
        static void Main(string[] args)
        {
            //[[1,0,0,0],[0,0,0,0],[0,0,2,-1]]

            List<List<int>> lstInput = new List<List<int>>();

            lstInput.Add(new List<int> { 1, 0, 0, 0 });
            lstInput.Add(new List<int> { 0, 0, 0, 0 });
            lstInput.Add(new List<int> { 0, 0, 2, -1 });

            Solution obj = new Solution();
            int result = obj.solve(lstInput);
            Console.Read();
        }
    }

    class Solution
    {

        public int solve(List<List<int>> A)
        {

            int stX = 0;
            int stY = 0;
            int zeroCount = 0;

            for (int i = 0; i < A.Count; i++)
            {
                for (int j = 0; j < A[0].Count; j++)
                {
                    if (A[i][j] == 0)
                    {
                        zeroCount++;
                    }
                    else if (A[i][j] == 1)
                    {
                        stX = i; stY = j;
                    }

                }
            }

            int answer = check(A, stX, stY, zeroCount);

            return answer;

        }
        public int check(List<List<int>> matrix, int indX, int indY, int zeroCount)
        {
            if (indX < 0 || indY < 0 || indX > matrix.Count - 1 || indY >= matrix[0].Count || matrix[indX][indY] == -1)
            {
                return 0;
            }

            if (matrix[indX][indY] == 2)
            {
                return zeroCount == -1 ? 1 : 0;
            }

            matrix[indX][indY] = -1;
            zeroCount--;

            int totalCount = check(matrix, indX - 1, indY, zeroCount)
            + check(matrix, indX + 1, indY, zeroCount)
            + check(matrix, indX, indY - 1, zeroCount)
            + check(matrix, indX, indY + 1, zeroCount);

            zeroCount++;
            matrix[indX][indY] = 0;

            return totalCount;
        }
    }

    class SolutionTest
    {
        public int solve(int[][] grid)
        {

            int zeroCount = 0, si = 0, sj = 0;
            for (int row = 0; row < grid.Length; row++)
            {
                for (int col = 0; col < grid[0].Length; col++)
                {
                    if (grid[row][col] == 0)
                    {
                        zeroCount++;
                    }
                    else if (grid[row][col] == 1)
                    {
                        si = row; sj = col;
                    }
                }
            }

            return dfs(grid, si, sj, zeroCount);
        }
        public int dfs(int[][] grid, int x, int y, int zeroCount)
        {
            if (x < 0 || y < 0 || x >= grid.Length || y >= grid[0].Length || grid[x][y] == -1)
                return 0;
            if (grid[x][y] == 2)
                return zeroCount == -1 ? 1 : 0;
            grid[x][y] = -1;
            zeroCount--;

            int totalPath = dfs(grid, x + 1, y, zeroCount) + dfs(grid, x, y + 1, zeroCount) +
                            dfs(grid, x - 1, y, zeroCount) + dfs(grid, x, y - 1, zeroCount);
            zeroCount++;
            grid[x][y] = 0;
            return totalPath;
        }
    }

}
