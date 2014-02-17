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
    public class DigitTests
    {
        [Theory]
        [InlineData(new[] { " _ ", "| |", "|_|" }, 0)]
        [InlineData(new[] { "   ", "  |", "  |" }, 1)]
        [InlineData(new[] { " _ ", " _|", "|_ " }, 2)]
        public void TestValidNumber(string[] input, int expected)
        {
            var digit = new Digit(input);
            int number;
            bool isReadable = digit.TryGetNumber(out number);
            Assert.Equal(true, isReadable);
            Assert.Equal(expected, number);
        }

        [Theory]
        [InlineData(new[] { "   ", "   ", "   " }, 0)]
        [InlineData(new[] { "   ", " _|", "  |" }, 0)]
        public void TestInvalidNumber(string[] input, int expected)
        {
            var digit = new Digit(input);
            int number;
            bool isReadable = digit.TryGetNumber(out number);
            Assert.Equal(false, isReadable);
        }
    }
}
