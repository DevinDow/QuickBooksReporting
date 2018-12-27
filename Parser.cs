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
            string[] fields = Regex.Split(line, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");

            // Trim the leading & trailing double-quotes
            for (int i=0; i<fields.Length; i++)
            {
                fields[i] = fields[i].Trim('\"');
            }

            return fields;
        }
    }
}
