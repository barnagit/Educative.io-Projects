using System;
using System.Collections.Generic;

namespace Happy_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(HappyNumber.find(23));
            Console.WriteLine(HappyNumber.find(12));
        }
    }

    class HappyNumber {

        public static bool find(int num) {

            /* instead of HashSet this can be solved with two pointers */
/*             HashSet<int> set = new HashSet<int>();
            while (!set.Contains(num)) {
                set.Add(num);
                num = SumOfSquareOfDigits(num);
                if (num == 1) return true;
            }
            return false; */

            /* because I missed to realize that the exit criteria is not automatic.
            ** when it reaches 1 for happy numbers, it cycles over it.. */

            int slow = SumOfSquareOfDigits(num);
            int fast = SumOfSquareOfDigits(SumOfSquareOfDigits(num));

            while (slow != fast) {
                slow = SumOfSquareOfDigits(slow);
                fast = SumOfSquareOfDigits(SumOfSquareOfDigits(fast));
            }

            return slow == 1;

        }


        private static int SumOfSquareOfDigits(int num) {

            /* what a stupid solution from me! :) Next time use %! Stupido.. */
/*             int sum = 0;
            int tmp = num;
            while (num >= 1) {
                tmp = num;
                num /= 10;
                sum += (tmp-num*10)*(tmp-num*10);
            }
            return sum; */
            int sum = 0;
            int digit = 0;
            while (num >= 1) {
                digit = num % 10;
                sum += digit*digit;
                num /= 10;
            }

            return sum;
        }
    }
}
