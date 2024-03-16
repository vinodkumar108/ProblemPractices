using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubMatrixSumArray
{
    class Program
    {
        static void Main(string[] args)
        {
            List<List<int>> lstInput = new List<List<int>>();
            lstInput.Add(new List<int> { 0 });
           

            //lstInput.Add(new List<int> { 5, 17, 100, 11 });
            //lstInput.Add(new List<int> { 0, 0, 2, 8 });
            //lstInput.Add(new List<int> { 7,8,9});

            List<int> B = new List<int> { 1};
            List<int> C = new List<int> { 1};
            List<int> D = new List<int> { 1};
            List<int> E = new List<int> { 1};

            List<int> result = solve(lstInput, B, C, D, E);
            Console.Read();
        }
        public static List<int> solve(List<List<int>> A, List<int> B, List<int> C, List<int> D, List<int> E)
        {

            int N = A.Count;
            int M = A[0].Count;
            int modVal = 1000000007;
            List<List<int>> P = new List<List<int>>();
            List<int> result = new List<int>();

            //Generate prefix sum matrix
            for (int i = 0; i < N; i++)
            {
                List<int> lstData = new List<int>();
                for (int j = 0; j < M; j++)
                {
                    lstData.Add(0);
                }
                P.Add(lstData);

                for (int j = 0; j < M; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        P[i][j]= A[i][j];                        
                    }
                    else if (i == 0 && j > 0)
                    {
                        P[i][j] = (A[i][j] % modVal + P[i][j - 1] % modVal) % modVal;                        
                    }
                    else if (i > 0 && j == 0)
                    {
                        P[i][j] = (A[i][j] % modVal + P[i - 1][j] % modVal) % modVal;                        
                    }
                    else
                    {
                        P[i][j] = (A[i][j] % modVal + P[i - 1][j] % modVal + P[i][j - 1] % modVal - P[i - 1][j - 1] % modVal) % modVal;                        
                    }
                }               
            }

            //Set all result based on value
            for (int k = 0; k < B.Count; k++)
            {
                int sX = B[k] - 1, sY = C[k] - 1, eX = D[k] - 1, eY = E[k] - 1;
                //end p [D[k]-1,E[k]-1]
                //start p [B[k]-1,C[k]-1]
                int answer = 0;
                if (sX == 0 && eX == 0)
                {
                    answer = P[eX][eY]- P[eX][sY-1];
                }
                else if (sY == 0 && eY == 0)
                {
                    answer = P[eX][eY] - P[sX-1][eY];
                }
                else if(sX == 0 && sY == 0)
                {
                    answer = P[eX][eY];
                }
                else if(sX == 0)
                {
                    answer = P[eX][eY] - P[eX][sY - 1] ;
                }
                else if(sY == 0)
                {
                    answer = P[eX][eY] - P[sX - 1][eY];
                }
                else
                {
                    answer = P[eX][eY] - P[sX - 1][eY] - P[eX][sY - 1] + P[sX - 1][sY - 1];
                }


                result.Add(answer);
            }

            return result;

        }
    }
}
