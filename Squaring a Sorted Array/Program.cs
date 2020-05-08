using System;

namespace Squaring_a_Sorted_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            SortedArraySquares.makeSquares(new int[]{-2, -1, 0, 2, 3});
            SortedArraySquares.makeSquares(new int[]{-3, -1, 0, 1, 2});
            SortedArraySquares.makeSquares(new int[]{0, 1, 2});
        }
    }

    class SortedArraySquares {

        public static int[] makeSquares(int[] arr) {
            int[] squares = new int[arr.Length];
            // TODO: Write your code here
            int left = 0;
            int right = arr.Length -1;
            int squaresPointer = arr.Length-1;
            while (left < right) {
                if (Math.Abs(arr[left]) > Math.Abs(arr[right])) {
                    squares[squaresPointer--] = (int)Math.Pow(arr[left],2);
                    left++;
                }
                else {
                    squares[squaresPointer--] = (int)Math.Pow(arr[right],2);
                    right--;
                }
            }
            return squares;
        }
    }
}
