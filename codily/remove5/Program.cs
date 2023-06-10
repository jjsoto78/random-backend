//https://leetcode.com/discuss/interview-question/398023/Microsoft-Online-Assessment-Questions
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace remove5
{
    class Program
    {
        static void Main(string[] args)
        {
            new Solution().solution(-5859);
            
        }
    }

    class Solution {

        public int solution (int number) {
            
            const string REMOVE_NUMBER = "5";

            string sn = Math.Abs(number).ToString();
            int max = int.MinValue; // negative infinity
            
            for (int i = 0; i < sn.Length; i++)
            {
                string character = sn.Substring(i,1);

                if(character == REMOVE_NUMBER){
                    
                    string ss = ($"{sn}").Remove(i,1);
                    int runnerUp = Int32.Parse(ss); // max runner up
                    if(number < 0) runnerUp*=-1;
                    max = (max < runnerUp) ? runnerUp : max;
                    // Console.WriteLine(ss); 
                }
            }

            return max;
        }
    }
}
