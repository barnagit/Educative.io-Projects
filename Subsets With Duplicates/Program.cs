using System;
using System.Collections.Generic;

namespace Subsets_With_Duplicates
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            List<List<int>> result = SubsetWithDuplicates.findSubsets(new int[] { 1, 3, 3 });
            Console.WriteLine("Here is the list of subsets: " + result);

            result = SubsetWithDuplicates.findSubsets(new int[] { 1, 5, 3, 3 });
            Console.WriteLine("Here is the list of subsets: " + result);
        }
    }
    class SubsetWithDuplicates {

        public static List<List<int>> findSubsets(int[] nums) {
            List<List<int>> subsets = new List<List<int>>();
            // TODO: Write your code here
            Array.Sort(nums);
            subsets.Add(new List<int>());
            int? previous = null;
            List<List<int>> setsToAppendWith = null;
            for (int i = 0; i < nums.Length; i++) {
                List<List<int>> setsToGoThrough;
                if (previous == nums[i]) {
                    setsToGoThrough = setsToAppendWith;
                }
                else setsToGoThrough = subsets;
                previous = nums[i];
                setsToAppendWith = new List<List<int>>();
                foreach (List<int> existingSet in setsToGoThrough) {
                    List<int> newSet = new List<int>(existingSet);
                    newSet.Add(nums[i]);
                    setsToAppendWith.Add(newSet);
                }
                subsets.AddRange(setsToAppendWith);
            }

            return subsets;
        }
    }
}
