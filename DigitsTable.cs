using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata_OCR
{
    class DigitsTable : Dictionary<string, int>
    {
        private DigitsTable()
        { }

        private static readonly DigitsTable hashtable;

        static DigitsTable()
        {
            hashtable = new DigitsTable();
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

        public static DigitsTable Instance
        {
            get { return hashtable; }
        }
    }
}
