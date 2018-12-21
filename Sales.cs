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
        public Dictionary<string, List<LineItem>> UnmappedItems = new Dictionary<string, List<LineItem>>();
        public Dictionary<string, List<LineItem>> MappedItems = new Dictionary<string, List<LineItem>>();


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
        /// collect LineItems by unique Name & Item
        /// </summary>
        /// <param name="lineItem"></param>
        private void TrackUnique(LineItem lineItem)
        {
            // Company Names
            if (!UnmappedNames.ContainsKey(lineItem.name))
            {
                UnmappedNames.Add(lineItem.name, new List<LineItem>());
            }
            UnmappedNames[lineItem.name].Add(lineItem);

            // Items
            if (!UnmappedItems.ContainsKey(lineItem.item))
            {
                UnmappedItems.Add(lineItem.item, new List<LineItem>());
            }
            UnmappedItems[lineItem.item].Add(lineItem);
        }
    }
}

/*
    // update matching LineItems
    if (sales.UnmappedNames.ContainsKey(from))
    {
        // create new MappedNames key
        if (!sales.MappedNames.ContainsKey(to))
        {
            sales.MappedNames.Add(to, new List<LineItem>());
        }

        foreach (LineItem lineItem in sales.UnmappedNames[from])
        {
            // update LineItem
            lineItem.normalizedName = to;

            // move to new Key
            sales.MappedNames[to].Add(lineItem);
        }

        // remove key from UnmappedNames
        sales.UnmappedNames.Remove(from);
    }
*/

/*
    // update matching UnmappedItems
    if (sales.UnmappedItems.ContainsKey(from))
    {
        // create new MappedNames key
        if (!sales.MappedItems.ContainsKey(to))
        {
            sales.MappedItems.Add(to, new List<LineItem>());
        }

        foreach (LineItem lineItem in sales.UnmappedItems[from])
        {
            // update LineItem
            lineItem.normalizedItem = item;

            // move to new Key
            sales.MappedItems[to].Add(lineItem);
        }

        // remove key from UnmappedNames
        sales.UnmappedItems.Remove(from);
    }
*/
