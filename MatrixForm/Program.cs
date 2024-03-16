using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixForm
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Matrix
    {

        // Define properties here
        public List<List<int>> val;

        // Define constructor here
        public Matrix(int row, int col)
        {
            val = new List<List<int>>();
            for (int i = 0; i < row; i++)
            {
                List<int> itemRow = new List<int>();
                for (int j = 0; j < col; j++)
                {
                    itemRow.Add(Console.Read());
                }
                val.Add(itemRow);
            }
        }

        public void input()
        {
            int n = val.Count;
            int m = val[0].Count;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    val[i][j] = Console.Read();
                }
            }
        }

        public Matrix add(Matrix x)
        {
            // Complete the function
            int n = val.Count;
            int m = val[0].Count;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    x.val[i][j] = x.val[i][j] + val[i][j];
                }
            }

            return x;
        }

        public Matrix subtract(Matrix x)
        {
            // Complete the function
            int n = val.Count;
            int m = val[0].Count;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    x.val[i][j] = val[i][j] - x.val[i][j];
                }
            }
            return x;
        }

        public Matrix transpose()
        {
            // Complete the function
            int n = val.Count;
            int m = val[0].Count;

            Matrix b = new Matrix(m, n);
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    b.val[i][j] = val[j][i];
                }
            }

            return b;
        }

        public void print()
        {
            // Complete the function
            int n = val.Count;
            int m = val[0].Count;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(val[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }

    /*
        Matrix a = new Matrix(10, 5)  // 10 rows, 5 columns
        a.input() 
        Matrix b = new Matrix(10, 5)  // 10 rows, 5 columns
        b.input()
        Matrix c1 = a.add(b)
        Matrix c2 = a.subtract(b)
        Matrix c3 = a.transpose()
        a.print()
    */
}
