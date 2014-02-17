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

            Assert.Equal("457508000", accountNumber.GetNumber());
        }

        [Fact]
        public void TestAccountNumbersFromSampleFile()
        {
            string[] lines = File.ReadAllLines("sample.txt");
            var ans = new List<string>();
            for (int i = 0; i < lines.Length; i += 4)
            {
                var accountNumber = string.Join("\n", new[] { lines[i], lines[i + 1], lines[i + 2] });
                ans.Add(accountNumber);
            }

            var accountNumbers = ans.Select(an => new AccountNumber(an)).ToArray();

            Assert.Equal(56, accountNumbers.Length);
            Assert.Equal("457508000", accountNumbers[0].GetNumber());
            Assert.Equal("012345678", accountNumbers[5].GetNumber());
        }
    }
}
