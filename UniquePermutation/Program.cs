using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniquePermutation
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 1, 1, 2};
            List<List<int>> permutations = GetUniquePermutations(numbers);

            foreach (List<int> permutation in permutations)
            {
                Console.WriteLine(string.Join(", ", permutation));
            }

            Console.Read();
        }
        static List<List<int>> GetUniquePermutations(List<int> numbers)
        {
            List<List<int>> result = new List<List<int>>();
            Permute(numbers, 0, result);
            return result;
        }

        static void Permute(List<int> numbers, int start, List<List<int>> result)
        {
            if (start == numbers.Count - 1)
            {
                result.Add(new List<int>(numbers));
                return;
            }

            for (int i = start; i < numbers.Count; i++)
            {
                if (numbers.Skip(start).Take(i - start).Contains(numbers[i]))
                {
                    continue;
                }

                Swap(numbers, start, i);
                Permute(numbers, start + 1, result);
                Swap(numbers, start, i);
            }
        }

        static void Swap(List<int> numbers, int i, int j)
        {
            int temp = numbers[i];
            numbers[i] = numbers[j];
            numbers[j] = temp;
        }
    }
}


