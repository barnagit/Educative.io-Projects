using System;
using System.Linq;
using Barna.Lib;
using System.Collections.Generic;

namespace Maximize_Capital
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int result = MaximizeCapital.findMaximumCapital(new int[] { 0, 1, 2 }, new int[] { 1, 2, 3 }, 2, 1);
            Console.WriteLine("Maximum capital: " + result);
            result = MaximizeCapital.findMaximumCapital(new int[] { 0, 1, 2, 3 }, new int[] { 1, 2, 3, 5 }, 3, 0);
            Console.WriteLine("Maximum capital: " + result);
        }
    }

    class MaximizeCapital {
        public static int findMaximumCapital(int[] capital, int[] profits, int numberOfProjects, int initialCapital) {
            // TODO: Write your code here
            int myCapital = initialCapital;
            Heap<Project> profitHeap;
            Heap<Project> capitalHeap = new Heap<Project>(new CapitalComparer());
            for (int i = 0; i < capital.Length; i++) {
                Project p = new Project(){Profit = profits[i], Capital = capital[i]};
                capitalHeap.Add(p);
            }
            
            for (int i = 0; i < numberOfProjects; i++) {
                profitHeap = new Heap<Project>(new ProfitComparer());

                while (capitalHeap.Count > 0 && capitalHeap[0].Capital <= myCapital) {
                    Project p = capitalHeap[0];
                    capitalHeap.Remove();
                    profitHeap.Add(p);
                }

                myCapital += profitHeap[0].Profit;
            }


            // Solution assuming capital and profits arrays are unordered and can contain duplications
/*             int[] projectAlreadyDone = new int[capital.Length];
            for (int i = 0; i < projectAlreadyDone.Length; i++) projectAlreadyDone[i]=-1;
            for (int i = 0; i < numberOfProjects; i++) {
                int maxProfitIndex = -1;
                for (int j = 0; j < profits.Length; j++) {
                    if (capital[j]<=myCapital
                        && ( maxProfitIndex ==-1 || profits[maxProfitIndex]<profits[j])
                        && !projectAlreadyDone.Contains(j)
                        ) {
                        maxProfitIndex = j;
                    }
                }
                if (maxProfitIndex != -1) myCapital += profits[maxProfitIndex];
            } */

            return myCapital;
        }
    }

    public class CapitalComparer:IComparer<Project> {
        public int Compare(Project a, Project b) {
            return b.Capital - a.Capital;
        }
    }
    public class ProfitComparer:IComparer<Project> {
        public int Compare(Project a, Project b) {
            return a.Profit - b.Profit;
        }
    }

    public class Project {
        public int Capital {get;set;}
        public int Profit {get;set;}
    }
}