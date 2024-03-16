using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairSumDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputLst = new List<int> { 1, 2, 3, 4, 5 };
            int result = solve(inputLst, 2);
            Console.Read();
        }
        public static int solve(List<int> A, int B)
        {

            int answer = 0;
            int mod = 1000000007;
            Dictionary<int, int> hashReminder = new Dictionary<int, int>();

            for (int i = 0; i < A.Count; i++)
            {
                int reminder = A[i] % B;
                if (hashReminder.ContainsKey(reminder))
                {
                    hashReminder[reminder] += 1;
                }
                else
                {
                    hashReminder[reminder] = 1;
                }
            }

            if (hashReminder.ContainsKey(0))
            {
                int n = hashReminder[0];
                answer = answer + (((n % mod) * (n - 1) % mod) % mod) / 2;
            }

            if (B % 2 == 0)
            {
                if (hashReminder.ContainsKey(B / 2))
                {
                    int n = hashReminder[B / 2];
                    answer = answer+(((n % mod) * (n - 1) % mod) % mod) / 2;
                }
            }

            for (int j = 1; j < (System.Math.Ceiling(B / 2.0) - 1); j++)
            {
                int jthCount = 0;
                int jthComplementCount = 0;

                if (hashReminder.ContainsKey(j))
                {
                    jthCount = hashReminder[j];
                }

                if (hashReminder.ContainsKey(B - j))
                {
                    jthComplementCount = hashReminder[B - j];
                }

                answer = (answer + (jthCount % mod * jthComplementCount % mod) % mod) % mod;
            }

            return answer;
        }
    }
}
