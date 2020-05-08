using System;
using System.Collections.Generic;

namespace Subarrays_with_Product_Less_than_a_Target
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(SubarrayProductLessThanK.findSubarrays(new int[]{2, 5, 3, 10},30));
            Console.WriteLine(SubarrayProductLessThanK.findSubarrays(new int[]{8, 2, 6, 5},50));
        }
    }

    class SubarrayProductLessThanK {

        public static List<List<int>> findSubarrays(int[] arr, int target) {
            List<List<int>> subarrays = new List<List<int>>();
            
            int left = 0;
            int right = 0;

            while (left < arr.Length) {

                int mul = 1;
                List<int> f = new List<int>();
                right = left;
                while (right < arr.Length && mul < target) {
                    mul *= arr[right];
                    f.Add(arr[right]);
                    if (mul < target) {
                        List<int> l = new List<int>(f);
                        subarrays.Add(l);
                    }
                    right++;
                }

                left++;
            }
            
            return subarrays;
        }
    }
}
