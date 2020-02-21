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
    class Report
    {
        // Fields
        public string Path;
        HTML Writer;

        private Sales Sales;
        private bool Detailed;
        private DateTime From;
        private DateTime To;


        // Constructor
        public Report(Sales sales, bool customer, bool detailed, DateTime from, DateTime to)
        {
            Sales = sales;
            Detailed = detailed;
            From = from;
            To = to;

            Path = Formatter.GenerateReportPath(sales.FolderPath, customer, detailed, from, to);

            // Write Report file
            using (StreamWriter streamWriter = new StreamWriter(Path))
            {
                using (Writer = new HTML(streamWriter))
                {
                    if (customer)
                    {
                        generateCustomerReport();
                    }
                    else
                    {
                        generateItemReport();
                    }

                    Writer.WriteBreak();
                    Writer.WriteLine(string.Format("created {0} at {1}", DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString()));
                }
            }
        }


        // Methods
        private void generateItemReport()
        {
            // write Headings
            if (Detailed)
                Writer.WriteHeading(HtmlTextWriterTag.H1, "Item Detail");
            else
                Writer.WriteHeading(HtmlTextWriterTag.H1, "Item Summary");
            WriteReportParameters();

            // filter LineItems & collect Items
            SortedDictionary<string, List<LineItem>> itemMap = new SortedDictionary<string, List<LineItem>>();
            foreach (LineItem lineItem in Sales.Invoices)
            {
                FilterAndCollectByItemName(itemMap, lineItem);
            }
            foreach (LineItem lineItem in Sales.Credits)
            {
                FilterAndCollectByItemName(itemMap, lineItem);
            }

            // write Summary Header
            if (!Detailed)
            {
                WriteTableHeader(new string[] { "Product", "Qty", "Total" });
            }

            // loop Items
            decimal total = 0;
            foreach (var itemEntry in itemMap)
            {
                // write Detail Header
                if (Detailed)
                {
                    Writer.WriteHeading(HtmlTextWriterTag.H3, itemEntry.Key);
                    WriteTableHeader(MergeColumns(new string[] { "Date", "Customer", "Qty", "Price", "Total", "Product" }, Items.Columns));
                }

                int quantity = 0;
                decimal subtotal = 0;
                // loop LineItems
                foreach (LineItem lineItem in itemEntry.Value)
                {
                    quantity += lineItem.quantity;
                    subtotal += lineItem.Subtotal;

                    // write LineItem
                    if (Detailed)
                    {
                        string[] columns = new string[] { lineItem.date.ToShortDateString(), lineItem.CustomerName, lineItem.quantity.ToString(), string.Format("{0:C2}", lineItem.price), string.Format("{0:C2}", lineItem.Subtotal), lineItem.ItemName };
                        if (lineItem.itemMap != null)
                            columns = MergeColumns(columns, lineItem.itemMap);
                        WriteTableRow(columns);
                    }
                }

                if (Detailed)
                {
                    // end table
                    Writer.RenderEndTag();
                    Writer.WriteLine();
                    // write Summary
                    Writer.WriteHeading(HtmlTextWriterTag.H5, string.Format("{0} line items totalling {1:C2} for {2} products", itemEntry.Value.Count, subtotal, quantity));
                    Writer.WriteLine();
                }
                else
                {
                    // write Summary
                    WriteTableRow(new string[] { itemEntry.Key, quantity.ToString(), string.Format("{0:C2}", subtotal) });
                }

                total += subtotal;
            }

            if (!Detailed)
            {
                // end table
                Writer.RenderEndTag();
                Writer.WriteLine();
            }

            // write Total
            Writer.WriteHeading(HtmlTextWriterTag.H2, string.Format("Total = {0:C2}", total));
        }

        private void generateCustomerReport()
        {
            // write Headings
            if (Detailed)
                Writer.WriteHeading(HtmlTextWriterTag.H1, "Customer Detail");
            else
                Writer.WriteHeading(HtmlTextWriterTag.H1, "Customer Summary");
            WriteReportParameters();

            // filter LineItems & collect Customers
            SortedDictionary<string, List<LineItem>> customerMap = new SortedDictionary<string, List<LineItem>>();
            foreach (LineItem lineItem in Sales.Invoices)
            {
                FilterAndCollectByCustomerName(customerMap, lineItem);
            }
            foreach (LineItem lineItem in Sales.Credits)
            {
                FilterAndCollectByCustomerName(customerMap, lineItem);
            }

            // loop Customers
            decimal total = 0;
            foreach (var customerEntry in customerMap)
            {
                Writer.WriteHeading(HtmlTextWriterTag.H3, customerEntry.Key);

                int customerQuantity = 0;
                decimal customerSubtotal = 0;

                if (Detailed)
                {
                    // write Header
                    WriteTableHeader(new string[] { "Customer", "Date", "Product", "Qty", "Price", "Total" });

                    // loop LineItems for this Customer
                    foreach (LineItem lineItem in customerEntry.Value)
                    {
                        customerQuantity += lineItem.quantity;
                        customerSubtotal += lineItem.Subtotal;
                        WriteTableRow(new string[] { lineItem.CustomerName, lineItem.date.ToShortDateString(), lineItem.ItemName, lineItem.quantity.ToString(), string.Format("{0:C2}", lineItem.price), string.Format("{0:C2}", lineItem.Subtotal) });
                    }
                }
                else
                {
                    // write Header
                    WriteTableHeader(new string[] { "Customer", "Product", "Qty", "Total" });

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

                        customerQuantity += quantity;
                        customerSubtotal += subtotal;
                        WriteTableRow(new string[] { customerEntry.Key, itemEntry.Key, quantity.ToString(), string.Format("{0:C2}", subtotal) });
                    }
                }

                // end table
                Writer.RenderEndTag();
                Writer.WriteLine();

                // write Summary
                Writer.WriteHeading(HtmlTextWriterTag.H5, string.Format("{0} line items totalling {1:C2} for {2} products", customerEntry.Value.Count, customerSubtotal, customerQuantity));
                Writer.WriteLine();

                total += customerSubtotal;
            }

            // write Total
            Writer.WriteHeading(HtmlTextWriterTag.H2, string.Format("Total = {0:C2}", total));
        }

        private void FilterAndCollectByItemName(SortedDictionary<string, List<LineItem>> itemMap, LineItem lineItem)
        {
            // filter by Date range
            if (lineItem.date < From || lineItem.date > To)
                return;

            // collect LineItems by ItemName
            if (!itemMap.ContainsKey(lineItem.ItemName))
                itemMap.Add(lineItem.ItemName, new List<LineItem>());
            itemMap[lineItem.ItemName].Add(lineItem);

        }

        private void FilterAndCollectByCustomerName(SortedDictionary<string, List<LineItem>> customerMap, LineItem lineItem)
        {
            // filter by Date range
            if (lineItem.date < From || lineItem.date > To)
                return;

            // collect LineItems by CustomerName
            if (!customerMap.ContainsKey(lineItem.CustomerName))
                customerMap.Add(lineItem.CustomerName, new List<LineItem>());
            customerMap[lineItem.CustomerName].Add(lineItem);
        }

        private void WriteReportParameters()
        {
            Writer.WriteHeading(HtmlTextWriterTag.H2, string.Format("{0} thru {1}", Formatter.FormatDate(From), Formatter.FormatDate(To)));
            Writer.WriteBreak();
            Writer.WriteLine();
        }

        private void WriteTableHeader(string[] columns)
        {
            Writer.AddAttribute(HtmlTextWriterAttribute.Border, "1");
            Writer.RenderBeginTag(HtmlTextWriterTag.Table);
            WriteTableRow(columns, true);
        }

        private void WriteTableRow(string[] columns, bool header = false)
        {
            Writer.RenderBeginTag(HtmlTextWriterTag.Tr);
            foreach (string column in columns)
            {
                Writer.RenderBeginTag(header ? HtmlTextWriterTag.Th : HtmlTextWriterTag.Td);
                Writer.WriteLine(column);
                Writer.RenderEndTag();
                Writer.WriteLine();
            }
            Writer.RenderEndTag();
            Writer.WriteLine();
        }

        public static string[] MergeColumns(string[] initialArray, string[] appendingArray, int columnsToSkip = 2)
        {
            string[] destinationArray = new string[initialArray.Length + appendingArray.Length - columnsToSkip];
            Array.Copy(initialArray, 0, destinationArray, 0, initialArray.Length);
            if (appendingArray.Length > columnsToSkip)
            {
                int destinationIndex = initialArray.Length;
                Array.Copy(appendingArray, columnsToSkip, destinationArray, destinationIndex, appendingArray.Length - columnsToSkip);
            }
            return destinationArray;
        }
    }
}
