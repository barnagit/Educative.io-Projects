using System;
using System.Collections.Generic;
using Barna.Lib;

namespace Sliding_Window_Median
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            SlidingWindowMedian slidingWindowMedian = new SlidingWindowMedian();
            double[] result = slidingWindowMedian.findSlidingWindowMedian(new int[] { 1, 2, -1, 3, 5 }, 2);
            Console.Write("Sliding window medians are: ");
            foreach (double num in result)
                Console.Write(num + " ");
            Console.WriteLine();

            slidingWindowMedian = new SlidingWindowMedian();
            result = slidingWindowMedian.findSlidingWindowMedian(new int[] { 1, 2, -1, 3, 5 }, 3);
            Console.Write("Sliding window medians are: ");
            foreach (double num in result)
                Console.Write(num + " ");
        }
    }

    class SlidingWindowMedian {
        public double[] findSlidingWindowMedian(int[] nums, int k) {
            double[] result = new double[nums.Length - k + 1];
            // TODO: Write your code here
            FindMedian fm = new FindMedian(nums[0]);
            int pointer = 0;
            int i;
            for (i = pointer + 1; i < pointer+k; i++ )
                fm.Add(nums[i]);
            result[pointer] = fm.GetMedian();
            while (pointer < nums.Length-k) {
                fm.Remove(nums[pointer]);
                fm.Add(nums[pointer+k]);
                pointer++;
                result[pointer] = fm.GetMedian();
            }


            return result;
        }
    }

    class FindMedian {
        public Heap<int> MinHeap {get;private set;}
        public Heap<int> MaxHeap {get;private set;}
        private int? Median;
        public double GetMedian(){
            if (Median == null) {
                return (MinHeap[0]+MaxHeap[0])/2.0;
            }
            else return Median.Value;
        }

        public FindMedian(int first) {
            MinHeap = new Heap<int>(new MaxHeapComparer());
            MaxHeap = new Heap<int>(new MinHeapComparer());
            Median = first;
        }

        public void Add(int num) {
            if (Median == null) {
                if (num < MinHeap[0]) {
                    Median = MinHeap[0];
                    MinHeap.Remove();
                    MinHeap.Add(num);
                }
                else if (num > MaxHeap[0]) {
                    Median = MaxHeap[0];
                    MaxHeap.Remove();
                    MaxHeap.Add(num);
                }
                else {
                    Median = num;
                }
            } else {
                if (num < Median) {
                    MaxHeap.Add(Median.Value);
                    MinHeap.Add(num);
                }
                else {
                    MaxHeap.Add(num);
                    MinHeap.Add(Median.Value);
                }
                Median = null;
            }
        }

        public void Remove(int num) {
            if (Median == null) {
                if(num >= MaxHeap[0]) {
                    Median = MinHeap[0];
                    MinHeap.Remove();
                    MaxHeap.Remove(num);
                }
                else {
                    Median = MaxHeap[0];
                    MaxHeap.Remove();
                    MinHeap.Remove(num);
                }
            }
            else {
                if (num == Median) Median = null;
                else if (num >= MaxHeap[0]) {
                    MaxHeap.Remove(num);
                    MaxHeap.Add(Median.Value);
                }
                else {
                    MinHeap.Remove(num);
                    MinHeap.Add(Median.Value);
                }
                Median = null;
            }
        }
    }
}
