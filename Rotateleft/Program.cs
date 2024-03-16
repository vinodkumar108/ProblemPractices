using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rotateleft
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        public static List<List<int>> solve(List<int> A, List<int> B)
            {

                List<List<int>> resultList = new List<List<int>>();
                int N = B.Count;

                for (int i = 0; i < N; i++)
                {
                    //Get Left rotated for each B item

                    int aToRotate = B[i] % A.Count;
                    List<int> childList = new List<int>();

                    for (int j = aToRotate; j < A.Count; j++)
                    {
                        childList.Add(A[j]);
                    }

                    for (int k = 0; k < aToRotate; k++)
                    {
                        childList.Add(A[k]);
                    }

                    resultList.Add(childList);
                }

                return resultList;
            }
        }    
}
