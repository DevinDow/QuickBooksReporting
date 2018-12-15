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
        public string Filename;

        public List<LineItem> Invoices = new List<LineItem>();
        public List<LineItem> Credits = new List<LineItem>();
        public List<string> Skipped = new List<string>();

        public Dictionary<string, List<LineItem>> Names = new Dictionary<string, List<LineItem>>();
        public Dictionary<string, List<LineItem>> Items = new Dictionary<string, List<LineItem>>();


        // Methods
        public void ParseCSV(string filename)
        {
            Filename = filename;
            foreach (string line in File.ReadLines(filename, Encoding.UTF8))
            {
                string[] fields = line.Split(',');
                LineItem lineItem = new LineItem(fields);
                if (lineItem.type == "Invoice")
                {
                    Invoices.Add(lineItem);
                    TrackUnique(lineItem);
                }
                else if (lineItem.type == "Credit Memo")
                {
                    Credits.Add(lineItem);
                    TrackUnique(lineItem);
                }
                else
                {
                    Skipped.Add(line);
                }
            }
        }

        private void TrackUnique(LineItem lineItem)
        {
            if (!Names.ContainsKey(lineItem.name))
            {
                Names.Add(lineItem.name, new List<LineItem>());
            }
            Names[lineItem.name].Add(lineItem);

            if (!Items.ContainsKey(lineItem.item))
            {
                Items.Add(lineItem.item, new List<LineItem>());
            }
            Items[lineItem.item].Add(lineItem);
        }
    }
}
