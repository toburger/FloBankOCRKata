using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Kata_OCR
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = @"..\..\SampleData\sample.txt";

            System.IO.StreamReader sReader = new System.IO.StreamReader(file);

            string fileLine;
            int lineCounter = 0;
            var combinedNumber = new Dictionary<int, string>();

            int accountNumberLength = 9;
            int count = 1;

            // Should be better implemented, because it is a "global state" variable.
            Dictionary<int, List<string>> digits = null;

            while ((fileLine = sReader.ReadLine()) != null /*&&  count < 7*/ )
            {
                count++;
                if (fileLine.Length > 0)
                {
                    //replace \n\r
                    fileLine = fileLine.Replace(System.Environment.NewLine, string.Empty);
                    if (lineCounter == 0)
                    {
                        digits = new Dictionary<int, List<string>>();
                    }
                    // loop beginns from end to assign correct
                    for (var i = 0; i < accountNumberLength; i++)
                    {
                        //split line into parts
                        string subpart = fileLine.Substring(i * 3, 3);

                        //On first line create digit and ad it to accountnumber
                        if (lineCounter == 0)
                        {
                            digits.Add(i, new List<string>() { subpart });
                        }
                        else
                        {
                            digits[i].Add(subpart);
                        }
                    }
                    lineCounter++;
                }
                else
                {
                    var accountNumber = new AccountNumber();
                    foreach (var kvp in digits)
                    {
                        var digit = new Digit(kvp.Value.ToArray());
                        accountNumber.AddDigit(kvp.Key, digit);
                    }

                    lineCounter = 0;
                    Console.WriteLine(accountNumber);
                }

            }

            //Console.WriteLine(fileLine);                 
            sReader.Close();
            Console.Read();
        }
    }
}
