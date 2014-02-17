using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Kata_OCR.Tests
{
    public class DigitsParserTests
    {
        [Fact]
        public void TestDigitsParsing()
        {
            string accountNumberSample = @"
    _  _  _  _  _  _  _  _ 
|_||_   ||_ | ||_|| || || |
  | _|  | _||_||_||_||_||_|";

            //var accountNumber = new AccountNumber(accountNumberSample); // This should be the goal

            int length = 9;

            var digits = DigitsParser.ParseDigits(accountNumberSample, length);
            Assert.Equal(length, digits.Count());

            var ns = 457508000.GetDigits().ToArray();
            Assert.Equal(length, ns.Count());
            for (int i = 0; i < length; i++)
            {
                int number;
                digits[i].TryGetNumber(out number);
                Assert.Equal(ns[i], number);
            }
        }
    }
}