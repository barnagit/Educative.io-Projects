using System;

namespace Cyclic_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            CyclicSort.sort(new int[]{3, 1, 5, 4, 2});
            CyclicSort.sort(new int[]{2, 6, 4, 3, 1, 5});
            CyclicSort.sort(new int[]{1, 5, 6, 4, 3, 2});
        }
    }

    class CyclicSort {

        public static void sort(int[] nums) {
            // TODO: Write your code here    
            int tmp, i = 0;
            while (i<nums.Length) {
                if (nums[i]!=i+1) {
                    tmp = nums[nums[i]-1];
                    nums[nums[i]-1] = nums[i];
                    nums[i] = tmp;
                }
                else i++;
            }
        }
    }

}
