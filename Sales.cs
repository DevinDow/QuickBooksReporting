using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBooksReporting
{
    class Sales
    {
        // Public Fields
        public string Name;
        public List<LineItem> Invoices = new List<LineItem>();
        public List<LineItem> Credits = new List<LineItem>();
        public List<string> Skipped = new List<string>();


        // Methods
        public void ParseCSV(string filename)
        {
            foreach (string line in File.ReadLines(filename, Encoding.UTF8))
            {
                string[] fields = line.Split(',');
                LineItem lineItem = new LineItem(fields);
                if (lineItem.type == "Invoice")
                {
                    Invoices.Add(lineItem);
                }
                else if (lineItem.type == "Credit Memo")
                {
                    Credits.Add(lineItem);
                }
                else
                {
                    Skipped.Add(line);
                }
            }
        }
    }
}
