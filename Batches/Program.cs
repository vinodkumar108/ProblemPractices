using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batches
{
    class Program
    {
        static void Main(string[] args)
        {
            //Batch 1 ->1,4,6,9,8
            int A = 9;
            List<int> B = new List<int> { 10, 8, 2, 3, 4, 8, 3, 5, 9 };
            List<List<int>> C = new List<List<int>>();

            C.Add(new List<int> { 1, 4 });
            C.Add(new List<int> { 1, 6 });
            C.Add(new List<int> { 2, 7 });
            C.Add(new List<int> { 2, 9 });
            C.Add(new List<int> { 3, 5 });
            C.Add(new List<int> { 3, 8 });
            C.Add(new List<int> { 4, 9 });
            C.Add(new List<int> { 5, 8 });
            C.Add(new List<int> { 6, 8 });          

            int D = 25;

            Solution sol = new Solution();
            int res = sol.solve(A, B, C, D);

            Console.Read();
        }
    }
    class Solution
    {

        List<int> parent = new List<int>();

        public int solve(int A, List<int> B, List<List<int>> C, int D)
        {

            int[] rootArr = new int[A + 1];

            int ans = 0;

            parent.Add(0);

            //Add Parent Array
            for (int i = 1; i <= A; i++)
            {
                parent.Add(i);
            }

            

            //Call query method for each student known to each other
            foreach (List<int> cItem in C)
            {
                query(cItem[0], cItem[1]);
            }

            //Add root Array
            for (int i = 1; i <= A; i++)
            {
                rootArr[i] = root(i);
            }

            //Create batch based on the group in dijoint set available
            Dictionary<int, List<int>> batchList = new Dictionary<int, List<int>>();
            Dictionary<int, int> batchStrength = new Dictionary<int, int>();

            for (int i = 1; i <= A; i++)
            {
                if (batchList.ContainsKey(rootArr[i]))
                {
                    List<int> stdList = batchList[rootArr[i]];
                    stdList.Add(i);
                    batchList[rootArr[i]] = stdList;

                    //update batchStrength
                    int strength = batchStrength[rootArr[i]];
                    batchStrength[rootArr[i]] = strength + B[i - 1];
                }
                else
                {
                    List<int> stdList = new List<int>();
                    stdList.Add(i);
                    batchList.Add(rootArr[i], stdList);
                    batchStrength.Add(rootArr[i], B[i - 1]);
                }
            }

            foreach (KeyValuePair<int, int> item in batchStrength)
            {
                if (item.Value >= D)
                {
                    ans++;
                }
            }

            return ans;
        }

        public int root(int x)
        {   
            if(x == parent[x]) { return x; }

            int xRoot = root(parent[x]);

            parent[x] = xRoot;

            return xRoot;
        }

        public void query(int x, int y)
        {
            int xRoot = root(x);
            int yRoot = root(y);

            //both student are in different set and need to combine
            if (xRoot != yRoot)
            {
                parent[xRoot] = yRoot;
            }
        }
    }


}
