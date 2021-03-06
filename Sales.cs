﻿using System;
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
        public string FolderPath;
        public int FileCount = 0;

        // lists of LineItems parsed from CSV
        public List<LineItem> InvoicesAndCredits = new List<LineItem>();
        public List<string> Skipped = new List<string>();

        // Lists of unmapped Names/Items in Sales file
        public List<string> UnmappedCustomers = new List<string>();
        public List<string> UnmappedItems = new List<string>();

        // Date Range
        public DateTime MinDate = DateTime.Now;
        public DateTime MaxDate = DateTime.MinValue;


        // Constructor
        public Sales(string folderPath)
        {
            FolderPath = folderPath;

            // Parse all Sales Files
            string[] filenames = Directory.GetFiles(folderPath, "*.csv");
            foreach (string filename in filenames)
            {
                ParseCSV(filename);
                FileCount++;
            }
        }

        // Methods

        /// <summary>
        /// parse the CSV
        /// collect Invoices, Credits, & skipped
        /// </summary>
        /// <param name="filename"></param>
        private void ParseCSV(string filename)
        {
            foreach (string line in File.ReadLines(filename, Encoding.UTF8))
            {
                // Create LineItem from split line
                string[] fields = Parser.Split(line);
                LineItem lineItem = new LineItem(fields);

                // Skip Customers/Items mapped to "DELETE"
                if (Customers.Skip.Contains(lineItem.customer) || Items.Skip.Contains(lineItem.item))
                {
                    Skipped.Add(line);
                    continue;
                }

                // Categorize Invoice / Credit / Skipped
                if (lineItem.type == "Invoice")
                {
                    InvoicesAndCredits.Add(lineItem);
                }
                else if (lineItem.type == "Credit Memo")
                {
                    InvoicesAndCredits.Add(lineItem);
                }
                else // skip others
                {
                    Skipped.Add(line);
                    continue;
                }

                // Date Range
                if (lineItem.date < MinDate)
                {
                    MinDate = lineItem.date;
                }
                if (lineItem.date > MaxDate)
                {
                    MaxDate = lineItem.date;
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
                    lineItem.itemMap = Items.Mapping[lineItem.item];
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
