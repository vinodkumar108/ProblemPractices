using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningMedian
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = new List<int> { 10, 47, 82, 30, 52, 46, 84, 47, 97, 38 };
            Solution objSol = new Solution();
            var result = objSol.solve(input);
            Console.Read();
        }
    }
    public class Solution
    {
        public List<int> solve(List<int> A)
        {

            PriorityMaxQueue<int> pqMax = new PriorityMaxQueue<int>();
            PriorityMinQueue<int> pqMin = new PriorityMinQueue<int>();
            List<int> result = new List<int>();

            pqMax.Enqueue(A[0]);
            result.Add(pqMax.Peek());

            for (int i = 1; i < A.Count; i++)
            {
                int maxItem = pqMax.Peek();

                if (pqMin.Count > 0)
                {
                    int minItem = pqMin.Peek();
                    if (A[i] > minItem)
                    {
                        pqMin.Enqueue(A[i]);

                        if (pqMin.Count == pqMax.Count)
                        {
                            result.Add(pqMax.Peek());
                        }

                        if (pqMin.Count != pqMax.Count && (pqMin.Count - pqMax.Count) == 1)
                        {
                            result.Add(pqMin.Peek());
                        }

                        if (pqMin.Count != pqMax.Count && (pqMin.Count - pqMax.Count) == 2)
                        {
                            int itemToShift = pqMin.Peek();
                            pqMax.Enqueue(itemToShift);
                            pqMin.Dequeue();
                            result.Add(pqMax.Peek());
                        }

                        
                    }
                    else if (A[i] <= minItem)
                    {
                        pqMax.Enqueue(A[i]);

                        if (pqMin.Count == pqMax.Count)
                        {
                            result.Add(pqMax.Peek());
                        }

                        if (pqMin.Count != pqMax.Count && (pqMax.Count - pqMin.Count) == 1)
                        {
                            result.Add(pqMax.Peek());
                        }

                        if (pqMin.Count != pqMax.Count && (pqMax.Count - pqMin.Count) == 2)
                        {
                            int itemToShift = pqMax.Peek();
                            pqMin.Enqueue(itemToShift);
                            pqMax.Dequeue();
                            result.Add(pqMax.Peek());
                        }

                        
                    }

                }
                else if (pqMin.Count == 0 && pqMax.Count > 0)
                {

                    if(A[i] > pqMax.Peek())
                    {
                        pqMin.Enqueue(A[i]);
                        result.Add(pqMax.Peek());
                    }
                    else
                    {
                        pqMax.Enqueue(A[i]);
                        int itemToShift = pqMax.Peek();
                        pqMin.Enqueue(itemToShift);
                        pqMax.Dequeue();
                        result.Add(pqMax.Peek());
                    }

                   
                }
            }

            return result;
        }
    }

    //MIN HEAP
    public class PriorityMinQueue<T> where T : IComparable<T>
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


    /* MAX heap*/
    public class PriorityMaxQueue<T> where T : IComparable<T>
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
                if (heap[currentIndex].CompareTo(heap[parentIndex]) > 0)
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
                    if (rightChildIndex <= lastIndex && heap[rightChildIndex].CompareTo(heap[leftChildIndex]) > 0)
                    {
                        smallestChildIndex = rightChildIndex;
                    }
                    if (heap[smallestChildIndex].CompareTo(heap[currentIndex]) > 0)
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
