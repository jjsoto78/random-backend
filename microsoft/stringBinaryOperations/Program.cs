using System;
using System.Collections.Generic;


// count operations to reduce a binary representation of a number to 0
namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
           int result= new Solution().solution("100");
           Console.WriteLine(result);
        }
    }

    class Solution {
    public int solution(string S) {

        int operations = 0;
        string ss = S;

        while(ss != string.Empty)
        {
            string ending = ss.Substring(ss.Length-1,1);
            // if v is odd number
            if(ending == "1") {
                ss = ss.Remove(ss.Length-1); // equals number -1
            }
            else
            {
                ss = ss.Remove(0,1); // equals number / 2
            }

            Console.WriteLine(ss);
            operations++;
        }

        return operations;

    }
}
}
