using Kata_OCR.Library;
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

        [Fact]
        public void TestNearestMatch()
        {
            string illegibleDigitSample = "     | _|";

            var digit = new Digit(illegibleDigitSample);
            Assert.Equal("?", digit.ToString());

            int[] numbers = DigitsParser.GetNearestMatch(illegibleDigitSample);
            Assert.NotNull(numbers);
            Assert.NotEmpty(numbers);
            Assert.Equal(1, numbers.Length);
            Assert.Equal(1, numbers[0]);
        }
    }
}