using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata_OCR
{
    class AccountNumber
    {
        private readonly Digit[] digits = new Digit[9];
        private readonly int length;

        public AccountNumber(string accountNumber, int length = 9)
        {
            if (accountNumber == null)
                throw new ArgumentNullException("accountNumber");

            this.length = length;
            var digits = DigitsParser.ParseDigits(accountNumber, length);
            for (int i = 0; i < digits.Length; i++)
            {
                this.digits[i] = digits[i];
            }
        }

        private bool TryGetNumber(out int number)
        {
            var reversedDigits = digits.Reverse().ToArray();

            bool isReadable = true;
            int acc = 0;
            
            for (int i = 0; i < reversedDigits.Length; i++)
            {
                int n;
                var d = reversedDigits[i];
                if (d.TryGetNumber(out n))
                    acc += ((int)Math.Pow(10, i)) * n;
                else
                    isReadable = false;
            }

            number = acc;
            return isReadable;
        }

        public override string ToString()
        {
            int number;
            if (TryGetNumber(out number))
            {
                string numberString = number.ToString("d" + length);
                if (Checksum.IsValid(number))
                    return numberString;
                else
                    return numberString + " ERR";
            }
            else
            {
                string numberString = string.Join("", digits.Select(d => d.ToString()));
                return numberString + " ILL"; //TODO: return the correct result
            }
        }
    }
}
