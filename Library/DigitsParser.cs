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

            var lls = new List<List<string>>();
            foreach (string line in lines)
            {
                var ls = new List<string>();
                for (int i = 0; i < length * 3; i += 3)
                {
                    ls.Add(line.Substring(i, 3));
                }
                lls.Add(ls);
            }

            string[] digits = new string[length];
            for (int j = 0; j < lls.Count; j++)
            {
                for (int i = 0; i < length; i++)
                {
                    if (digits[i] == null) digits[i] = "";
                    digits[i] += lls[j][i];
                }
            }

            return digits.Select(digitAsString => new Digit(digitAsString))
                         .ToArray();
        }
        public static int[] GetNearestMatch(string digit)
        {
            throw new NotImplementedException();
        }
    }
}
