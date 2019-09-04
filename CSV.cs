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
            string[] columns = Report.MergeColumns(new string[] { "Date", "Customer", "Qty", "Price Each", "Total Sales" }, Items.Columns);
            Writer.WriteLine(string.Join(",", columns));

            foreach (LineItem lineItem in Sales.Invoices)
            {
                // Filter by Date range
                if (lineItem.date < From || lineItem.date > To)
                    continue;

                columns = new string[] { lineItem.date.ToShortDateString(), lineItem.CustomerName, lineItem.quantity.ToString(), string.Format("${0}", lineItem.price), string.Format("${0}", lineItem.Subtotal) };
                if (lineItem.itemMap != null)
                {
                    columns = Report.MergeColumns(columns, lineItem.itemMap);
                }
                else
                {
                    columns = Report.MergeColumns(columns, new string[] { lineItem.ItemName });
                }

                Writer.WriteLine(string.Join(",", columns));
            }
        }

        private void generateItemSummary()
        {
            string[] columns = Report.MergeColumns(new string[] { "Product", "Qty", "Total Sales" }, Items.Columns);
            Writer.WriteLine(string.Join(",", columns));

            // Filter & Collect
            SortedDictionary<string, List<LineItem>> itemMap = new SortedDictionary<string, List<LineItem>>();
            foreach (LineItem lineItem in Sales.Invoices)
            {
                // Filter by Date range
                if (lineItem.date < From || lineItem.date > To)
                    continue;

                // Collect LineItems by ItemName
                if (!itemMap.ContainsKey(lineItem.ItemName))
                {
                    itemMap.Add(lineItem.ItemName, new List<LineItem>());
                }

                itemMap[lineItem.ItemName].Add(lineItem);
            }

            foreach (var itemEntry in itemMap)
            {
                int quantity = 0;
                decimal subtotal = 0;
                foreach (LineItem lineItem in itemEntry.Value)
                {
                    quantity += lineItem.quantity;
                    subtotal += lineItem.Subtotal;
                }
                columns = new string[] { itemEntry.Key, quantity.ToString(), string.Format("${0}", subtotal) };
                Writer.WriteLine(string.Join(",", columns));
            }
        }

        private void generateCustomerSummary()
        {
        }
    }
}
