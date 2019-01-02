using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBooksReporting
{
    class Item
    {
        // Public Fields
        public string Family;
        public string Name;
        public string UpcCode; // 12 digits stored as a string
        public string PackageStyle;
        public string RetailDisplay;


        // Constructor
        public Item(string[] fields)
        {
            Family = fields[1];
            if (fields.Length > 2) Name = fields[2];
            if (fields.Length > 3) UpcCode = fields[3];
            if (fields.Length > 4) PackageStyle = fields[4];
            if (fields.Length > 5) RetailDisplay = fields[5];
        }


        // Overrides
        public override string ToString()
        {
            return string.Format("{0} - {1} - {2} - {3} - {4}", Family, Name, UpcCode, PackageStyle, RetailDisplay);
        }
    }
}
