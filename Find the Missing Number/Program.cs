using System;

namespace Find_the_Missing_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(MissingNumber.findMissingNumber(new int[]{4, 0, 3, 1}));
            Console.WriteLine(MissingNumber.findMissingNumber(new int[]{8, 3, 5, 2, 4, 6, 0, 1}));
            Console.WriteLine(MissingNumber.findMissingNumber(new int[]{1, 3, 5, 2, 4, 6, 8, 7}));
        }
    }

    class MissingNumber {
        public static int findMissingNumber(int[] nums) {
            // TODO: Write your code here
            /* let's do it in place */
            int i = 0;
            while (i < nums.Length) {
                if (nums[i] != i && nums[i]<nums.Length) {
                    int tmp = nums[nums[i]];
                    nums[nums[i]] = nums[i];
                    nums[i] = tmp;
                } else i++;
            }

            for (i = 0; i < nums.Length;i++) if (nums[i]!=i) return i;
            return -1;

            /* this is my not in place ordering */
            /* int[] racks = new int[nums.Length+1];
            //for(int i = 0; i < racks.Length; i++) racks[i] = -1;
            for(int i = 0; i < nums.Length; i++) racks[nums[i]] = nums[i];
            for(int i = 0; i < racks.Length; i++) if (racks[i]!=i) return i; // this does not work for 0 but if true for all the missing number is 0
            return 0; */
        }
    }
}
