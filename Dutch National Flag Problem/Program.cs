using System;

namespace Dutch_National_Flag_Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DutchFlag.sort(new int[]{1, 0, 2, 1, 0});
            DutchFlag.sort(new int[]{2, 2, 0, 1, 2, 0});
            DutchFlag.sort(new int[]{1, 0, 0, 1, 1});
        }
    }

    class DutchFlag {

        public static void sort(int[] arr) {
            bringNumForth(arr, 1,bringNumForth(arr, 0,0));
        }

        static int bringNumForth(int[] arr, int num, int from) {
            int left = from;
            int right = from;
            int m = 0;

            while (left < arr.Length && arr[left] == num) left++;
            right = left;

            while (right < arr.Length) {
                if (arr[right] != num) right ++;
                else {
                    m=arr[left];
                    arr[left] = arr[right];
                    arr[right] = m;
                    left ++;
                }
            }
            return left;
        }
    }
}