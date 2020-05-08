using System;

namespace Triplet_Sum_Close_to_Target
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(TripletSumCloseToTarget.searchTriplet(new int[]{-2, 0, 1, 2},2));
            Console.WriteLine(TripletSumCloseToTarget.searchTriplet(new int[]{-3, -1, 1, 2},1));
            Console.WriteLine(TripletSumCloseToTarget.searchTriplet(new int[]{1, 0, 1, 1},100));
        }
    }

    class TripletSumCloseToTarget {

        public static int searchTriplet(int[] arr, int targetSum) {
            // TODO: Write your code here

            int closestValue = Int32.MaxValue;
            int left =0;
            int right = arr.Length-1;
            Array.Sort(arr);
            int diff = Int32.MaxValue;
            int[] triplet = new int[3];

            for (int i = 0; i < arr.Length-2; i ++) {
                left = i +1;
                while (left < right) {
                    diff = targetSum - arr[i]-arr[left]-arr[right];
                    if (Math.Abs(diff) < closestValue) {
                        closestValue = Math.Abs(diff);
                        triplet[0]=arr[i]; triplet[1]=arr[left]; triplet[2]=arr[right];
                        if (diff > 0) left ++;
                        else right --;
                    }
                    else left ++;
                }
            }

            return triplet[0]+triplet[1]+triplet[2];
        }
    }
}
