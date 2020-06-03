using System;
using System.Collections.Generic;

namespace Permutations
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            List<List<int>> result = Permutations.findPermutations(new int[] { 1, 3, 5 });
            Console.WriteLine("Here are all the permutations: " + result);
        }
    }

    class Permutations {

        public static List<List<int>> findPermutations(int[] nums) {
            List<List<int>> result = new List<List<int>>();
            // TODO: Write your code here
            result.Add(new List<int>());
            for (int i = 0; i < nums.Length; i++)
            {
                int max = result.Count;
                for (int j = 0; j < max; j++) {
                    for (int k = 0; k < result[j].Count; k++) {
                        if (result[j].Count == 0) continue;
                        List<int> set = new List<int>(result[j]);
                        set.Insert(k,nums[i]);
                        result.Add(set);
                    }
                    result[j].Add(nums[i]);
                }
            }
            return result;
        }

        private static int Factorial(int v) {
            if (v==2) return 2;
            else return v*Factorial(v-1);
        }
    }
}
