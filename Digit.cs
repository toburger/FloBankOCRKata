using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Kata_OCR
{
    class Digit
    {
        private static readonly Dictionary<string, int> hashtable;
        private readonly string[] digitAsArray = new string[3];

        static Digit()
        {
            // Create and return new Hashtable.
            hashtable = new Dictionary<string, int>();
            hashtable.Add("     |  |", 1);
            hashtable.Add(" _  _||_ ", 2);
            hashtable.Add(" _  _| _|", 3);
            hashtable.Add("   |_|  |", 4);
            hashtable.Add(" _ |_  _|", 5);
            hashtable.Add(" _ |_ |_|", 6);
            hashtable.Add(" _   |  |", 7);
            hashtable.Add(" _ |_||_|", 8);
            hashtable.Add(" _ |_| _|", 9);
            hashtable.Add(" _ | ||_|", 0);
        }

        public Digit()
        { }

        public Digit(string[] subparts)
        {
            if (subparts == null)
                throw new ArgumentNullException("subparts");
            if (subparts.Length != 3)
                throw new ArgumentOutOfRangeException("subparts", "Please provide a valid string array with three items in it.");

            for (int i = 0; i < digitAsArray.Length; i++)
                digitAsArray[i] = subparts[i];
        }

        public void AddLine(int lineCount, string subpart)
        {
            this.digitAsArray[lineCount] = subpart;
        }

        private string GetAsString()
        {
            return string.Join("", digitAsArray);
        }

        public override string ToString()
        {
            int number;
            if (TryGetNumber(out number))
                return number.ToString();
            else
                return "?";
        }

        public bool TryGetNumber(out int number)
        {
            string digitasNumber = this.GetAsString();
            return hashtable.TryGetValue(digitasNumber, out number);
        }
    }
}
