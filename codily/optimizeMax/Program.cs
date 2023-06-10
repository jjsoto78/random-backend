using System;
using System.Collections.Generic;

// https://leetcode.com/discuss/interview-question/398023/Microsoft-Online-Assessment-Questions/1263769
namespace optimizeMax
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = {9,10,11,78,9,9};
            Console.WriteLine(new Solution().GetMax(numbers));
            Console.WriteLine(new Solution().notOptimized(numbers));
        }
    }

    class Solution
    {
        public int GetMax(int[] nums)
        {
            int result = 0;
            var set = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (set.ContainsKey(nums[i]))
                {
                    result = Math.Max(result, i - set[nums[i]]);
                }
                else
                { set.Add(nums[i], i); }
            }
            return result;
        }

        public int notOptimized(int[] A)
        {
            int N = A.Length, result = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (A[i] == A[j]) result = Math.Max(result, Math.Abs(i - j));
                }
            }
            return result;
        }


    }
}
