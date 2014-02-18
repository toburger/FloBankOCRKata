using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata_OCR.Library
{
    public class AccountNumber
    {
        private readonly Digit[] _digits;
        private readonly int _length;

        public AccountNumber(string accountNumber, int length = 9)
        {
            if (accountNumber == null)
                throw new ArgumentNullException("accountNumber");

            _length = length;
            _digits = new Digit[length];
            DigitsParser.ParseDigits(accountNumber, length)
                        .Iteri((i, d) => _digits[i] = d);
        }

        private bool TryGetNumber(out int number)
        {
            var res =
                _digits
                    .Reverse()
                    .Aggregate(Tuple.Create(0, 0, true), (state, d) =>
                    {
                        int i = state.Item1;
                        int acc = state.Item2;
                        bool isReadable = state.Item3;

                        int n;
                        if (d.TryGetNumber(out n))
                            acc += ((int)Math.Pow(10, i)) * n;
                        else
                            isReadable = false;

                        return Tuple.Create(i + 1, acc, isReadable);
                    });
            number = res.Item2;
            return res.Item3;
        }

        public override string ToString()
        {
            int number;
            if (TryGetNumber(out number))
            {
                string numberString = number.ToString("d" + _length);
                if (Checksum.IsValid(number))
                    return numberString;
                else
                    return numberString + " ERR";
            }
            else
            {
                string numberString = string.Join("", _digits.Select(d => d.ToString()));
                return numberString + " ILL";
            }
        }
    }
}
