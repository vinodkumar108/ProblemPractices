using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleGraph
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution objSol = new Solution();

            List<List<int>> B = new List<List<int>>();
           
            B.Add(new List<int> {1,4});
            B.Add(new List<int> {2,1});
            B.Add(new List<int> {4,3});
            B.Add(new List<int> {4,5});
            B.Add(new List<int> {2,3});
            B.Add(new List<int> {2,4});
            B.Add(new List<int> {1,5});
            B.Add(new List<int> {5,3});
            B.Add(new List<int> {2,5});
            B.Add(new List<int> { 5, 1 });
            B.Add(new List<int> { 4, 2 });
            B.Add(new List<int> { 3, 1 });
            B.Add(new List<int> { 5, 4 });
            B.Add(new List<int> { 3, 4 });
            B.Add(new List<int> { 1, 3 });
            B.Add(new List<int> { 4, 1 });
            B.Add(new List<int> { 3, 5 });
            B.Add(new List<int> { 3, 2 });
            B.Add(new List<int> { 5, 2 });

            int res = objSol.solve(5, B);

            Console.Read();

        }
    }
    class Solution
    {
        public int solve(int A, List<List<int>> B)
        {

            bool[] visited = new bool[A + 1];
            bool[] path = new bool[A + 1];

            if (B.Count() == 1) // For 1 size, there is no cyclic
            {
                return 0;
            }

            visited[0] = false;
            visited[1] = false;
            path[0] = false;
            path[1] = false;

            // Create adjacency List to store the element with respect to Nodes
            List<List<int>> list = new List<List<int>>();

            for (int i = 0; i <= A; i++)
            {
                list.Add(new List<int>()); // initialing A number of nodes
            }

            for (int i = 0; i < B.Count(); i++)
            {
                list[B[i][0]].Add(B[i][1]); // creating adjacency list
            }

            for (int i = 1; i <= A; i++)
            {
                if (!visited[i] && dfs(i, list, visited, path))
                {
                    return 1;
                }
            }

            return 0;
        }
        public bool dfs(int source, List<List<int>> edges, bool[] visited, bool[] path)
        {
            visited[source] = true;
            path[source] = true;

            //Get all edges neighbours for current node
            //List<int> connEdges = edges.Where(x => x[0] == source).Select(x => x[1]).ToList();
            foreach (int connSource in edges[source])
            {
                if (path[connSource])
                {
                    return true;
                }

                if (visited[connSource] && dfs(connSource, edges, visited, path))
                {
                    return true;
                }
            }

            path[source] = false;

            return false;
        }
    }
}
