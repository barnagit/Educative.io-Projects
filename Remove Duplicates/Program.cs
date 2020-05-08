using System;

namespace Remove_Duplicates
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(RemoveDuplicates.remove(new int[]{2, 3, 3, 3, 6, 9, 9}));
            Console.WriteLine(RemoveDuplicates.remove(new int[]{2, 2, 2, 11}));
        }
    }
    // OoopS! the task was to redo the array as well! :()
    class RemoveDuplicates {

        public static int remove(int[] arr) {
            int left = 0, right = 0;
            int elemsCount = arr.Length;
            
            while (right < arr.Length) {
                while (right < arr.Length && arr[left] == arr[right]) right++;
                elemsCount -= right-left - 1;
                left = right;
            }

            return elemsCount;
        }
    }
}
