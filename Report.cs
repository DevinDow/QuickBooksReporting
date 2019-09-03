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

            // Path for Report
            string date = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
            string reportType = customer ? "customer" : "item";
            string reportDetailed = detailed ? "-detailed" : "";
            string filename = string.Format("{0} {1}{2}.html", date, reportType, reportDetailed);
            
            // reportsFolder
            string reportsFolder = System.IO.Path.Combine(sales.FolderPath, "reports");
            if (!Directory.Exists(reportsFolder))
            {
                Directory.CreateDirectory(reportsFolder);
            }
            Path = System.IO.Path.Combine(reportsFolder, filename);

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
                    Writer.WriteLine("generated " + date);
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
            foreach (var entry in customerMap)
            {
                Writer.WriteHeading(HtmlTextWriterTag.H3, entry.Key);

                if (Detailed)
                {
                    WriteTableHeader(new string[] { "Item", "Quantity", "Price", "Subtotal" });
                }

                decimal subtotal = 0;
                foreach (LineItem lineItem in entry.Value)
                {
                    subtotal += lineItem.Subtotal;

                    if (Detailed)
                    {
                        WriteTableRow(new string[] { lineItem.item, lineItem.quantity.ToString(), string.Format("${0}", lineItem.price), string.Format("${0}", lineItem.Subtotal) });
                    }
                }

                if (Detailed)
                {
                    Writer.RenderEndTag();
                }

                Writer.WriteHeading(HtmlTextWriterTag.H5, string.Format("{0:n0} Line Items totalling ${1:n2}", entry.Value.Count, subtotal));
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

            // Loop itemMap
            decimal total = 0;
            foreach (var entry in itemMap)
            {
                Writer.WriteHeading(HtmlTextWriterTag.H3, entry.Key);

                if (Detailed)
                {
                    WriteTableHeader(MergeColumns(new string[] { "Customer", "Quantity", "Price", "Subtotal" }, Items.Columns));
                }

                decimal subtotal = 0;
                foreach (LineItem lineItem in entry.Value)
                {
                    subtotal += lineItem.Subtotal;

                    if (Detailed)
                    {
                        string[] columns = new string[] { lineItem.CustomerName, lineItem.quantity.ToString(), string.Format("${0}", lineItem.price), string.Format("${0}", lineItem.Subtotal) };
                        if (lineItem.itemMap != null)
                        {
                            columns = MergeColumns(columns, lineItem.itemMap);
                        }
                        WriteTableRow(columns);
                    }
                }

                if (Detailed)
                {
                    Writer.RenderEndTag();
                }

                Writer.WriteHeading(HtmlTextWriterTag.H5, string.Format("{0:n0} Line Items totalling ${1:n2}", entry.Value.Count, subtotal));
                Writer.WriteLine();

                total += subtotal;
            }

            Writer.WriteHeading(HtmlTextWriterTag.H2, string.Format("Total = ${0:n2}", total));
        }

        private void WriteReportParameters()
        {
            Writer.WriteLine(string.Format("From {0} to {1}", From.ToShortDateString(), To.ToShortDateString()));
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
