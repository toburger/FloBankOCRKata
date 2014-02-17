using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Kata_OCR
{
    class Digit
    {
        private readonly string digitAsString;

        public Digit(string[] subparts)
        {
            if (subparts == null)
                throw new ArgumentNullException("subparts");
            if (subparts.Length != 3)
                throw new ArgumentOutOfRangeException("subparts", "Please provide a valid string array with three items in it.");

            digitAsString = string.Join("", subparts);
        }

        public bool TryGetNumber(out int number)
        {
            return DigitsTable.Instance.TryGetValue(digitAsString, out number);
        }

        public override string ToString()
        {
            int number;
            if (TryGetNumber(out number))
                return number.ToString();
            else
                return "?";
        }
    }
}
