using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PainterPartision
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution sl = new Solution();
            //List<int> boards = new List<int> { 884, 228, 442, 889 };
            //884,228,442,889
            //884, 865, 800, 889
            //int ans = sl.paint(4, 10, boards);

            List<int> boards = new List<int> { 1000000, 1000000 };
            //884,228,442,889
            //884, 865, 800, 889
            int ans = sl.paint(1, 1000000, boards);

            Console.Read();
        }
    }

    class Solution
    {
        public int paint(int A, int B, List<int> C)
        {

            long L = 0;
            long R = 0;

            for (int i = 0; i < C.Count; i++)
            {
                R = R+C[i];

                if (L < C[i])
                {
                    L = C[i];
                }
            }

            L = L * B;
            R = R * B;

            if(A==1)
            {
                long ans =R % 10000003;
                return (int)ans;
            }

            while (L <= R)
            {
                long mid = L + (R - L) / 2;

                int painterCount1 = calculateTotalPainters(C, mid, B);
                int painterCount2 = calculateTotalPainters(C, mid - 1, B);

                if (painterCount1 <= A && (painterCount2 > A || painterCount2 == -1))
                {
                    long ans = mid % 10000003;
                    return (int)ans;                    
                }
                
                if (painterCount1 <= A)
                {
                    R = mid - 1;
                }
                else
                {
                    L = mid + 1;
                }
            }

            return -1;
        }
        public int calculateTotalPainters(List<int> C, long X, int B)
        {
            int totalPainterCount = 1;
            long rTime = X;
            for (int i = 0; i < C.Count; i++)
            {
                int tReq = C[i] * B;
                if (tReq > X)
                {
                    return -1;
                }

                if (rTime >= tReq)
                {
                    rTime = rTime - tReq;
                }
                else
                {
                    totalPainterCount++;
                    rTime = X - tReq;
                }
            }

            return totalPainterCount;
        }
    }

}
