using Xunit;
using Xunit.Extensions;

namespace Kata_OCR.Tests
{
    public class ChecksumTests
    {
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
