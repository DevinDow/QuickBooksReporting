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
                if (sales.UnmappedNames.ContainsKey(from))
                {
                    // create new MappedNames key
                    if (!sales.MappedNames.ContainsKey(to))
                    {
                        sales.MappedNames.Add(to, new List<LineItem>());
                    }

                    foreach (LineItem lineItem in sales.UnmappedNames[from])
                    {
                        // update LineItem
                        lineItem.normalizedName = to;

                        // move to new Key
                        sales.MappedNames[to].Add(lineItem);
                    }

                    // remove key from UnmappedNames
                    sales.UnmappedNames.Remove(from);
                }
            }

            return true;
        }
    }
}
