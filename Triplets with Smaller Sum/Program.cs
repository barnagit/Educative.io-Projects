using System;

namespace Triplets_with_Smaller_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(TripletWithSmallerSum.searchTriplets(new int[]{-1, 0, 2, 3},3));
            Console.WriteLine(TripletWithSmallerSum.searchTriplets(new int[]{-1, 4, 2, 1, 3},5));
        }
    }

    class TripletWithSmallerSum {        
        public static int searchTriplets(int[] arr, int target) {
            int count = 0;
            Array.Sort(arr);
            int left, right;

            for (int i = 0; i < arr.Length -2; i ++) {
                left = i+1;
                right = arr.Length-1;

                while (left < right) {
                    int sum = arr[i]+arr[left]+arr[right];
                    if (sum < target) {
                        count += right-left; // all fits, right?
                        left++; 
                    }
                    else right--;
                }
            }
            return count;
        }
    }
}
