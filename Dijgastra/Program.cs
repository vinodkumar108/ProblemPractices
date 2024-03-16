using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijgastra
{
    class Solution
    {
        public List<int> solve(int A, List<List<int>> B, int C)
        {

            List<int> dis = new List<int>();
            for (int i = 0; i < A + 1; i++)
            {
                dis.Add(-1);
            }

            dis[C] = 0; //set source distance 0

            SortedList<int, Pair> srtMinList = new SortedList<int, Pair>();
            srtMinList.Add(0, new Pair(C, 0));
            bool[] visited = new bool[A + 1];

            //Create adjacencyList for graph nodes
            Dictionary<int, List<Pair>> adjDict = new Dictionary<int, List<Pair>>();

            foreach (List<int> bItem in B)
            {
                int node1 = bItem[0];
                int node2 = bItem[1];
                int weight = bItem[2];

                //set weight for first direction
                if (adjDict.ContainsKey(node1))
                {
                    List<Pair> lstPairs = new List<Pair>();
                    lstPairs = adjDict[node1];
                    lstPairs.Add(new Pair(node2, weight));                    
                    adjDict[node1] = lstPairs;
                }
                else
                {
                    List<Pair> lstPairs = new List<Pair>();
                    lstPairs.Add(new Pair(node2, weight));
                    adjDict.Add(node1, lstPairs);
                }

                //set weight for second direction
                if (adjDict.ContainsKey(node2))
                {
                    List<Pair> lstPairs = new List<Pair>();
                    lstPairs = adjDict[node2];
                    lstPairs.Add(new Pair(node1, weight));
                    adjDict[node2]= lstPairs;
                }
                else
                {
                    List<Pair> lstPairs = new List<Pair>();
                    lstPairs.Add(new Pair(node1, weight));
                    adjDict.Add(node2, lstPairs);
                }
            }

            while (srtMinList.Count > 0)
            {
                KeyValuePair<int, Pair> p = srtMinList.FirstOrDefault();

                srtMinList.RemoveAt(0);

                Pair pV = p.Value;
                if (visited[pV.ver])
                {
                    continue;
                }

                visited[pV.ver] = true;

                dis[pV.ver] = pV.wt;
                List<Pair> lstPairs = new List<Pair>();
                lstPairs = adjDict[pV.ver];
                foreach (Pair prItem in lstPairs)
                {
                    if (dis[prItem.ver] == -1)
                    {
                        if(srtMinList.ContainsKey(prItem.ver))
                        {
                            srtMinList[prItem.ver] = new Pair(prItem.ver, pV.wt + prItem.wt);
                        }
                        else
                        {
                            srtMinList.Add(prItem.ver, new Pair(prItem.ver, pV.wt + prItem.wt));
                        }
                        
                    }
                }                
            }

            return dis;
        }
    }

    class Pair
    {
        public int ver;
        public int wt;
        public Pair(int v, int w)
        {
            this.ver = v;
            this.wt = w;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Solution sol = new Solution();
            int A = 6;
            int C = 4;
            List<List<int>> B = new List<List<int>>();
            B.Add(new List<int> { 0, 4, 9 });
            B.Add(new List<int> { 3, 4, 6 });
            B.Add(new List<int> { 1, 2, 1 });
            B.Add(new List<int> { 2, 5, 1 });
            B.Add(new List<int> { 2, 4, 5 });
            B.Add(new List<int> { 0, 3, 7 });
            B.Add(new List<int> { 0, 1, 1 });
            B.Add(new List<int> { 4, 5, 7 });
            B.Add(new List<int> { 0, 5, 1 });

            List<int> res = sol.solve(A, B, C);
            Console.Read();

        }
    }
    
}
