using System;

namespace Longest_Subarray_with_Ones_after_Replacement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine(ReplacingOnes.findLength(new int[] {0, 1, 1, 0, 0, 0, 1, 1, 0, 1, 1},2));
            Console.WriteLine(ReplacingOnes.findLength(new int[] {0, 1, 0, 0, 1, 1, 0, 1, 1, 0, 0, 1, 1},3));
        }
    }

    class ReplacingOnes {
        public static int findLength(int[] arr, int k) {
            int max = 0, windowStart = 0, windowEnd = 0;
            int countZero = 0;
            for (;windowEnd < arr.Length;) {
                while(windowEnd<arr.Length && (countZero < k || (countZero == k && arr[windowEnd] == 1))) {
                    if (arr[windowEnd] == 0) countZero++;
                    windowEnd++;
                }
                max = Math.Max(max,windowEnd-windowStart);
                if (arr[windowStart]==0) countZero--;
                windowStart++;
            }
            return max;
        }
    }
}
