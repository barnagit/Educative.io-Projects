using System;

namespace Pair_with_Target_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(PairWithTargetSum.search(new int[] {1, 2, 3, 4, 6},6));
            Console.WriteLine(PairWithTargetSum.search(new int[] {2, 5, 9, 11},11));
        }
    }
    class PairWithTargetSum {

        public static int[] search(int[] arr, int targetSum) {
            int pointerLeft = 0, pointerRight = arr.Length-1;
            while (arr[pointerLeft] + arr[pointerRight] != targetSum) {
                if (arr[pointerLeft] + arr[pointerRight] < targetSum) pointerLeft ++;
                else if (arr[pointerLeft] + arr[pointerRight] > targetSum) pointerRight --;
                
                if (pointerLeft >= pointerRight) return new int[] { -1, -1 };
            }

            return new int[] { pointerLeft, pointerRight };
        }
    }
}
