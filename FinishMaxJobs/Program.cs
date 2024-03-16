using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinishMaxJobs
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> stTimeList = new List<int>() { 4, 4, 8, 15, 6 };
            List<int> fnTimeList = new List<int>() { 9, 5, 15, 16, 7 };
            Solution objSOl = new Solution();

            int answer = objSOl.solve(stTimeList, fnTimeList);
            Console.Read();
        }
    }
    class Solution
    {
        public int solve(List<int> A, List<int> B)
        {

            List<Tuple<int, int>> tList = new List<Tuple<int, int>>();

            for (int i = 0; i < A.Count; i++)
            {
                tList.Add(new Tuple<int, int>(B[i], A[i]));
            }

            var list = tList.OrderBy(c => c.Item1).ToList();

            int answer = 1;
            int lastEndTime = list[0].Item1;

            for (int i = 1; i < A.Count; i++)
            {
                int startTime = list[i].Item2;

                if (startTime >= lastEndTime)
                {
                    answer++;
                    lastEndTime = list[i].Item1;
                }
            }

            return answer;

        }
    }

}
