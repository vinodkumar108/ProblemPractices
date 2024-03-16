using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnapSack2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> A = new List<int> { 16, 3, 3, 6, 7, 8, 17, 13, 7 };
            List<int> B = new List<int> { 3, 10, 9, 18, 17, 17, 6, 16, 13 };

            int res = solve(A, B, 11);

            Console.Read();

        }

        public static int solve(List<int> A, List<int> B, int C)
        {

            Tuple<int, int>[] lst = new Tuple<int, int>[A.Count];

            for (int i = 0; i < A.Count; i++)
            {
                lst[i] = new Tuple<int, int>(A[i], B[i]);
            }

            Array.Sort(lst, new MyTupleComparer());

            decimal answer = 0;

            foreach (var item in lst)
            {                
                Console.WriteLine(item.Item1 + "-" + item.Item2);
                if (C > 0 && C > item.Item2)
                {
                    answer = answer + (item.Item1);
                    C = C - item.Item2;
                }
                else
                {
                    decimal fact = (Convert.ToDecimal(C) / item.Item2);
                    answer = answer + (item.Item1 * fact);
                    Console.WriteLine("ANS-" + answer);
                    break;
                }

                Console.WriteLine("ANS-" + answer);
            }

            return (int)answer*100;
        }

        public class MyTupleComparer : Comparer<Tuple<int, int>>
        {
            public override int Compare(Tuple<int, int> x, Tuple<int, int> y)
            {
                if((Convert.ToDecimal(x.Item1)/x.Item2) > (Convert.ToDecimal(y.Item1)/y.Item2))
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
        }

}
}
