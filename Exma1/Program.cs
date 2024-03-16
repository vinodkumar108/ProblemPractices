using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exma1
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution obj = new Solution();
            long ans = obj.solve(new List<int> { 21,21,31,20,34,32,34,22,35});

            Console.Read();
        }
    }

    class Solution
    {
        public long solve(List<int> A)
        {

            long answer = 0;

            if (A.Count == 1)
            {
                return answer;
            }

            PriorityQueue<long> pqList = new PriorityQueue<long>();

            for (int i = 0; i < A.Count; i++)
            {
                pqList.Enqueue((long)A[i]);
            }

            while (pqList.Count > 1)
            {
                long firstItem = pqList.Dequeue();
                long secondItem = pqList.Dequeue();
                long total = firstItem + secondItem;
                pqList.Enqueue(total);
                answer = answer + total;
            }

            return answer;

        }

    }
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
                throw new InvalidOperationException("Priority Queue is Empty");
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
                    else if (heap[smallestChildIndex].CompareTo(heap[currentIndex]) < 0)
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

}
