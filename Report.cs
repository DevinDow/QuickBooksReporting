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
            string date = DateTime.Now.ToString("yyyy-MM-dd HH-mm");
            string reportType = customer ? "customer" : "item";
            string reportDetailed = detailed ? "-detailed" : "";
            string filename = string.Format("{0} {1}{2}.html", date, reportType, reportDetailed);
            Path = System.IO.Path.Combine(sales.FolderPath, filename);

            // Write Report file
            using (StreamWriter streamWriter = new StreamWriter(Path))
            {
                using (Writer = new HTML(streamWriter))
                {
                    if (customer)
                    {
                        generateCustomerReport();
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
                Writer.WriteHeading(HtmlTextWriterTag.H1, "Customer Report - detailed");
            else
                Writer.WriteHeading(HtmlTextWriterTag.H1, "Customer Report");

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

                decimal subtotal = 0;
                foreach (LineItem lineItem in entry.Value)
                {
                    subtotal += lineItem.Subtotal;

                    if (Detailed)
                    {
                        Writer.WriteLine(string.Format("{0} {1} @ {2} = {3:n2}", lineItem.quantity, lineItem.item, lineItem.price, lineItem.Subtotal));
                        Writer.WriteBreak();
                        Writer.WriteLine();
                    }
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
    }
}
