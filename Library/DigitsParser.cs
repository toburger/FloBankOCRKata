using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata_OCR.Library
{
    static class DigitsParser
    {
        public static Digit[] ParseDigits(string accountNumber, int length = 9)
        {
            string[] lines = accountNumber.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            return (from digitAsString in
                        from j in Enumerable.Range(0, length)
                        let lls = from line in lines
                                  select from i in Enumerable.Range(0, length)
                                         select line.Substring(i * 3, 3)
                        select lls.ElementAt(0).ElementAt(j) + lls.ElementAt(1).ElementAt(j) + lls.ElementAt(2).ElementAt(j)
                    select new Digit(digitAsString)).ToArray();
        }

        public static int[] GetNearestMatch(string digit)
        {
            return DigitsTable.Instance.Where(kvp => GetMatchCountOf(kvp.Key, digit, 8))
                                       .Select(kvp => kvp.Value)
                                       .ToArray();
        }

        private static bool GetMatchCountOf(string s1, string s2, int matchCount)
        {
            return GetMatches(s1, s2).Where(m => m)
                                     .Count() == matchCount;
        }

        private static IEnumerable<bool> GetMatches(string s1, string s2)
        {
            if (s1.Length != s2.Length)
                throw new ArgumentException("The two strings provided must be of the same size.");
            for (int i = 0; i < s1.Length; i++)
            {
                yield return s1[i] == s2[i];
            }
        }
    }
}
