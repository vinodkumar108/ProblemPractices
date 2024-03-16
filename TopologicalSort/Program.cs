using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopologicalSort
{
    class Program
    {
        static void Main(string[] args)
        {
            //[[1,4],[1,2],[4,2],[4,3],[3,2],[5,2],[3,5],[8,2],[8,6]]
            int A = 8;
            List<List<int>> B = new List<List<int>>();
            B.Add(new List<int> { 1, 4 });
            B.Add(new List<int> { 1, 2 });
            B.Add(new List<int> { 4, 2 });
            B.Add(new List<int> { 4, 3 });
            B.Add(new List<int> { 3, 2 });
            B.Add(new List<int> { 5, 2 });
            B.Add(new List<int> { 3, 5 });
            B.Add(new List<int> { 8, 2 });
            B.Add(new List<int> { 8, 6 });

            Solution sol = new Solution();
            List<int> res = sol.solve(A, B);
            Console.WriteLine("Printing All results:");
            for(int i=0;i<res.Count;i++)
            {
                Console.Write(res[i] + " ");
            }
            Console.Read();

        }
    }
    class Solution
    {
        public List<int> solve(int A, List<List<int>> B)
        {
            int[] inDegree = new int[A + 1];
            List<int> resTopoList = new List<int>();

            Dictionary<int, List<int>> grpHashMap = new Dictionary<int, List<int>>();

            //Update Indegree graph and neighbour list for each node
            foreach (List<int> item in B)
            {
                int sourceNode = item[0];
                int desNode = item[1];
                inDegree[desNode] = inDegree[desNode] + 1;

                if (grpHashMap.ContainsKey(sourceNode)) //Source code
                {
                    List<int> lstNode = grpHashMap[sourceNode];
                    lstNode.Add(desNode);
                    grpHashMap[sourceNode] = lstNode;
                }
                else
                {
                    grpHashMap.Add(sourceNode, new List<int> { desNode });
                }
            }

            SortedSet<int> qu = new SortedSet<int>();
            //Queue<int> qu = new Queue<int>();
            // inclde all indegree with zero in queue
            for (int i = 1; i < A + 1; i++)
            {
                if (inDegree[i] == 0)
                {
                    qu.Add(i);                   
                }
            }

            while (qu.Count > 0)
            {
                int nodeToProcess = qu.Min;
                qu.Remove(nodeToProcess);
                resTopoList.Add(nodeToProcess);

                if (grpHashMap.ContainsKey(nodeToProcess))
                {
                    List<int> lstNeighbourNode = grpHashMap[nodeToProcess];

                    foreach (int nodeItem in lstNeighbourNode)
                    {
                        inDegree[nodeItem] = inDegree[nodeItem] - 1;

                        if (inDegree[nodeItem] == 0)
                        {
                            qu.Add(nodeItem);
                        }
                    }
                }
            }

            if (resTopoList.Count != A)
            {
                return new List<int>();
            }

            return resTopoList;
        }
    }

}
