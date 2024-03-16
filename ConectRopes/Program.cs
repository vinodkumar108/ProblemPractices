using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConectRopes
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution objSol = new Solution();
            List<int> input = new List<int>() { 16,7,3,5,9,8,6,15};

            int result = objSol.solve(input);

            Console.Read();

            

        }
    }
   

class Solution
    {
        public int solve(List<int> A)
        {
            SortedSet<int> pQ = new SortedSet<int>();
            int answer = 0;

            //Insert all value in priority queue
            for (int i = 0; i < A.Count; i++)
            {
                pQ.Add(A[i]);
            }

            while (pQ.Count >= 2)
            {
                int dq1 = pQ.Min;
                pQ.Remove(dq1);
                int dq2 = pQ.Min;
                pQ.Remove(dq2);

                int sum = dq1 + dq2;
                answer = answer + sum;

                pQ.Add(sum);
            }

            return answer;
        }
    }
}
