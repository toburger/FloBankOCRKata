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

        private static readonly DigitsTable _hashtable;

        static DigitsTable()
        {
            _hashtable = new DigitsTable();
            _hashtable.Add("     |  |", 1);
            _hashtable.Add(" _  _||_ ", 2);
            _hashtable.Add(" _  _| _|", 3);
            _hashtable.Add("   |_|  |", 4);
            _hashtable.Add(" _ |_  _|", 5);
            _hashtable.Add(" _ |_ |_|", 6);
            _hashtable.Add(" _   |  |", 7);
            _hashtable.Add(" _ |_||_|", 8);
            _hashtable.Add(" _ |_| _|", 9);
            _hashtable.Add(" _ | ||_|", 0);
        }

        public static DigitsTable Instance
        {
            get { return _hashtable; }
        }
    }
}
