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
        // Constants
        public const string filename = "Items.csv";


        // Public Fields
        public static Dictionary<string, Item> Mapping = new Dictionary<string, Item>();


        // Methods

        /// <summary>
        /// parses Items.csv, filling Mapping dictionary
        /// </summary>
        /// <param name="folderPath"></param>
        /// <returns>FALSE if there are duplicate mappings</returns>
        public static void ParseMappingFile(string folderPath)
        {
            string path = Path.Combine(folderPath, filename);

            foreach (string line in File.ReadLines(path, Encoding.UTF8))
            {
                // parse CSV mapping file
                string[] nameMapping = line.Split(',');
                string from = nameMapping[0];
                if (Mapping.ContainsKey(from))
                {
                    throw new Exception(string.Format("Duplicate Item mapping: \"{0}\"", from));
                }

                // map "from" to Item object
                Item item = new Item(nameMapping);
                Mapping[from] = item;
                string to = item.ToString();
            }
        }
    }
}
