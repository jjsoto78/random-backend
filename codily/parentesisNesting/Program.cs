using System;

namespace parentesisNesting
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = new Solution().solution("))((");
            Console.WriteLine(result == 1 ? "valid" : "invalid" );
        }
    }

    class Solution{
        private int openingCount = 0;
        public int solution(string s) {

            for (int i = 0; i < s.Length; ++i)
            {
                string character =s.Substring(i,1);          
                countBrackets(character);

                if (openingCount < 0)
                    return 0;
            }

            // after calling countBrackets in for loop, openingCount should be 0 on a properly nested string of ()
            if (openingCount != 0)
                return 0;

            // else is valid            
            return 1;
        }

        int countBrackets (string character) {

            if(character == "(") {
                return ++openingCount;
            }

            // else is a closing ')'
            return --openingCount;
        }
    }
}
