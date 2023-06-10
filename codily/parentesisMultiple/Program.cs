using System;
using System.Collections;

namespace parentesisMultiple
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = new Solution().solution("([)()]");
            Console.WriteLine($"{result}");
        }
    }

    class Solution
    {
        public int solution(string s)
        {
            Stack stack = new Stack();

            if(s.Length % 2 != 0) return 0; //all odd numbered strings can't be properly nested

            for (int i = 0; i < s.Length; ++i)
            {
                string character = s.Substring(i, 1);

                switch (character)
                {
                    case ("]"):
                        if (stack.Count < 1 || stack.Pop().ToString() != "[")
                            return 0;
                        break;
                    case (")"):
                        if (stack.Count < 1 || stack.Pop().ToString() != "(")
                            return 0;
                        break;
                    case ("}"):
                        if (stack.Count < 1 || stack.Pop().ToString() != "{")
                            return 0;
                        break;

                    default:
                        stack.Push(character);
                        break;
                }
            }

            // after the for above, for properly nested strings, stack count is 0
            if (stack.Count != 0)
                return 0;

            // else is valid            
            return 1;
        }
    }
}
