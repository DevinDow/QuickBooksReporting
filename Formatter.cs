using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBooksReporting
{
    class Formatter
    {
        public static string GenerateReportPath(string salesFolderPath, bool customer, bool detailed, DateTime from, DateTime to)
        {
            string reportsFolder = GenerateReportsFolder(salesFolderPath);
            string reportType = customer ? "Customer" : "Item";
            string reportDetail = detailed ? "Detail" : "Summary";
            string reportDate = FormatDate(DateTime.Now);
            string filename = string.Format("{0} {1} {2} thru {3} Created {4}.html", reportType, reportDetail, FormatDate(from), FormatDate(to), reportDate);
            return System.IO.Path.Combine(reportsFolder, filename);
        }

        public static string GenerateCSVPath(string salesFolderPath, DateTime from, DateTime to)
        {
            string reportsFolder = GenerateReportsFolder(salesFolderPath);
            string reportDate = FormatDate(DateTime.Now);
            string filename = string.Format("{0} thru {1} Created {2}.csv", FormatDate(from), FormatDate(to), reportDate);
            return System.IO.Path.Combine(reportsFolder, filename);
        }

        private static string GenerateReportsFolder(string salesFolderPath)
        {
            string reportsFolder = System.IO.Path.Combine(salesFolderPath, "reports");
            if (!Directory.Exists(reportsFolder))
                Directory.CreateDirectory(reportsFolder);
            return reportsFolder;
        }

        public static string FormatDate(DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }
    }
}
