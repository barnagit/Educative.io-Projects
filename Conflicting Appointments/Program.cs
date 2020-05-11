using System;

namespace Conflicting_Appointments
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Interval[] intervals = { new Interval(1, 4), new Interval(2, 5), new Interval(7, 9) };
            bool result = ConflictingAppointments.canAttendAllAppointments(intervals);
            Console.WriteLine("Can attend all appointments: " + result);

            Interval[] intervals1 = { new Interval(6, 7), new Interval(2, 4), new Interval(8, 12) };
            result = ConflictingAppointments.canAttendAllAppointments(intervals1);
            Console.WriteLine("Can attend all appointments: " + result);

            Interval[] intervals2 = { new Interval(4, 5), new Interval(2, 3), new Interval(3, 6) };
            result = ConflictingAppointments.canAttendAllAppointments(intervals2);
            Console.WriteLine("Can attend all appointments: " + result);
        }
    }

    class ConflictingAppointments {

        public static bool canAttendAllAppointments(Interval[] intervals) {
            // TODO: Write your code here
            Array.Sort(intervals, (a,b)=>{return a.start - b.start;});
            for (int i = 0; i < intervals.Length -1; i++) {
                if(intervals[i].end > intervals[i+1].start) return false;
            }
            return true;
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
