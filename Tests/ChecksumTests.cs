using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Extensions;

namespace Kata_OCR.Tests
{
    public class ChecksumTests
    {
        [Theory]
        [InlineData(0, new int[0] { })]
        [InlineData(1, new[] { 1 })]
        [InlineData(1234, new[] { 1, 2, 3, 4 })]
        [InlineData(0001234, new[] { 1, 2, 3, 4 })]
        public void TestDigits(int number, int[] expected)
        {
            Assert.Equal(number.GetDigits(), expected);
        }

        [Fact]
        public void TestSelecti()
        {
            var input = new[] { "a", "b", "c", "d" };
            int counter = 0;
            var result = input.Selecti((i, s) =>
                {
                    Assert.Equal(counter++, i);
                    return i;
                }).ToArray();
            Assert.Equal(new[] { 0, 1, 2, 3 }, result);

            var result2 = input.Selecti((i, s) => s);
            Assert.Equal(new[] { "a", "b", "c", "d" }, result2);
        }

        [Theory]
        [InlineData(457508000, true)]
        [InlineData(345882865, true)]
        [InlineData(111111111, false)]
        [InlineData(382913738, false)]
        public void TestValidChecksum(int number, bool isValid)
        {
            bool isValidChecksum = Checksum.IsValid(number);
            Assert.Equal(isValid, isValidChecksum);
        }
    }
}
