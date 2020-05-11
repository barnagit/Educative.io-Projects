using System;
using System.Collections.Generic;

namespace Insert_Interval
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            IList<Interval> input = new List<Interval>();
            input.Add(new Interval(1, 3));
            input.Add(new Interval(5, 7));
            input.Add(new Interval(8, 12));
            Console.Write("Intervals after inserting the new interval: ");
            foreach (Interval interval in InsertInterval.insert(input, new Interval(4, 6)))
            Console.Write("[" + interval.start + "," + interval.end + "] ");
            Console.WriteLine();

            input = new List<Interval>();
            input.Add(new Interval(1, 3));
            input.Add(new Interval(5, 7));
            input.Add(new Interval(8, 12));
            Console.Write("Intervals after inserting the new interval: ");
            foreach (Interval interval in InsertInterval.insert(input, new Interval(4, 10)))
            Console.Write("[" + interval.start + "," + interval.end + "] ");
            Console.WriteLine();

            input = new List<Interval>();
            input.Add(new Interval(2, 3));
            input.Add(new Interval(5, 7));
            Console.Write("Intervals after inserting the new interval: ");
            foreach (Interval interval in InsertInterval.insert(input, new Interval(1, 4)))
            Console.Write("[" + interval.start + "," + interval.end + "] ");
            Console.WriteLine();
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

    class InsertInterval {
        public static IList<Interval> insert(IList<Interval> intervals, Interval newInterval) {
            IList<Interval> mergedIntervals = new List<Interval>();

            var e = intervals.GetEnumerator();

            while (e.MoveNext()) {
                Interval c = e.Current;
                if (c.end < newInterval.start || c.start > newInterval.end){
                    mergedIntervals.Add(c);
                }
                else {
                    Interval i = new Interval(Math.Min(c.start, newInterval.start), Math.Max(c.end, newInterval.end));
                    bool gotIn = false;
                    while (e.MoveNext()) {
                        c = e.Current;
                        if (c.start > i.end) {
                            gotIn = true;
                            break;
                        }
                        else {
                            i.end = Math.Max(i.end, c.end);
                        }
                    }
                    mergedIntervals.Add(i);
                    if (gotIn) mergedIntervals.Add(c);
                }

            }


            return mergedIntervals;
        }
    }
}
