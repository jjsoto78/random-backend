using System;

// given a string representing a binary number, write a method to add 1 to it
// return the new string after adding 1

namespace addonebinary
{
    class Program
    {
        static void Main(string[] args)
        {

            var result = new Solution().solution("111");
            Console.WriteLine(result);
        }
    }

    class Solution
    {
        public string solution(string s)
        {
            // adding one to s swaps 1 with 0 until a 0 is found, is like adding in base 10
            // traverse s from left to right doing above
            string result = string.Empty;

            bool foundZero = false;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                // need to keep swaping 1s with 0s until a zero is found
                if (!foundZero)
                {
                    if (s.Substring(i, 1) == "1")
                        result = $"{0}{result}";
                    else
                    {
                        result = $"{1}{result}";
                        foundZero = true;
                    }
                }
                // otherwise just keep building the string
                else{
                     result = $"{s.Substring(i, 1)}{result}";
                }
            }

            // on numbers like 111, there will be no zero to swap
             if (!foundZero)
                result = $"{1}{result}";

            return result;
        }

        private string swapWithZeros(string s){

            string result = string.Empty;
            for (int i = 0; i < s.Length; i++)
            {
                result = $"{result}{0}";
            }

            return result;
        }
    }
}
