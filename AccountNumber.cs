using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata_OCR
{
    class AccountNumber
    {
        private readonly Digit[] orgData = new Digit[9];
        private readonly int length;

        private Boolean isValidChecksum = false;

        private Boolean isreadable = true;

        private int number;

        private List<string> possibleAccountNumbers;

        public string[] possibleReplacer = new string[6] {
            " _ ",
            " _|",
            "|_ ",
            "|_|",
            "| |",
            "  |"
        };

        [Obsolete("Use other constructor")]
        public AccountNumber()
        { }

        public AccountNumber(string accountNumber, int length = 9)
        {
            if (accountNumber == null)
                throw new ArgumentNullException("accountNumber");

            this.length = length;
            var digits = DigitsParser.ParseDigits(accountNumber, length);
            for (int i = 0; i < digits.Length; i++)
            {
                orgData[i] = digits[i];
            }
        }

        /*
         * Return combined digits in account number
         * */
        private int GetNumber()
        {
            int number = PrepareNumber(this.orgData);
            //Check();
            return number;
        }

        private int PrepareNumber(IEnumerable<Digit> digits)
        {
            int acc = 0;
            var reversedDigits = digits.Reverse().ToArray();
            for (int i = 0; i < reversedDigits.Length; i++)
            {
                int number;
                var d = reversedDigits[i];
                if (d.TryGetNumber(out number))
                    acc += ((int)Math.Pow(10, i)) * number;
            }
            return acc;
        }

        public Boolean IsReadable
        {
            get { return this.isreadable; }
        }

        public void AddDigit(int position, Digit digit)
        {
            this.orgData[position] = digit;
        }

        private void Check()
        {
            foreach (Digit digit in this.orgData)
            {
                int number;
                this.isreadable = digit.TryGetNumber(out number);
            }
            this.CheckIsValidChecksum(this.number.ToString());
        }

        private void CheckIsValidChecksum(string accountNumber)
        {
            string numberAsString = accountNumber;
            int[] numberArray = numberAsString.ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToArray();

            int checksumAdd = 0;
            int tempCounter = numberArray.Length;
            for (int i = 0; i < numberArray.Length; i++)
            {
                if (i == 0)
                {
                    checksumAdd = numberArray[i];
                }
                else
                {
                    checksumAdd = checksumAdd * (numberArray[i] + tempCounter);
                    tempCounter--;
                }
            }

            //Check modulo %11 
            if ((checksumAdd % 11) == 0)
            {
                this.isValidChecksum = true;
            }
        }

        public Boolean IsValidChecksum
        {
            get { return this.isValidChecksum; }
        }

        public override string ToString()
        {
            return GetNumber().ToString("d" + length);
        }
    }
}
