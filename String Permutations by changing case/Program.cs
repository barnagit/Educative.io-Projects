using System;
using System.Collections.Generic;

namespace String_Permutations_by_changing_case
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            List<String> result = LetterCaseStringPermutation.findLetterCaseStringPermutations("ad52");
            Console.WriteLine(" String permutations are: " + result);

            result = LetterCaseStringPermutation.findLetterCaseStringPermutations("ab7c");
            Console.WriteLine(" String permutations are: " + result);
        }
    }

    class LetterCaseStringPermutation {

        public static List<String> findLetterCaseStringPermutations(String str) {
            List<String> permutations = new List<String>();
            // TODO: Write your code here
            RecursiveStep(permutations,str, 0);
            return permutations;
        }

        private static void RecursiveStep(List<string> permutations, string element, int index) {
            
            if (index == element.Length) {
                permutations.Add(element);

            }
            else if (Char.IsLetter(element[index])){

                char[] myString = element.ToCharArray();

                myString[index] = Char.ToLower(element[index]);
                RecursiveStep(permutations, new String(myString), index +1);

                myString[index] = Char.ToUpper(element[index]);
                RecursiveStep(permutations, new String(myString), index +1);
            } else {
                RecursiveStep(permutations, element, index +1);
            }
        }
    }
}
