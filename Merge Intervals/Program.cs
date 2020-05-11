using System;
using System.Collections.Generic;
using System.Collections;

namespace Merge_Intervals
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            List<Interval> input = new List<Interval>();
            input.Add(new Interval(1, 4));
            input.Add(new Interval(2, 5));
            input.Add(new Interval(7, 9));
            Console.WriteLine("Merged intervals: ");
            foreach (Interval interval in MergeIntervals.merge(input))
                Console.Write("[" + interval.start + "," + interval.end + "] ");
            Console.WriteLine();

            input = new List<Interval>();
            input.Add(new Interval(6, 7));
            input.Add(new Interval(2, 4));
            input.Add(new Interval(5, 9));
            Console.Write("Merged intervals: ");
            foreach (Interval interval in MergeIntervals.merge(input))
                Console.Write("[" + interval.start + "," + interval.end + "] ");
            Console.WriteLine();

            input = new List<Interval>();
            input.Add(new Interval(1, 4));
            input.Add(new Interval(2, 6));
            input.Add(new Interval(3, 5));
            Console.Write("Merged intervals: ");
            foreach (Interval interval in MergeIntervals.merge(input))
                Console.Write("[" + interval.start + "," + interval.end + "] ");
            Console.WriteLine();
        }
    }

    class Interval : IComparable<Interval> {
        internal int start;
        internal int end;

        public Interval(int start, int end) {
            this.start = start;
            this.end = end;
        }

        public int CompareTo(Interval o) {
            return this.start - o.start;
        }
    }

    class MergeIntervals { 

        public static ICollection<Interval> merge(ICollection<Interval> intervals) {

            List<Interval> _intervals = (List<Interval>)intervals;
            _intervals.Sort();

            ICollection<Interval> mergedIntervals = new LinkedList<Interval>();
            // TODO: Write your code here
            
            var e = _intervals.GetEnumerator();
            int left = -1, right = -1;
            while (e.MoveNext())
            {
                Interval c = e.Current;
                if (left == -1) {
                    left = c.start;
                    right = c.end;
                } else if (right >= c.start) {
                    if (right < c.end) right = c.end;
                } else {
                    Interval i = new Interval(left, right);
                    mergedIntervals.Add(i);
                    left = c.start;
                    right = c.end;
                }
            }
            mergedIntervals.Add(new Interval(left, right));

            return mergedIntervals;
        }
    }
}