using System;
using System.Collections.Generic;
using System.Linq;

namespace Fruits_into_Baskets
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(MaxFruitCountOf2Types.findLength(new char[]{'A', 'B', 'C', 'A', 'C'}));
            Console.WriteLine(MaxFruitCountOf2Types.findLength(new char[]{'A', 'B', 'C', 'B', 'B', 'C'}));
        }
    }

    class MaxFruitCountOf2Types {
        public static int findLength(char[] arr) {
            // TODO: Write your code here
            Dictionary<char, int> baskets = new Dictionary<char, int>();
            int max = 0;
            int windowStart = 0, windowEnd = 0;
            for (; windowEnd<arr.Length;) {
                while (windowEnd<arr.Length) {
                    if (baskets.Keys.Count < 2) {
                        baskets.Add(arr[windowEnd++],1);
                    }
                    else if (baskets.ContainsKey(arr[windowEnd])) {
                        baskets[arr[windowEnd++]]++;
                    }
                    else break;
                }
                max = Math.Max(max, baskets.Sum(vals));
                while (baskets.Keys.Count > 1) {
                    if (baskets[arr[windowStart]] > 1) baskets[arr[windowStart++]]--;
                    else baskets.Remove(arr[windowStart++]);
                }
            }
            return max;
        }
        private static Func<KeyValuePair<char, int>, int> vals = Vals;
        private static int Vals(KeyValuePair<char,int> keyValue) {
            return keyValue.Value;
        }
    }
}
