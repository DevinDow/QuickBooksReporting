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

            Path = Formatter.GenerateCSVPath(sales.FolderPath, from, to);

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
