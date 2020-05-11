using System;
using System.Collections.Generic;

namespace Intervals_Intersection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Interval[] input1 = new Interval[] { new Interval(1, 3), new Interval(5, 6), new Interval(7, 9) };
            Interval[] input2 = new Interval[] { new Interval(2, 3), new Interval(5, 7) };
            Interval[] result = IntervalsIntersection.merge(input1, input2);
            Console.Write("Intervals Intersection: ");
            foreach(Interval interval in result)
            Console.Write("[" + interval.start + "," + interval.end + "] ");
            Console.WriteLine();

            input1 = new Interval[] { new Interval(1, 3), new Interval(5, 7), new Interval(9, 12) };
            input2 = new Interval[] { new Interval(5, 10) };
            result = IntervalsIntersection.merge(input1, input2);
            Console.Write("Intervals Intersection: ");
            foreach(Interval interval in result)
                Console.Write("[" + interval.start + "," + interval.end + "] ");
        }
    }

    class IntervalsIntersection {

        /* SUCESSFULL! for the first run! */
        public static Interval[] merge(Interval[] arr1, Interval[] arr2) {
            List<Interval> intervalsIntersection = new List<Interval>();
            
            int i = 0, j = 0;
            Interval  interval = null;
            while (i<arr1.Length && j<arr2.Length) {
                int start = Math.Max(arr1[i].start, arr2[j].start);
                int end = Math.Min(arr1[i].end,arr2[j].end);
                if (end >= start) {
                    interval = new Interval(start, end);
                    intervalsIntersection.Add(interval);
                }

                if (arr1[i].end > arr2[j].end) j++;
                else i++;
            }

            return intervalsIntersection.ToArray();
        }
    }

    class Interval {
        internal int start;
        internal int end;

        public Interval(int start, int end) {
            this.start = start;
            this.end = end;
        }
    }
}
