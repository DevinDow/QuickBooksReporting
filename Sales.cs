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

        // lists of LineItems parsed from CSV
        public List<LineItem> Invoices = new List<LineItem>();
        public List<LineItem> Credits = new List<LineItem>();
        public List<string> Skipped = new List<string>();

        // maps of Names/Items to lists of LineItems with those Names/Items
        public Dictionary<string, List<LineItem>> UnmappedNames = new Dictionary<string, List<LineItem>>();
        public Dictionary<string, List<LineItem>> MappedNames = new Dictionary<string, List<LineItem>>();
        public Dictionary<string, List<LineItem>> Items = new Dictionary<string, List<LineItem>>();


        // Methods

        /// <summary>
        /// parse the CSV
        /// collect Invoices, Credits, & skipped
        /// </summary>
        /// <param name="filename"></param>
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

        /// <summary>
        /// collect LineItems by unique Name/Item
        /// </summary>
        /// <param name="lineItem"></param>
        private void TrackUnique(LineItem lineItem)
        {
            if (!UnmappedNames.ContainsKey(lineItem.name))
            {
                UnmappedNames.Add(lineItem.name, new List<LineItem>());
            }
            UnmappedNames[lineItem.name].Add(lineItem);

            if (!Items.ContainsKey(lineItem.item))
            {
                Items.Add(lineItem.item, new List<LineItem>());
            }
            Items[lineItem.item].Add(lineItem);
        }
    }
}
