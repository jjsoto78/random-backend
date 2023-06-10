using System;
using System.Linq;

namespace maxSliceReturnsArray
{
    class Program
    {
        static void Main(string[] args)
        {
            // max slice sum array but returning the slice array

            int[] A = { -2, -3, 4, -1, -2, 1, 5, -3 };
            // int[] A = { 5, -7, 3, 5, -2, 4, -1 };
            //  int[] A = { -2, -3, -3, 20 };

            int adyacentSum = A[0];
            int bestSum = A[0];
            
            // indexes of max slice 
            int l = 0;
            int r = 0;

            for (int i = 1; i < A.Length; i++)
            {
                adyacentSum = A[i] + adyacentSum;
                // adyacentSum = Math.Max(A[i], adyacentSum);

                if(adyacentSum < A[i] ) {
                    adyacentSum = A[i];
                    l = i; // move to the right skipping
                    r = i; 
                }
                else{
                    r++;
                }

                bestSum = Math.Max(adyacentSum, bestSum);
            }
            
            var maxSlice = A.Select( e => e).Skip(l).Take(r-2).ToArray();

            Console.WriteLine(String.Join(",", maxSlice));
            Console.WriteLine($"{bestSum} l: {l}, r: {r}");
        }
    }
}
