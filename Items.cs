using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickBooksReporting
{
    class Items
    {
        // Public Fields
        public static Dictionary<string, Item> Mapping = new Dictionary<string, Item>();


        // Methods

        /// <summary>
        /// import CSV of Item Mapping
        /// </summary>
        /// <param name="sales"></param>
        /// <param name="filename">CSV of Name mapping</param>
        /// <returns></returns>
        public static bool Normalize(Sales sales, string filename)
        {
            foreach (string line in File.ReadLines(filename, Encoding.UTF8))
            {
                // parse CSV mapping file
                string[] nameMapping = line.Split(',');
                string from = nameMapping[0];
                if (Mapping.ContainsKey(from))
                {
                    MessageBox.Show(string.Format("Duplicate mapping: \"{0}\"", from));
                    return false;
                }

                // map "from" to Item object
                Item item = new Item(nameMapping);
                Mapping[from] = item;
                string to = item.ToString();

                // update matching UnmappedItems
                if (sales.UnmappedItems.ContainsKey(from))
                {
                    // create new MappedNames key
                    if (!sales.MappedItems.ContainsKey(to))
                    {
                        sales.MappedItems.Add(to, new List<LineItem>());
                    }

                    foreach (LineItem lineItem in sales.UnmappedItems[from])
                    {
                        // update LineItem
                        lineItem.normalizedItem = item;

                        // move to new Key
                        sales.MappedItems[to].Add(lineItem);
                    }

                    // remove key from UnmappedNames
                    sales.UnmappedItems.Remove(from);
                }
            }

            return true;
        }
    }
}
