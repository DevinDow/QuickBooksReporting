﻿using System;
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
        private void generateCustomerReport()
        {
            // Write Headings
            if (Detailed)
                Writer.WriteHeading(HtmlTextWriterTag.H1, "Customer Detail");
            else
                Writer.WriteHeading(HtmlTextWriterTag.H1, "Customer Summary");

            WriteReportParameters();

            // Filter & Collect
            SortedDictionary<string, List<LineItem>> customerMap = new SortedDictionary<string, List<LineItem>>();
            foreach (LineItem lineItem in Sales.Invoices)
            {
                // Filter by Date range
                if (lineItem.date < From || lineItem.date > To)
                    continue;

                // Collect LineItems by Customer
                if (!customerMap.ContainsKey(lineItem.CustomerName))
                {
                    customerMap.Add(lineItem.CustomerName, new List<LineItem>());
                }

                customerMap[lineItem.CustomerName].Add(lineItem);
            }

            // Loop customerMap
            decimal total = 0;
            foreach (var customerEntry in customerMap)
            {
                Writer.WriteHeading(HtmlTextWriterTag.H3, customerEntry.Key);

                if (Detailed)
                {
                    WriteTableHeader(new string[] { "Customer", "Date", "Product", "Qty", "Price", "Total" });
                }

                decimal subtotal = 0;
                foreach (LineItem lineItem in customerEntry.Value)
                {
                    subtotal += lineItem.Subtotal;

                    if (Detailed)
                    {
                        WriteTableRow(new string[] { lineItem.CustomerName, lineItem.date.ToShortDateString(), lineItem.item, lineItem.quantity.ToString(), string.Format("${0}", lineItem.price), string.Format("${0}", lineItem.Subtotal) });
                    }
                }

                if (Detailed)
                {
                    Writer.RenderEndTag();
                }

                Writer.WriteHeading(HtmlTextWriterTag.H5, string.Format("{0:n0} Line Items totalling ${1:n2}", customerEntry.Value.Count, subtotal));
                Writer.WriteLine();

                total += subtotal;
            }

            Writer.WriteHeading(HtmlTextWriterTag.H2, string.Format("Total = ${0:n2}", total));
        }

        private void generateItemReport()
        {
            // Write Headings
            if (Detailed)
                Writer.WriteHeading(HtmlTextWriterTag.H1, "Item Detail");
            else
                Writer.WriteHeading(HtmlTextWriterTag.H1, "Item Summary");

            WriteReportParameters();

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

            if (!Detailed)
            {
                WriteTableHeader(new string[] { "Product", "Qty", "Total" });
            }

            // Loop itemMap
            decimal total = 0;
            foreach (var itemEntry in itemMap)
            {
                if (Detailed)
                {
                    Writer.WriteHeading(HtmlTextWriterTag.H3, itemEntry.Key);
                    WriteTableHeader(MergeColumns(new string[] { "Product", "Date", "Customer", "Qty", "Price", "Total" }, Items.Columns));
                }

                decimal subtotal = 0;
                foreach (LineItem lineItem in itemEntry.Value)
                {
                    subtotal += lineItem.Subtotal;

                    if (Detailed)
                    {
                        string[] columns = new string[] { lineItem.ItemName, lineItem.date.ToShortDateString(), lineItem.CustomerName, lineItem.quantity.ToString(), string.Format("${0}", lineItem.price), string.Format("${0}", lineItem.Subtotal) };
                        if (lineItem.itemMap != null)
                        {
                            columns = MergeColumns(columns, lineItem.itemMap);
                        }
                        WriteTableRow(columns);
                    }
                }

                if (Detailed)
                {
                    Writer.RenderEndTag(); // end table
                    Writer.WriteLine();
                    Writer.WriteHeading(HtmlTextWriterTag.H5, string.Format("{0:n0} Line Items totalling ${1:n2}", itemEntry.Value.Count, subtotal));
                    Writer.WriteLine();
                }
                else
                {
                    WriteTableRow(new string[] { itemEntry.Key, itemEntry.Value.Count.ToString(), string.Format("${0}", subtotal) });
                }

                total += subtotal;
            }

            if (!Detailed)
            {
                Writer.RenderEndTag(); // end table
                Writer.WriteLine();
            }

            Writer.WriteHeading(HtmlTextWriterTag.H2, string.Format("Total = ${0:n2}", total));
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

        public static string[] MergeColumns(string[] arr1, string[] arr2)
        {
            int destinationIndex = arr1.Length;
            Array.Resize<string>(ref arr1, arr1.Length + arr2.Length);
            Array.Copy(arr2, 0, arr1, destinationIndex, arr2.Length);
            return arr1;
        }
    }
}
