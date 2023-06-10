using System;

namespace maxPalindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = new Solution().LongestPalindrome("aaa");

            Console.WriteLine(result);

        }
    }

    class Solution
    {
        public string LongestPalindrome(string S)
        {
            if(S.Length <= 1)
                return S;

            string maxPalindrome = string.Empty;

            for (int i = 0; i < S.Length; i++)
            {
                string nextCharacter = string.Empty;
                string previousCharacter = string.Empty;
                int left = i;
                int right = i;
                string localPalindrome = string.Empty;
                // string currentCharacter = S.Substring(i, 1);

                // search core
                while (canTakeRight(S, right))
                {
                    nextCharacter = S.Substring(right++, 1);
                    if (S.Substring(i, 1) == nextCharacter)
                        localPalindrome = $"{localPalindrome}{nextCharacter}";
                    else
                        break;
                }

                //search for extension of the palindrome
                // to the left at i-1 and to right at right-1
                left = i;
                right = i + localPalindrome.Length - 1;

                while (canTakeLeft(S, left) && canTakeRight(S, right))
                {
                    nextCharacter = S.Substring(++right, 1);
                    previousCharacter = S.Substring(--left, 1);

                    if (nextCharacter == previousCharacter)
                        localPalindrome = $"{previousCharacter}{localPalindrome}{nextCharacter}";
                    else
                        break;
                }

                maxPalindrome = (maxPalindrome.Length <= localPalindrome.Length) ? localPalindrome : maxPalindrome;

                // if(maxPalindrome.Length <= localPalindrome.Length)
                // {
                //     maxPalindrome = localPalindrome;
                //     i+= maxPalindrome.Length-1; // forward i to the end of palindrome just found, so is faster
                // }
            }

            return maxPalindrome;

        }

        bool canTakeLeft(string S, int index) => (index - 1 >= 0);

        bool canTakeRight(string S, int index) => (index + 1 < S.Length);

    }
}
