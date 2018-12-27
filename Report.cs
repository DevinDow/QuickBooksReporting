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

        private Sales Sales;

        
        // Constructor
        public Report(Sales sales, bool customer, bool detailed)
        {
            Sales = sales;

            string date = DateTime.Now.ToString("yyyy-MM-dd HH-mm");
            string reportType = customer ? "customer" : "item";
            string reportDetailed = detailed ? "-detailed" : "";
            string filename = string.Format("{0} {1}{2}.html", date, reportType, reportDetailed);
            Path = System.IO.Path.Combine(sales.FolderPath, filename);

            using (StreamWriter streamWriter = new StreamWriter(Path))
            {
                using (HTML writer = new HTML(streamWriter))
                {
                    if (customer)
                    {
                        generateCustomerReport(writer, detailed);
                    }

                    writer.WriteBreak();
                    writer.WriteLine("generated " + date);
                }
            }
        }


        // Methods
        private void generateCustomerReport(HTML writer, bool detailed)
        {
            writer.WriteHeading(HtmlTextWriterTag.H1, "Customer Report");

            SortedDictionary<string, List<LineItem>> customerMap = new SortedDictionary<string, List<LineItem>>();

            // Collect LineItems by Customer
            foreach (LineItem lineItem in Sales.Invoices)
            {
                if (!customerMap.ContainsKey(lineItem.CustomerName))
                {
                    customerMap.Add(lineItem.CustomerName, new List<LineItem>());
                }

                customerMap[lineItem.CustomerName].Add(lineItem);
            }

            decimal total = 0;
            foreach (var entry in customerMap)
            {
                writer.WriteHeading(HtmlTextWriterTag.H3, entry.Key);

                decimal subtotal = 0;
                foreach (LineItem lineItem in entry.Value)
                {
                    subtotal += lineItem.Subtotal;

                    if (detailed)
                    {
                        writer.WriteLine(string.Format("{0} {1} @ {2} = {3:n2}", lineItem.quantity, lineItem.item, lineItem.price, lineItem.Subtotal));
                        writer.WriteBreak();
                        writer.WriteLine();
                    }
                }

                writer.WriteHeading(HtmlTextWriterTag.H5, string.Format("{0:n0} Line Items totalling ${1:n2}", entry.Value.Count, subtotal));
                writer.WriteLine();

                total += subtotal;
            }

            writer.WriteHeading(HtmlTextWriterTag.H2, string.Format("Total = ${0:n2}", total));
        }
    }
}
