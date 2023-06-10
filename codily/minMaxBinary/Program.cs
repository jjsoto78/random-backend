using System;

namespace minMaxBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = { 2, 1, 5, 1, 2, 2, 2};
            var solution = new Solution().solution(3,5,A);
            Console.WriteLine(solution);
        }
    }

    
    class Solution
    {
        public int solution(int K, int M, int[] A)
        {
            int left = 0;
            int right = 0;
            
            for (int i = 0; i < A.Length; i++)
            {//get the sum as max, and the largest number as min
                right += A[i];
                left = Math.Max(left, A[i]);
            }

            int guessResult = right;
            
            while (left <= right)
            {
                int mid = (left + right) / 2;
                int blocks = countBlocks(A, mid);

                // if blocks is > N, mid is too low and then too many blocks where formed
                // if blocks < K, the mid is high, so too little blocks were formed

                if(blocks > K) {
                    left = mid + 1;
                }
                else {
                    right = mid - 1;
                    // if(mid < guess)
                    guessResult = mid;
                }

            }
            return guessResult;
        }

        // each block represents a sum of A elements for a given mid
        private int countBlocks(int[] A, int mid)
        {
            // start counting on block 1
            int blocks = 1;
            int blockSum = 0;

            // traverse A counting for blocks,
            // a block is complete when the sum overflows mid
            for (int i = 0; i < A.Length; i++)
            {
                blockSum+= A[i];
                // sum overflow happed
                if (blockSum > mid) {
                    blocks++; // counts block
                    blockSum = A[i]; // begins the sum of the next block
                }
            }

            return blocks;
        }

    }

    // class Solution
    // {
    //     public int solution(int K, int M, int[] A)
    //     {
    //         int min = 0;
    //         int max = 0;
    //         for (int i = 0; i < A.Length; i++)
    //         {//get the sum as max, and the largest number as min
    //             max += A[i];
    //             min = Math.Max(min, A[i]);
    //         }
    //         int result = max;
    //         while (min <= max)
    //         {
    //             int mid = (min + max) / 2;
    //             if (divisionSolvable(mid, K - 1, A))
    //             {
    //                 max = mid - 1;
    //                 result = mid;
    //             }
    //             else
    //             {
    //                 min = mid + 1;
    //             }
    //         }
    //         return result;
    //     }
    //     private static bool divisionSolvable(int mid, int k, int[] a)
    //     {
    //         int sum = 0;
    //         for (int i = 0; i < a.Length; i++)
    //         {
    //             sum += a[i];
    //             if (sum > mid)
    //             {
    //                 sum = a[i];
    //                 k--;
    //             }
    //             if (k < 0)
    //             {
    //                 return false;
    //             }
    //         }
    //         return true;
    //     }

    // }
}
