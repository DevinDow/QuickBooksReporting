using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QuickBooksReporting
{
    class Parser
    {
        public static string[] Split(string line)
        {
            // Regular Expression to split on commas not within double-quotes
            return Regex.Split(line, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
        }
    }
}
