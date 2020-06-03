using System;
using System.Collections.Generic;

namespace Subsets
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            List<List<int>> result = Subsets.findSubsets(new int[] { 1, 3 });
            Console.WriteLine("Here is the list of subsets: " + result);

            result = Subsets.findSubsets(new int[] { 1, 5, 3 });
            Console.WriteLine("Here is the list of subsets: " + result);
        }
    }

    class Subsets {
        public static List<List<int>> findSubsets(int[] nums) {
            List<List<int>> subsets = new List<List<int>>();
            // TODO: Write your code here

            subsets.Add(new List<int>());

            for (int i = 0; i < nums.Length; i++) {
                int n = subsets.Count;
                for (int j = 0; j < n; j++) {
                    List<int> set = new List<int>(subsets[j]);
                    set.Add(nums[i]);
                    subsets.Add(set);
                }
            }


            return subsets;
        }

        static int Combination(int n, int k) {
            return Factorial(n)/Factorial(k)/Factorial(n-k);
        }

        static int Factorial(int n) {
            int r = 1;
            for (int i = 2; i <= n; i++) {
                r *= i;
            }
            return r;
        }
    }
}
