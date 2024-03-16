using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCars
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> timeList = new List<int> { 1, 7, 6, 2, 8, 4, 4, 6, 8, 2 };
            List<int> profList = new List<int> { 8, 11, 7, 7, 10, 8, 7, 5, 4, 9 };
            Solution objSol = new Solution();

            int answer = objSol.solve(timeList, profList);
            Console.Read();
        }
    }
    class Solution
    {
        public int solve(List<int> A, List<int> B)
        {

            List<ProfitCar> lstProfit = new List<ProfitCar>();

            for (int i = 0; i < A.Count; i++)
            {
                lstProfit.Add(new ProfitCar(A[i], B[i]));
            }

            lstProfit = lstProfit.OrderBy(x => x.time).ToList();

            int mod = (int)Math.Pow(10, 9) + 7;
            PriorityQueue<int> pQ = new PriorityQueue<int>();
            int answer = 0;
            int T = 0;
            for (int i = 0; i < lstProfit.Count; i++)
            {
                if (T < lstProfit[i].time)
                {
                    pQ.Enqueue(lstProfit[i].profit);
                    T++;
                }
                else
                {
                    if (lstProfit[i].profit > pQ.Peek())
                    {
                        pQ.Dequeue();
                        pQ.Enqueue(lstProfit[i].profit);
                    }
                }
            }

            while (pQ.Count > 0)
            {
                int profitItem = pQ.Peek();
                answer = (answer % mod + profitItem % mod) % mod;
                pQ.Dequeue();
            }

            return answer;

        }
    }
    //MIN HEAP
    public class PriorityQueue<T> where T : IComparable<T>
    {
        private List<T> heap = new List<T>();

        public int Count => heap.Count;

        public void Enqueue(T item)
        {
            heap.Add(item);
            int currentIndex = heap.Count - 1;
            while (currentIndex > 0)
            {
                int parentIndex = (currentIndex - 1) / 2;
                if (heap[currentIndex].CompareTo(heap[parentIndex]) < 0)
                {
                    Swap(currentIndex, parentIndex);
                    currentIndex = parentIndex;
                }
                else
                {
                    break;
                }
            }
        }

        public T Dequeue()
        {
            if (heap.Count == 0)
            {
                throw new InvalidOperationException("Priority queue is empty");
            }

            T firstItem = heap[0];
            int lastIndex = heap.Count - 1;
            heap[0] = heap[lastIndex];
            heap.RemoveAt(lastIndex);
            lastIndex--;

            int currentIndex = 0;
            while (true)
            {
                int leftChildIndex = currentIndex * 2 + 1;
                int rightChildIndex = currentIndex * 2 + 2;
                int smallestChildIndex = 0;

                if (leftChildIndex <= lastIndex)
                {
                    smallestChildIndex = leftChildIndex;
                    if (rightChildIndex <= lastIndex && heap[rightChildIndex].CompareTo(heap[leftChildIndex]) < 0)
                    {
                        smallestChildIndex = rightChildIndex;
                    }
                    if (heap[smallestChildIndex].CompareTo(heap[currentIndex]) < 0)
                    {
                        Swap(currentIndex, smallestChildIndex);
                        currentIndex = smallestChildIndex;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            return firstItem;
        }
        public T Peek()
        {
            T firstItem = heap[0];
            return firstItem;
        }
        private void Swap(int index1, int index2)
        {
            T temp = heap[index1];
            heap[index1] = heap[index2];
            heap[index2] = temp;
        }
    }
    public class ProfitCar
    {
        public int time;
        public int profit;
        public ProfitCar(int x, int y)
        {
            this.time = x;
            this.profit = y;
        }
    }

}
