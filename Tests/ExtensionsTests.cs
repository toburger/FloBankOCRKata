using System.Linq;
using Xunit;
using Xunit.Extensions;
using Kata_OCR.Library;

namespace Kata_OCR.Tests
{
    public class ExtensionsTests
    {
        [Theory]
        [InlineData(0, new int[] { })]
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

        [Fact]
        public void TestSelectiWithSeed()
        {
            var input = new[] { "a", "b", "c", "d" };
            int seed = 8;
            int counter = 8;
            var result = input.Selecti(seed, (i, s) =>
            {
                Assert.Equal(counter++, i);
                return i;
            }).ToArray();
            Assert.Equal(new[] { 8, 9, 10, 11 }, result);

            var result2 = input.Selecti((i, s) => s);
            Assert.Equal(new[] { "a", "b", "c", "d" }, result2);
        }

        [Fact]
        public void TestIter()
        {
            var input = new[] { "a", "b", "c", "d" };
            int counter = 0;
            input.Iter(_ => counter++);
            Assert.Equal(4, counter);
        }

        [Fact]
        public void TestIteriWithSeed()
        {
            var input = new[] { "a", "b", "c", "d" };
            int counter = 0;
            input.Iteri(9, (i, _) => counter += i);
            Assert.Equal(42, counter);
        }

        [Theory]
        [InlineData("a\nb\nc", false, new[] { "a", "b", "c"})]
        [InlineData("a\r\nb\r\nc", false, new[] { "a", "b", "c" })]
        [InlineData("a\n\nc", false, new[] { "a", "", "c" })]
        [InlineData("a\n\nc", true, new[] { "a", "c" })]
        [InlineData("a\n\nc\n", false, new[] { "a", "", "c" })]
        [InlineData("a\n\nc\n", true, new[] { "a", "c" })]
        public void TestStringGetLines(string input, bool ignoreEmptyLines, string[] expected)
        {
            var result = input.GetLines(ignoreEmptyLines);
            Assert.Equal(expected, result);
        }
    }
}
