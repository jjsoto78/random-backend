using System;

namespace maxCommonDivisor
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(getMaxDivisor(5,15));
        }

        private static int getMaxDivisor(int a, int b)
        {
            int maxN = Math.Max(a, b);
            int minN = Math.Min(a, b);

            if (maxN % minN == 0)
                return minN;

            int bestCommonDivisor = 1;

            // any common divisor must be <= than half the min number
            int limitN = Math.Min(a, b) / 2;

            for (int i = 1; i <= limitN; i++)
            {
                int aDivisor = a % i;
                int bDivisor = b % i;

                if (aDivisor == 0 && bDivisor == 0 && bestCommonDivisor <= i)
                    bestCommonDivisor = i;
            }

            return bestCommonDivisor;
        }
    }
}
