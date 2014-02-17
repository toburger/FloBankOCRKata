using Kata_OCR.Library;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

            var accountNumber = new AccountNumber(accountNumberSample);

            Assert.Equal("457508000", accountNumber.ToString());
        }

        [Fact]
        public void TestAccountNumbersFromSampleFile()
        {
            var accountNumbers = ReadSampleFile("sample.txt").ToArray();

            Assert.Equal(56, accountNumbers.Length);
            Assert.Equal("457508000", accountNumbers[0].ToString());
            Assert.Equal("012345678 ERR", accountNumbers[5].ToString());
        }

        private static IEnumerable<AccountNumber> ReadSampleFile(string file)
        {
            string[] lines = File.ReadAllLines(file);
            for (int i = 0; i < lines.Length; i += 4)
            {
                var accountNumber = string.Join("\n", new[] { lines[i], lines[i + 1], lines[i + 2] });
                yield return new AccountNumber(accountNumber);
            }
        }
    }
}
