using System;

namespace Find_the_Duplicate_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //  ‘n+1’ numbers taken from the range 1 to ‘n’
            Console.WriteLine(FindDuplicate.findNumber(new int[]{1, 4, 4, 3, 2}));
            Console.WriteLine(FindDuplicate.findNumber(new int[]{2, 1, 3, 3, 5, 4}));
            Console.WriteLine(FindDuplicate.findNumber(new int[]{2, 4, 1, 4, 4}));
            Console.WriteLine(FindDuplicate.findNumber(new int[]{3,2, 1, 3, 3, 5, 4,6,7,9}));
        }
    }

    class FindDuplicate {

        public static int findNumber(int[] nums) {
            // TODO: Write your code here
            int i = 0;
            while (i < nums.Length) {
                if (nums[i] != i+1 && nums[i] != nums[nums[i]-1]) {
                    int tmp = nums[nums[i]-1];
                    nums[nums[i]-1] = nums[i];
                    nums[i] = tmp;
                } else i++;
            }
            //for (i = 0; i < nums.Length; i++) if (nums[i]!=i+1) return nums[i];
            return nums[nums.Length-1]; //  ‘n+1’ numbers taken from the range 1 to ‘n’ -> so last place has (one of) the duplicates
        }
    }

}
