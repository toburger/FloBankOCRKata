using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata_OCR.Library
{
    static class DigitsParser
    {
        public static IEnumerable<Digit> ParseDigits(string accountNumber, int length = 9, int digitSize = 3)
        {
            return from digitAsString in GetDigitLines(accountNumber, length, digitSize)
                   select new Digit(digitAsString);
        }

        private static IEnumerable<string> GetDigitLines(string accountNumber, int length, int digitSize)
        {
            var lines = accountNumber.GetLines(true);
            return from j in Enumerable.Range(0, length)
                   let lls = from line in lines
                             select from i in Enumerable.Range(0, length)
                                    select line.Substring(i * digitSize, digitSize)
                   let lla = lls.ToArray2D()
                   select string.Join(string.Empty, from i in Enumerable.Range(0, digitSize)
                                                    select lla[i][j]);
        }

        public static IEnumerable<int> GetNearestMatch(string digit)
        {
            return from kvp in DigitsTable.Instance
                   where GetMatchCountOf(kvp.Key, digit, 8)
                   select kvp.Value;
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

            return s1.Zip(s2, (c1, c2) => c1 == c2);
        }
    }
}
