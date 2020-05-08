using System;

namespace Remove_all_Instances_of_Key
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(RemoveElement.remove(new int[]{3, 2, 3, 6, 3, 10, 9, 3}, 3));
            Console.WriteLine(RemoveElement.remove(new int[]{2, 11, 2, 2, 1}, 2));
        }
    }

    class RemoveElement {
        public static int remove(int[] arr, int key) {
            int nextElement = 0;
            int pointer = 0;

            for (;pointer < arr.Length; pointer++) {
                if (arr[pointer]!=key) {
                    arr[nextElement] = arr[pointer];
                    nextElement++;
                }
            }

            return nextElement;
        }
    }
}
