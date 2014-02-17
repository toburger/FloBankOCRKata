using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Kata_OCR.Tests
{
    public class AccountNumberTests
    {
        [Fact]
        public void TestAccountNumber()
        {
            string accountNumberSample = @"
    _  _  _  _  _  _  _  _ 
|_||_   ||_ | ||_|| || || |
  | _|  | _||_||_||_||_||_|";

            //var accountNumber = new AccountNumber(accountNumberSample); // This should be the goal

            var digits = DigitsParser.ParseDigits(accountNumberSample);
            var accountNumber = new AccountNumber();
            for (int i = 0; i < digits.Length; i++)
            {
                accountNumber.AddDigit(i, digits[i]);
            }

            Assert.Equal("457508000", accountNumber.GetNumber());
        }
    }
}
