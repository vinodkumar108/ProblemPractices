using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subsets
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution obj = new Solution();
            List<int> input = new List<int> { 1, 2 };
            List<List<int>> answer = obj.subsets(input);

            Console.Read();
        }
    }
    class Solution
    {

        public List<List<int>> subsets(List<int> A)
        {

            List<List<int>> result = new List<List<int>>();
            List<int> curr = new List<int>();

            A.Sort();
            MakeSubset(A, 0, curr, result);

            //lexicographic  order         
            result.Sort((o1, o2) => {
                int n = Math.Min(o1.Count, o2.Count);
                for (int i = 0; i < n; i++)
                {
                    if (o1[i] == o2[i])
                    {
                        continue;
                    }
                    else
                    {
                        return o1[i].CompareTo(o2[i]);
                    }
                }
                return o1.Count.CompareTo(o2.Count);
            });
            return result;

        }
        public void MakeSubset(List<int> A, int i, List<int> curr, List<List<int>> res)
        {
            if (i >= A.Count)
            {
                curr.Sort();
                List<int> curList = curr.ToList();
                res.Add(curList);
                return;
            }

            curr.Add(A[i]);
            MakeSubset(A, i + 1, curr, res);
            curr.RemoveAt(curr.Count() - 1);
            MakeSubset(A, i + 1, curr, res);

            return;
        }
    }

}
