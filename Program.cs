using System;
using System.Collections;
using System.Collections.Generic;

namespace Kata_OCR
{
    class Program
    {
        private static AccountNumber accountNumber;

        static void Main(string[] args)
        {
            string file = @"..\..\SampleData\sample.txt";

            System.IO.StreamReader sReader = new System.IO.StreamReader(file);

            string fileLine;
            int lineCounter = 0;
            var combinedNumber = new Dictionary<int, string>();

            int accountNumberLength = 9;
            int count = 1;
            while ((fileLine = sReader.ReadLine()) != null /*&&  count < 7*/ )
            {
                count++;
                if (fileLine.Length > 0)
                {
                    //replace \n\r
                    fileLine = fileLine.Replace(System.Environment.NewLine, string.Empty);
                    if (lineCounter == 0)
                    {
                        accountNumber = new AccountNumber();
                    }
                    // loop beginns from end to assign correct
                    for (var i = 0; i < accountNumberLength; i++)
                    {
                        //split line into parts
                        string subpart = fileLine.Substring(i * 3, 3);

                        //On first line create digit and ad it to accountnumber
                        if (lineCounter == 0)
                        {
                            Digit digit = new Digit();
                            digit.AddString(lineCounter, subpart);
                            accountNumber.AddDigit(i, digit);
                        }
                        else
                        {
                            accountNumber.GetDigitByIndex(i).AddString(lineCounter, subpart);
                        }
                    }
                    lineCounter++;
                }
                else
                {
                    lineCounter = 0;
                    string additionalState = "";
                    //Begin to evaluate accountNumber 
                    accountNumber.PrepareNumber();
                    accountNumber.Check();
                    String number = accountNumber.GetNumber();
                    if (accountNumber.IsReadable() == false)
                    {
                        additionalState = "  ILL";
                    }
                    else
                    {
                        if (accountNumber.GetIsValidChecksum() == false)
                        {
                            additionalState = "  ERR";
                        }
                    }
                    Console.WriteLine(number + additionalState);
                }

            }
            //Console.WriteLine(fileLine);                 
            sReader.Close();
            Console.Read();
        }
    }
}
