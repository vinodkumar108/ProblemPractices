using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFSGraph
{
    class Program
    {
        static void Main(string[] args)
        {
            List<List<int>> edges = new List<List<int>>();

            edges.Add(new List<int> { 1, 2 });
            edges.Add(new List<int> { 4, 5 });
            edges.Add(new List<int> { 2, 4 });
            edges.Add(new List<int> { 3, 4 });
            edges.Add(new List<int> { 5, 2 });
            edges.Add(new List<int> { 1, 3 });

            int[] visited = new int[5];

            bool ans = DFSNodeFound(1, 5, visited, edges);

            Console.Read();

        }

        public static bool DFSNodeFound(int source, int target,int[] visited, List<List<int>> edges)
        {
            visited[source-1] = 1;

            if(source == target)
            {
                return true;
            }

            //Get all neighours
            List<int> connEdges = edges.Where(x => x[0] == source).Select(x => x[1]).ToList();
            foreach(int connSource in connEdges)
            {
                if(visited[connSource-1] ==0)
                {
                    bool result = DFSNodeFound(connSource, target, visited, edges);
                    if(result)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
