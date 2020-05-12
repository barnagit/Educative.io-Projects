using System;
using System.Collections.Generic;

namespace Find_all_Duplicate_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(FindAllDuplicate.findNumbers(new int[]{3, 4, 4, 5, 5}));
            Console.WriteLine(FindAllDuplicate.findNumbers(new int[]{5, 4, 7, 2, 3, 5, 3}));
            Console.WriteLine(FindAllDuplicate.findNumbers(new int[]{5, 4, 7, 3, 3, 5, 3}));
        }
    }

    class FindAllDuplicate {

        public static List<int> findNumbers(int[] nums) {
            List<int> duplicateNumbers = new List<int>();
            // TODO: Write your code here
            int i = 0;
            while(i < nums.Length) {
                if(nums[i] != i+1){
                    if (nums[i] != nums[nums[i]-1]) {
                        int tmp = nums[nums[i]-1];
                        nums[nums[i]-1] = nums[i];
                        nums[i] = tmp;
                    }
                    else {
                        duplicateNumbers.Add(nums[i++]);
                    }
                }
                else i++;
            }


            return duplicateNumbers;
        }
    }
}
