using System;

namespace maxSlice
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = new Solution().solution(new int[] {-2, 1, 1});
            // var result = new Solution().solution(new int[] {1, 1, 1});
            // var result = new Solution().solution(new int[] {-2, 1});
            // var result = new Solution().solution(new int[] {3,2,-6,4,0});
            // var result = new Solution().solution(new int[] {-1,-1,2,-1,3});
            // var result = new Solution().solution(new int[] {-1,-1,-2,-1,-3});
            // var result = new Solution().solution(new int[] {3, -2});

            Console.WriteLine(result);
        }
    }

    class Solution
    {
        public int solution(int[] A)
        {

            int absoluteMax = A[0];
            int localMax = A[0];
            int nextSum = 0;
            int currentElement = 0;

            for (int i = 1; i < A.Length; i++)
            {
                currentElement = A[i];
                nextSum = localMax + currentElement;
                localMax = Math.Max(A[i], nextSum);
                absoluteMax = Math.Max(absoluteMax, localMax);
            }
            return absoluteMax;
        }
    }
  
}
