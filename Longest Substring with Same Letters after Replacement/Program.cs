using System;
using System.Collections.Generic;
using System.Linq;

namespace Longest_Substring_with_Same_Letters_after_Replacement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CharacterReplacement.findLength("aabccbb",2)); //5
            Console.WriteLine(CharacterReplacement.findLength("abbcb",1)); //4
            Console.WriteLine(CharacterReplacement.findLength("abccde",1)); //3
        }
    }

    public static class CharacterReplacement {
        public static int findLength(String str, int k) {
            _k = k;
            // TODO: Write your code here
            int max = 0;
            int windowStart = 0, windowEnd = 0;
            Dictionary<char, int> chars = new Dictionary<char, int>();
            for (;windowEnd < str.Length;) {
                while (windowEnd < str.Length && !chars.IsDictFull(str[windowEnd])) {
                    if (chars.ContainsKey(str[windowEnd])) {
                        chars[str[windowEnd++]]++;
                    }
                    else {
                        chars.Add(str[windowEnd++],1);
                    }
                }

                max = Math.Max(max, windowEnd-windowStart);
                
                if (chars[str[windowStart]] > 1) {
                    chars[str[windowStart++]]--;
                }
                else {
                    chars.Remove(str[windowStart++]);
                }
                
            }

            return max;
        }
        private static int _k;
        private static bool GreatherThanK(KeyValuePair<char,int> kv) {
            return kv.Value >= _k;
        }
        private static char getFirstMaxKey(this Dictionary<char,int> d) {
            char maxKey = d.Keys.FirstOrDefault();
            foreach (char k in d.Keys) {
                if (d[k] > d[maxKey]) maxKey = k;
            }
            return maxKey;
        }
        private static bool IsDictFull(this Dictionary<char,int> chars, char c) {
            if (chars.Count > _k+1) return true;
            else if (chars.Count == _k+1  && !chars.ContainsKey(c)) return true;
            else if (chars.Count == _k+1  && !chars.Any(GreatherThanK)) return false;
            else if (chars.Count == _k+1 && chars.getFirstMaxKey() == c) return false;
            else if (chars.Count < _k+1) return false;
            else return true;
        }
    }

}
