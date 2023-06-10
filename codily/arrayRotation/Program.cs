using System;
using System.Collections;

namespace arrayRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            var A = new int[] { 6, 7, 9, 3 };
            var result = new Solution().solution(A, 3);
            // Console.WriteLine(result[0]);
        }
    }

    class Solution
    {
        public int[] solution(int[] A, int K)
        {
            // Implement your solution here
            var rotatedArray = new int[A.Length];

            for (int i = 0; i < A.Length; i++)
            {
                var rotatedIndex = (i + K) % (A.Length);
                rotatedArray[rotatedIndex] = A[i];
            }

            return rotatedArray;
        }
    }
}
