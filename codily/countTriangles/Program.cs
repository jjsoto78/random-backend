using System;

// https://www.geeksforgeeks.org/find-number-of-triangles-possible/

namespace countTriangles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = {3,3,5,6};
            Console.WriteLine($"Found {new Solution().solution(A)} triangles");
        }
    }

    class Solution
    {
        public int solution(int[] A)
        {
            // Implement your solution here
            int n = A.Length;

            Array.Sort(A);

            // aI, bI are fixed triangle sides, searchI finds a range of valid 3rd side solutions
            // since the array is sorted the amount of solutions can be expressed as indexes difference
            int trianglesCount = 0;

            for (int aI = 0; aI < n - 2; ++aI) // there has to be 2 elements forward 
            {
                int searchI = aI+2;

                for (int bI = aI+1; bI < n; ++bI)
                {
                    // search for the rightmost index where triangle conditions are met
                    while (searchI < n && A[aI] + A[bI] > A[searchI]){
                        // searchI goes === n at the end so -1 to the result
                        ++searchI;
                        if (searchI > bI)
                            // every possible 3rd side to the right of bI is a valid solution, because the array is sorted
                            trianglesCount += searchI - bI - 1;
                    }   
                }
            }

            return trianglesCount;
               
        }
    }

