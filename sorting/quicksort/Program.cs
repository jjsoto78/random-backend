using System;
using System.Collections.Generic;

namespace quicksort
{
    class Program
    {
        static void Main(string[] args)
        {
            var sort = quickSort(new List<int> { 8, 5, 1, 7, 9, 3, 4, 1, 0, 99 });
            Console.WriteLine(String.Join(',', sort));
        }

        public static List<int> quickSort(List<int> list)
        {
            List<int> left = new List<int>();
            List<int> right = new List<int>();
            int pivot = list[0]; // first list element

            list.Remove(pivot);

            list.ForEach(e =>
            {
                if (e > pivot)
                    right.Add(e);
                else
                    left.Add(e);
            });

            if (left.Count > 0)
                left = new List<int>(quickSort(left));

            if (right.Count > 0)
                right = new List<int>(quickSort(right));

            List<int> result = new List<int>();
            result.AddRange(left);
            result.Add(pivot);
            result.AddRange(right);

            return result;
        }
    }
}
