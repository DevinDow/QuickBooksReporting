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


        // Constructor
        public CSV(Sales sales, DateTime from, DateTime to)
        {
            Sales = sales;

            // Path for Report
            string date = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
            string filename = string.Format("{0}.csv", date);

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
                    string[] columns = Report.MergeColumns(new string[] { "Customer", "Quantity", "Price", "Subtotal" }, Items.Columns);
                    Writer.WriteLine(string.Join(",", columns));

                    foreach (LineItem lineItem in Sales.Invoices)
                    {
                        // Filter by Date range
                        if (lineItem.date < from || lineItem.date > to)
                            continue;

                        columns = new string[] { lineItem.CustomerName, lineItem.quantity.ToString(), string.Format("${0}", lineItem.price), string.Format("${0}", lineItem.Subtotal) };
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
            }
        }
    }
}
