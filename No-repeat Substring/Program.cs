using System;
using System.Collections.Generic;

namespace No_repeat_Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(NoRepeatSubstring.findLength("aabccbb")); //3
            Console.WriteLine(NoRepeatSubstring.findLength("abbbb")); //2
            Console.WriteLine(NoRepeatSubstring.findLength("abccde")); //3
        }
    }

    class NoRepeatSubstring {
        public static int findLength(String str) {
            int windowStart=0, windowEnd = 0;
            int max = 0;
            List<char> chars = new List<char>();

            for (;windowEnd < str.Length;) {
                while (windowEnd < str.Length && !chars.Contains(str[windowEnd])) chars.Add(str[windowEnd++]);
                max = Math.Max(max, windowEnd-windowStart);
                chars.Remove(str[windowStart++]);
            }


            return max;
        }
    }

}
