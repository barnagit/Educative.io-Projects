using System;
using Barna.Lib;

namespace Find_the_Median_of_a_Number_Stream
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            MedianOfAStream medianOfAStream = new MedianOfAStream();
            medianOfAStream.insertNum(3);
            medianOfAStream.insertNum(1);
            Console.WriteLine("The median is: " + medianOfAStream.findMedian());
            medianOfAStream.insertNum(5);
            Console.WriteLine("The median is: " + medianOfAStream.findMedian());
            medianOfAStream.insertNum(4);
            Console.WriteLine("The median is: " + medianOfAStream.findMedian());
        }
    }

    class MedianOfAStream {
        Heap<int> MinHeap = new Heap<int>(new MinHeapComparer());
        Heap<int> MaxHeap = new Heap<int>(new MaxHeapComparer());
        int? Median;
        public void insertNum(int num) {
            // TODO: Write your code here
            if (Median == null)  {
                if (MinHeap.Count > 0 && num > MinHeap[0]) {
                    Median = MinHeap[0];
                    MinHeap.Remove();
                    MinHeap.Add(num);
                }
                else if (MaxHeap.Count > 0 && num <= MaxHeap[0]) {
                    Median = MaxHeap[0];
                    MaxHeap.Remove();
                    MaxHeap.Add(num);
                }
                else {
                    Median = num;
                }
            }
            else {
                if (num > Median) {
                    MaxHeap.Add(Median.Value);
                    MinHeap.Add(num);
                    Median = null;
                }
                else if (num <= Median) {
                    MaxHeap.Add(num);
                    MinHeap.Add(Median.Value);
                    Median = null;
                }
            }
        }

        public double findMedian() {
            if (Median == null) return (MaxHeap[0] + MinHeap[0]) / 2.0;
            else return Median.Value;
        }
    }
}
