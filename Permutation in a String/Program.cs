using System;

namespace Permutation_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(StringPermutation.findPermutation("oidbcaf","abc")); //true
            Console.WriteLine(StringPermutation.findPermutation("odicf","dc")); //false
            Console.WriteLine(StringPermutation.findPermutation("bcdxabcdy","bcdyabcdx")); //true
            Console.WriteLine(StringPermutation.findPermutation("aaacb","abc"));//true
            Console.WriteLine(StringPermutation.findPermutation("aabaa","bb")); // should be false :()
        }
    }

    /* inperfect solution */
    class StringPermutation {
        public static bool findPermutation(String str, String pattern) {
            int windowStart =0, windowEnd=0;
            
            for(;windowStart <= str.Length-pattern.Length;) {
                while (!pattern.Contains(str[windowStart]) && windowStart < str.Length - pattern.Length) windowStart++;
                windowEnd = windowStart + pattern.Length;
                bool match = true;
                for (int i = 0; i < pattern.Length; i++) {
                    match &= str.Substring(windowStart,windowEnd-windowStart).Contains(pattern[i]);
                }
                if (match) return true;
                windowStart++;
            } 

            return false;
        }
    }
}
