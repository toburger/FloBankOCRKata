using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Kata_OCR.Library;

namespace Kata_OCR.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = @"SampleData\sample.txt";

            var accountNumbers = ReadSampleFile(file);

            foreach (var accountNumber in accountNumbers)
            {
                System.Console.WriteLine(accountNumber);
            }
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
