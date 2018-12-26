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
        // lists of LineItems parsed from CSV
        public List<LineItem> Invoices = new List<LineItem>();
        public List<LineItem> Credits = new List<LineItem>();
        public List<string> Skipped = new List<string>();

        // Lists of unmapped Names/Items in Sales file
        public List<string> UnmappedCustomers = new List<string>();
        public List<string> UnmappedItems = new List<string>();


        // Methods

        /// <summary>
        /// parse the CSV
        /// collect Invoices, Credits, & skipped
        /// </summary>
        /// <param name="filename"></param>
        public void ParseCSV(string filename)
        {
            foreach (string line in File.ReadLines(filename, Encoding.UTF8))
            {
                // Create LineItem from split line
                string[] fields = Parser.Split(line);
                LineItem lineItem = new LineItem(fields);

                // Categorize Invoice / Credit / Skipped
                if (lineItem.type == "Invoice")
                {
                    Invoices.Add(lineItem);
                }
                else if (lineItem.type == "Credit Memo")
                {
                    Credits.Add(lineItem);
                }
                else // skip others
                {
                    Skipped.Add(line);
                    continue;
                }

                // Normalize Customer
                if (Customers.Mapping.ContainsKey(lineItem.customer))
                {
                    lineItem.normalizedCustomer = Customers.Mapping[lineItem.customer];
                }
                else
                {
                    // add unmapped Customer to List & Mapping File
                    if (!UnmappedCustomers.Contains(lineItem.customer))
                    {
                        UnmappedCustomers.Add(lineItem.customer);
                    }
                    Customers.AppendUnmapped(lineItem.customer);
                }

                // Normalize Item
                if (Items.Mapping.ContainsKey(lineItem.item))
                {
                    lineItem.normalizedItem = Items.Mapping[lineItem.item];
                }
                else
                {
                    // add unmapped Item to List & Mapping File
                    if (!UnmappedItems.Contains(lineItem.item))
                    {
                        UnmappedItems.Add(lineItem.item);
                    }
                    Items.AppendUnmapped(lineItem.item);
                }
            }
        }
    }
}
