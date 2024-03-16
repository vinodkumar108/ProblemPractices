using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatePath
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution sol = new Solution();
            int A = 4;
            List<List<int>> B = new List<List<int>>();
            //B.Add(new List<int> { 1, 2, 14 });
            //B.Add(new List<int> { 2, 3, 7 });
            //B.Add(new List<int> { 3, 1, 2 });

            B.Add(new List<int> { 1, 2, 1 });
            B.Add(new List<int> { 2, 3, 2 });
            B.Add(new List<int> { 3, 4, 1 });
            B.Add(new List<int> { 1, 3, 8 });
            B.Add(new List<int> { 1, 4, 12 });

            int res = sol.solve(A, B);
            Console.Read();
        }
    }
    class Solution1
    {

        int[] parent;
        int[] size;

        public int solve(int A, List<List<int>> B)
        {
            long ans = 0;
            int mod = 1000 * 1000 * 1000 + 7;
            parent = new int[A + 1];
            size = new int[A + 1];

            for (int i = 0; i < A + 1; i++)
            {
                parent[i] = i;
                size[i] = 1;
            }

            List<List<int>> items = B;
            items.Sort((a, b) => {
                return a[2] - b[2];
            });

            int N = items.Count;
            for (int i = 0; i < N; i++)
            {
                List<int> minEdgItem = items[i];

                int x = minEdgItem[0];
                int y = minEdgItem[1];
                int wt = minEdgItem[2];

                //items.Remove(minEdgItem);

                if (Root(x) == Root(y))
                {
                    continue;
                }
                else
                {
                    union(x, y);
                    ans = ((ans % mod) + wt % mod) % mod;
                }

            }

            return (int)ans;
        }

        public void union(int x, int y)
        {
            int rtX = Root(x);
            int rtY = Root(y);

            if (size[rtX] <= size[rtY])
            {
                parent[rtX] = rtY;
                size[rtY] += size[rtX];
            }
            else
            {
                parent[rtY] = rtX;
                size[rtX] += size[rtY];
            }

        }

        public int Root(int x)
        {
            // if(x == parent[x])
            // {
            //     return x;
            // }

            //int rt = Root(parent[x]);

            while (parent[x] != x)
            {
                parent[x] = parent[parent[x]];
                x = parent[x];
            }

            return x;
        }
    }
    class Solution
    {
        int[] parent;

        public int solve(int A, List<List<int>> B)
        {
            long ans = 0;
            int mod = 1000 * 1000 * 1000 + 7;
            parent = new int[A + 1];

            for (int i = 1; i < A + 1; i++)
            {
                parent[i] = i;
            }

            List<List<int>> items = B;
            items.Sort((a, b) => {
                return a[2] - b[2];
            });

            //SortedSet<Edge> sortEdges = new SortedSet<Edge>();

            //foreach (List<int> item in items)
            //{
            //    sortEdges.Add(new Edge(item[0], item[1], item[2]));
            //}

            while(items.Count > 0)
            {
                List<int> minEdgItem = items[0];

                int x = minEdgItem[0];
                int y = minEdgItem[1];
                int wt = minEdgItem[2];

                items.Remove(minEdgItem);

                if (union(x, y) == true)
                {
                    ans = ((ans%mod) + wt%mod)%mod;
                }
            }

            return (int)ans;

        }

        public bool union(int x, int y)
        {
            int rtX = Root(x);
            int rtY = Root(y);

            if(rtX == rtY)
            {
                return false;
            }
            else
            {
                parent[rtX] = rtY;
            }

            return true;
        }

        public int Root(int x)
        {
            while (parent[x] != x)
            {
                parent[x] = parent[parent[x]];
                x = parent[x];
            }

            return x;
        }
    }
    public class Edge : IComparable<Edge>
    {
        public int weight;
        public int src;
        public int des;

        public Edge(int s, int d, int w)
        {
            this.weight = w;
            this.src = s;
            this.des = d;
        }

        public int CompareTo(Edge other)
        {
            if (this.weight < other.weight)
            {
                return -1;
            }
            else if (this.weight > other.weight)
            {
                return 1;
            }

            return 0;
        }
    }

}
