using Kata_OCR.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Extensions;

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

        [Theory]
        [InlineData("     | _|", new[] { 1 })]
        [InlineData("    _| _|", new[] { 3 })]
        [InlineData("         ", new int[] { })]
        [InlineData(" _  _  _|", new int[] { 3, 5 })]
        public void TestNearestMatch(string input, int[] expected)
        {
            var digit = new Digit(input);
            Assert.Equal("?", digit.ToString());

            int[] numbers = DigitsParser.GetNearestMatch(input);
            Assert.NotNull(numbers);
            Assert.Equal(expected, numbers);
        }
    }
}