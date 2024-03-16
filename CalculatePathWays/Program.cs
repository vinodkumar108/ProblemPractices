using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatePathWays
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution obj = new Solution();
            List<List<int>> inputList = new List<List<int>>();
            //inputList.Add(new List<int> { 0, 0 });
            //inputList.Add(new List<int> { 0, 0 });
            //inputList.Add(new List<int> { 0, 0 });
            //inputList.Add(new List<int> { 1, 0 });
            //inputList.Add(new List<int> { 0, 0 });

            inputList.Add(new List<int> { 0,0 });


            int ans = obj.uniquePathsWithObstacles(inputList);

            Console.Read();

        }
    }
    class Solution
    {
        //Make DP Instance
        List<List<int>> DPL = new List<List<int>>();

        public int uniquePathsWithObstacles(List<List<int>> A)
        {

            int N = A.Count;
            int M = A[0].Count;          

            //SET Default values
            for (int i = 0; i < A.Count; i++)
            {
                List<int> lstItem = new List<int>();
                for (int j = 0; j < A[0].Count; j++)
                {
                    if(i==0 && j==0)
                    {
                        lstItem.Add(1);
                    }
                    else if (i == 0 || j == 0)
                    {
                        if (A[i][j] == 0 && i > 0 && DPL[i - 1][j] == 1)
                        {
                            lstItem.Add(1);
                        }
                        else if (A[i][j] == 0 && j > 0 && lstItem[j-1] == 1)
                        {
                            lstItem.Add(1);
                        }
                        else
                        {
                            lstItem.Add(0);
                        }                        
                    }
                    else
                    {
                        lstItem.Add(-1);
                    }
                }

                DPL.Add(lstItem);
            }

            //Calcualte ways
            int answer = CalculateWays(A, N - 1, M - 1);

            return answer;
        }
        public int CalculateWays(List<List<int>> A, int i, int j)
        {
            if (i == 0 || j == 0)
            {
                if (A[i][j] == 0 && i > 0 &&  DPL[i-1][j] == 1 )
                {
                    DPL[i][j] = 1;
                    Console.WriteLine("i=" + i + ",j=" + j + ":val-" + DPL[i][j]);
                    return 1;
                }
                if (A[i][j] == 0 && j > 0 && DPL[i][j - 1] == 1)
                {
                    DPL[i][j] = 1;
                    Console.WriteLine("i=" + i + ",j=" + j + ":val-" + DPL[i][j]);
                    return 1;
                }
                else
                {
                    DPL[i][j] = 0;
                    Console.WriteLine("i=" + i + ",j=" + j + ":val-" + DPL[i][j]);
                    return 0;
                }
            }

            if (DPL[i][j] != -1)
            {
                Console.WriteLine("i=" + i + ",j=" + j + ":val-" + DPL[i][j]);
                return DPL[i][j];
            }

            int ans = 0;
            if (A[i][j] == 0)
            {
                ans = CalculateWays(A, i - 1, j) + CalculateWays(A, i, j - 1);
            }

            DPL[i][j] = ans;
            return ans;
        }
    }

}
