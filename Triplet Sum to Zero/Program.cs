using System;
using System.Collections.Generic;
using System.Linq;

namespace Triplet_Sum_to_Zero
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            TripletSumToZero.searchTriplets(new int[]{-3, 0, 1, 2, -1, 1, -2}); //[-3, 1, 2], [-2, 0, 2], [-2, 1, 1], [-1, 0, 1]
            TripletSumToZero.searchTriplets(new int[]{-5, 2, -1, -2, 3}); // [[-5, 2, 3], [-2, -1, 3]]
        }
    }

    class TripletSumToZero {
        public static List<List<int>> searchTriplets(int[] arr) {
            List<List<int>> triplets = new List<List<int>>();
            /* with sorting + clever storing */
            Array.Sort(arr);
            HashSet<Duplet> set = new HashSet<Duplet>();
            int left, right;
            for (int i = 0; i < arr.Length-2; i++) {
                left = i+1;
                right = arr.Length-1;
                while (left < right) {
                    if (arr[left] + arr[right] > -1*arr[i]) right--;
                    else if (arr[left] + arr[right] < -1*arr[i]) left++;
                    else {
                        set.Add(new Duplet(arr[i],arr[left]));
                        left++;
                    }
                }
            }
            foreach (Duplet d in set) triplets.Add(new List<int>(){d.a, d.b, 0-d.a-d.b});
            
            /* bruteforce */
            
/*             for (int i = 0; i < arr.Length; i++) {
                for (int j = i+1; j<arr.Length; j++) {
                    for (int k = j+1; k<arr.Length; k++) {
                        if (arr[i]+arr[j]+arr[k]==0) {
                            List<int> triplet = new List<int>(){arr[i],arr[j],arr[k]};
                            triplet.Sort();
                            if (!triplets.Any(t => {return t[0]==triplet[0] && t[1]==triplet[1] && t[2]==triplet[2];})) {
                                triplets.Add(triplet);
                            }
                        }
                    }
                }
            }
 */
            return triplets;
        }
    }

    class Duplet {
        public int a {get; private set;}
        public int b {get; private set;}

        public Duplet(int a, int b) {
            this.a = a;
            this.b = b;
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            //
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //
            
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Duplet o = (Duplet)obj;
            
            // TODO: write your implementation of Equals() here
            return o.a == this.a && o.b == this.b;
        }
        
        // override object.GetHashCode
        public override int GetHashCode()
        {
            // TODO: write your implementation of GetHashCode() here
            return a.GetHashCode();
        }

    }
}

