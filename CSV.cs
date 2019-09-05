using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace QuickBooksReporting
{
    class CSV
    {
        // Fields
        public string Path;
        HTML Writer;

        private Sales Sales;
        private bool Detailed;
        private DateTime From;
        private DateTime To;


        // Constructor
        public CSV(Sales sales, bool customer, bool detailed, DateTime from, DateTime to)
        {
            Sales = sales;
            From = from;
            To = to;

            Path = Formatter.GenerateCSVPath(sales.FolderPath, customer, detailed, from, to);

            // Write Report file
            using (StreamWriter streamWriter = new StreamWriter(Path))
            {
                using (Writer = new HTML(streamWriter))
                {
                    if (detailed)
                        generateDetailed();
                    else
                    {
                        if (customer)
                            generateCustomerSummary();
                        else
                            generateItemSummary();
                    }
                }
            }
        }

        private void generateDetailed()
        {
            // write Header
            string[] columns = Report.MergeColumns(new string[] { "Date", "Customer", "Qty", "Price Each", "Total Sales", "Product" }, Items.Columns);
            Writer.WriteLine(string.Join(",", columns));

            // loop LineItems
            foreach (LineItem lineItem in Sales.Invoices)
            {
                // Filter by Date range
                if (lineItem.date < From || lineItem.date > To)
                    continue;

                // write LineItem
                columns = new string[] { lineItem.date.ToShortDateString(), lineItem.CustomerName, lineItem.quantity.ToString(), string.Format("{0:$0.00}", lineItem.price), string.Format("{0:$0.00}", lineItem.Subtotal), lineItem.ItemName };
                if (lineItem.itemMap != null)
                {
                    columns = Report.MergeColumns(columns, lineItem.itemMap);
                }

                Writer.WriteLine(string.Join(",", columns));
            }
        }

        private void generateItemSummary()
        {
            // write Header
            string[] columns = new string[] { "Product", "Qty", "Total Sales" };
            Writer.WriteLine(string.Join(",", columns));

            // filter LineItems & collect Items
            SortedDictionary<string, List<LineItem>> itemMap = new SortedDictionary<string, List<LineItem>>();
            foreach (LineItem lineItem in Sales.Invoices)
            {
                // filter by Date range
                if (lineItem.date < From || lineItem.date > To)
                    continue;

                // collect LineItems by ItemName
                if (!itemMap.ContainsKey(lineItem.ItemName))
                    itemMap.Add(lineItem.ItemName, new List<LineItem>());
                itemMap[lineItem.ItemName].Add(lineItem);
            }

            // loop Items
            foreach (var itemEntry in itemMap)
            {
                int quantity = 0;
                decimal subtotal = 0;
                // loop LineItems
                foreach (LineItem lineItem in itemEntry.Value)
                {
                    quantity += lineItem.quantity;
                    subtotal += lineItem.Subtotal;
                }

                // write Item summary
                columns = new string[] { itemEntry.Key, quantity.ToString(), string.Format("{0:$0.00}", subtotal) };
                Writer.WriteLine(string.Join(",", columns));
            }
        }

        private void generateCustomerSummary()
        {
            // write Header
            string[] columns = new string[] { "Customer", "Product", "Qty", "Total Sales" };
            Writer.WriteLine(string.Join(",", columns));

            // filter LineItems & collect LineItems by Customer
            SortedDictionary<string, List<LineItem>> customerMap = new SortedDictionary<string, List<LineItem>>();
            foreach (LineItem lineItem in Sales.Invoices)
            {
                // filter by Date range
                if (lineItem.date < From || lineItem.date > To)
                    continue;

                // collect LineItems by CustomerName
                if (!customerMap.ContainsKey(lineItem.CustomerName))
                    customerMap.Add(lineItem.CustomerName, new List<LineItem>());
                customerMap[lineItem.CustomerName].Add(lineItem);
            }

            // loop Customers
            foreach (var customerEntry in customerMap)
            {
                // collect LineItems for this Customer by ItemName
                SortedDictionary<string, List<LineItem>> itemMap = new SortedDictionary<string, List<LineItem>>();
                foreach (LineItem lineItem in customerEntry.Value)
                {
                    if (!itemMap.ContainsKey(lineItem.ItemName))
                        itemMap.Add(lineItem.ItemName, new List<LineItem>());
                    itemMap[lineItem.ItemName].Add(lineItem);
                }

                // loop Items for this Customer
                foreach (var itemEntry in itemMap)
                {
                    int quantity = 0;
                    decimal subtotal = 0;
                    // loop LineItems for this Item for this Customer
                    foreach (LineItem lineItem in itemEntry.Value)
                    {
                        quantity += lineItem.quantity;
                        subtotal += lineItem.Subtotal;
                    }
                    columns = new string[] { customerEntry.Key, itemEntry.Key, quantity.ToString(), string.Format("{0:$0.00}", subtotal) };
                    Writer.WriteLine(string.Join(",", columns));
                }
            }
        }
    }
}
