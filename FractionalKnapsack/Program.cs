using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionalKnapsack
{
    class Program
    {
        static void Main(string[] args)
        {
           // List<int> hpList = new List<int>() { 16, 3, 3, 6, 7, 8, 17, 13, 7 };
           // List<int> wtList = new List<int>() { 3, 10, 9, 18, 17, 17, 6, 16, 13 };

            List<int> hpList = new List<int>() { 3 };
            List<int> wtList = new List<int>() { 20 };


            Solution sol = new Solution();

            int ans = sol.solve(hpList, wtList, 17);

        }
    }
    
    class Solution
    {
        public int solve(List<int> A, List<int> B, int C)
        {

            Tuple<int, int,double>[] lst = new Tuple<int, int,double>[A.Count];

            for (int i = 0; i < A.Count; i++)
            {
                double vPrWegiht = (double)A[i] / B[i];
                lst[i]=new Tuple<int, int,double>(A[i], B[i], vPrWegiht);
            }
            
           
            Array.Sort(lst, new MyTupleComparer());

            decimal answer = 0;
            int selectedWT = 0;

            foreach (var item in lst)
            {
                //Console.WriteLine(item.Item1 + "-" + item.Item2);
                if (C > 0 && C > (item.Item2 + selectedWT))
                {
                    answer = answer + (item.Item1);
                    //C = C - item.Item2;
                    selectedWT = selectedWT + item.Item2;
                }
                else
                {
                    decimal fact = (Convert.ToDecimal(C - selectedWT) / item.Item2);
                    answer = answer + (item.Item1 * fact);
                    // Console.WriteLine("ANS-" + answer);
                    break;
                }

                //Console.WriteLine("ANS-" + answer);
            }

            return (int)(answer * 100);
        }

        public class MyTupleComparer : Comparer<Tuple<int, int,double>>
        {
            public override int Compare(Tuple<int, int, double> x, Tuple<int, int, double> y)
            {
                
                if (x.Item3 < y.Item3)
                {
                    return 1;
                }
                else if(x.Item3 > y.Item3)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }

}
