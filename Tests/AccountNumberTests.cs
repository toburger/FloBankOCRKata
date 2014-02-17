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

            var accountNumber = new AccountNumber(accountNumberSample);

            Assert.Equal("457508000", accountNumber.GetNumber());
        }
    }
}
