using System;
using System.Collections.Generic;

namespace Find_all_Missing_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(AllMissingNumbers.findNumbers(new int[]{2, 3, 1, 8, 2, 3, 5, 1}));
            Console.WriteLine(AllMissingNumbers.findNumbers(new int[]{2, 4, 1, 2}));
            Console.WriteLine(AllMissingNumbers.findNumbers(new int[]{2, 3, 2, 1}));
        }
    }


    class AllMissingNumbers {

        public static List<int> findNumbers(int[] nums) {
            List<int> missingNumbers = new List<int>();
            // TODO: Write your code here
            int i = 0;
            while (i < nums.Length) {
                if (nums[i] != i+1 && nums[nums[i]-1] != nums[i]) {
                    int tmp = nums[i];
                    nums[i] = nums[nums[i]-1];
                    nums[tmp-1] = tmp; //ááá%
                }
                else i++;
            }
            for(i = 0; i < nums.Length; i++) if(nums[i] != i+1) missingNumbers.Add(i+1);
            return missingNumbers;
        }
    }
}
