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
        public const string FILENAME = "Items.csv";


        // Public Fields
        public static string MappingFilePath;
        public static Dictionary<string, Item> Mapping = new Dictionary<string, Item>();
        public static List<string> Unmapped = new List<string>();


        // Methods

        /// <summary>
        /// parses Items.csv, filling Mapping dictionary
        /// </summary>
        /// <param name="folderPath"></param>
        public static void ParseMappingFile(string folderPath)
        {
            MappingFilePath = Path.Combine(folderPath, FILENAME);

            foreach (string line in File.ReadLines(MappingFilePath, Encoding.UTF8))
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

        /// <summary>
        /// adds an unmapped Item to the List and appends it to the Mapping File
        /// </summary>
        /// <param name="item"></param>
        public static void AppendUnmapped(string item)
        {
            if (!Unmapped.Contains(item))
            {
                // Add to Unmapped list
                Unmapped.Add(item);

                // Append to Mapping File
                using (StreamWriter writer = File.AppendText(MappingFilePath))
                {
                    writer.WriteLine(string.Format("{0},", item));
                }
            }
        }
    }
}
