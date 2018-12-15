using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickBooksReporting
{
    class Names
    {
        // Public Fields
        public static Dictionary<string, string> Mapping = new Dictionary<string, string>();


        // Methods
        public static bool Normalize(Sales sales, string filename)
        {
            foreach (string line in File.ReadLines(filename, Encoding.UTF8))
            {
                string[] nameMapping = line.Split(',');
                string from = nameMapping[0];
                string to = nameMapping[1];
                if (Mapping.ContainsKey(from))
                {
                    MessageBox.Show(string.Format("Duplicate mapping: \"{0}\"", from));
                    return false;
                }
                Mapping[from] = to;

                // update matching LineItems
                if (sales.Names.ContainsKey(from))
                {
                    foreach (LineItem lineItem in sales.Names[from])
                    {
                        lineItem.normalizedName = to;
                    }
                }
            }

            return true;
        }
    }
}
