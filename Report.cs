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

            foreach (var entry in customerMap)
            {
                writer.WriteHeading(HtmlTextWriterTag.H3, entry.Key);
                writer.WriteLine(string.Format("{0:n0} Line Items", entry.Value.Count));
            }
        }
    }
}
