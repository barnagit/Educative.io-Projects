using System;
using System.Collections.Generic;
using System.Linq;

namespace Balanced_Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            List<String> result = GenerateParentheses.generateValidParentheses(2);
            Console.WriteLine("All combinations of balanced parentheses are: " + result);

            result = GenerateParentheses.generateValidParentheses(3);
            Console.WriteLine("All combinations of balanced parentheses are: " + result);
        }
    }

    class GenerateParentheses {

        class ParenthesesString {
            internal int OpenCount {get;set;}
            internal int CloseCount {get;set;}
            internal string PartialString {get;set;}
        }

        public static List<String> generateValidParentheses(int num) {
            List<String> result = new List<String>();
            // TODO: Write your code here
            Queue<ParenthesesString> queue = new Queue<ParenthesesString>();
            queue.Enqueue(new ParenthesesString(){OpenCount=0, CloseCount=0, PartialString=""});
            while (queue.Count > 0) {
                int m = queue.Count;
                for (int j = 0; j <m; j++) {
                    ParenthesesString ps = queue.Dequeue();
                    if (ps.OpenCount == num && ps.CloseCount == num) {
                        result.Add(ps.PartialString);
                    }
                    else {
                        ParenthesesString rs = new ParenthesesString() {
                            OpenCount = ps.OpenCount,
                            CloseCount = ps.CloseCount,
                            PartialString = ps.PartialString
                        };
                        if (ps.OpenCount < num) {
                            ps.OpenCount += 1;
                            ps.PartialString += '(';
                            queue.Enqueue(ps);
                        }
                        if (rs.CloseCount < rs.OpenCount) {
                            rs.CloseCount += 1;
                            rs.PartialString += ')';
                            queue.Enqueue(rs);
                        }
                    }
                }
            }

            /*
            ** My original solution by noting that counting is time consuming task
            result.Add(String.Empty);
            for (int i = 0; i < num*2; i ++) {
                int m = result.Count;
                for (int j = 0; j < m; j++) {
                    string l = result[j] + "(";
                    string r = result[j] + ")";
                    bool modifiedInPlace = false;
                    if (l.Count(c=>{return c=='(';}) <= num) {
                        result[j] = l;
                        modifiedInPlace = true;
                    }
                    if (r.Count(c=>{return c == ')';}) <= r.Length/2) {
                        if (modifiedInPlace) result.Add(r);
                        else result[j] = r;
                    }
                }
            }
            */

            return result;
        }
    }
}
