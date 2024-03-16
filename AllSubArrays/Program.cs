using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllSubArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lst = new List<int> { 1, 2, 3 };

            List<List<int>> lstResult = solve(lst);

            Console.ReadLine();
        }
        public static List<List<int>> solve(List<int> A)
        {

            List<List<int>> lstArray = new List<List<int>>();

            for (int i = 0; i < A.Count; i++)
            {               
                for (int j = i; j < A.Count; j++)
                {
                    var newArray = A.Skip(i).Take(j+1).ToList();
                    lstArray.Add(newArray);
                }
            }

            return lstArray;
        }
    }
}
