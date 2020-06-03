using System;
using System.Collections.Generic;
using System.Text;

namespace Unique_Generalized_Abbreviations
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            List<String> result = GeneralizedAbbreviation.generateGeneralizedAbbreviation("BAT");
           Console.WriteLine("Generalized abbreviation are: " + result);

            result = GeneralizedAbbreviation.generateGeneralizedAbbreviation("code");
           Console.WriteLine("Generalized abbreviation are: " + result);
        }
    }

    class GeneralizedAbbreviation {

        public static List<String> generateGeneralizedAbbreviation(String word) {
            List<String> result = new List<String>();
            // TODO: Write your code here

            List<char[]> words = new List<char[]>();
            words.Add(word.ToCharArray());
            for (int i = 0; i < word.Length; i++) {
                int m = words.Count;
                for (int j = 0; j < m; j++) {
                    char[] w = (char[])words[j].Clone();
                    w[i] = '1';
                    words.Add(w);
                }
            }
            
            foreach (char[] w in words) {
                StringBuilder sb = new StringBuilder();
                int c = 0;
                for (int i = 0; i < w.Length; i++) {
                    if (Char.IsLetter(w[i])) {
                        if (c > 0) sb.Append(c.ToString());
                        c = 0;
                        sb.Append(w[i]);
                    } else c++;
                }
                if (c>0) sb.Append(c.ToString());
                result.Add(sb.ToString());
            }

            return result;
        }
    }
}
