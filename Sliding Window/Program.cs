using System;
using System.Collections.Generic;

namespace Sliding_Window
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(LongestSubstringKDistinct.findLength("araaci",2));
            Console.WriteLine(LongestSubstringKDistinct.findLength("araaci",1));
            Console.WriteLine(LongestSubstringKDistinct.findLength("cbbebi",3));
            
        }
    }

    class LongestSubstringKDistinct {
        public static int findLength(String str, int k) {
            // TODO: Write your code here

            int windowStart = 0, windowEnd = 0;
            int max = 0;
            HashSet<char> CharsInWindow = new HashSet<char>();

            for (; windowEnd < str.Length; ){
                while (windowEnd < str.Length && CharsInWindow.Count <= k){
                    CharsInWindow.Add(str[windowEnd++]);
                }
                max = Math.Max(windowEnd-1-windowStart, max);
                CharsInWindow.Remove(str[windowStart++]);
                for (int i = windowStart; i < windowEnd; i++) CharsInWindow.Add(str[i]);
            }

            return max;
        }
    }
}
