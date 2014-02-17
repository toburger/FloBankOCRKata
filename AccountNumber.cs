using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata_OCR
{
    class AccountNumber
    {
        private Digit[] orgData = new Digit[9];

        private Boolean isValidChecksum = false;

        private Boolean isreadable = true;

        private string number;

        private List<string> possibleAccountNumbers;

        public string[] possibleReplacer = new string[6] {
            " _ ",
            " _|",
            "|_ ",
            "|_|",
            "| |",
            "  |"
        };
        
        /*
         * Return combined digits in account number
         * */
        public string GetNumber()
        {
                PrepareNumber();
                Check();
                return this.number;
        }

        private void PrepareNumber()
        {
            foreach (Digit digit in this.orgData)
            {
                this.number += digit.ToString();
            }
        }

        public Boolean IsReadable
        {
            get
            {
                return this.isreadable;
            }
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
            this.CheckIsValidChecksum(this.number);
        }

        public void CheckIsValidChecksum(string accountNumber)
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
            get
            {
                return this.isValidChecksum;
            }
        }

        public Digit GetDigitByIndex(int index)
        {
            return this.orgData[index];
        }

        public Digit[] OrgData
        {
            get
            {
                return this.orgData;
            }
        }

        public override string ToString()
        {
            return GetNumber();
        }
    }
}
