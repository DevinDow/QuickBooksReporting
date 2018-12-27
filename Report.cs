using System;
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
        // Public Fields
        public string Path;

        
        // Constructor
        public Report(Sales sales, bool customer, bool detailed)
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd HH-mm");
            string reportType = customer ? "customer" : "item";
            string reportDetailed = detailed ? "-detailed" : "";
            string filename = string.Format("{0} {1}{2}.html", date, reportType, reportDetailed);
            Path = System.IO.Path.Combine(sales.FolderPath, filename);

            using (StreamWriter streamWriter = new StreamWriter(Path))
            {
                using (HtmlTextWriter writer = new HtmlTextWriter(streamWriter))
                {
                    writer.WriteLine("Testing 1..2..3..");

                }
            }
        }
    }
}
