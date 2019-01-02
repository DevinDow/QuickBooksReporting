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
        public const string SKIP = "DELETE";


        // Public Fields
        public static string MappingFilePath;
        public static Dictionary<string, Item> Mapping;
        public static List<string> Unmapped;
        public static List<string> Skip;



        // Methods

        /// <summary>
        /// parses Items.csv, filling Mapping dictionary
        /// </summary>
        /// <param name="folderPath"></param>
        public static void ParseMappingFile(string folderPath)
        {
            Mapping = new Dictionary<string, Item>();
            Unmapped = new List<string>();
            Skip = new List<string>();
            MappingFilePath = Path.Combine(folderPath, FILENAME);

            if (File.Exists(MappingFilePath))
            {
                foreach (string line in File.ReadLines(MappingFilePath, Encoding.UTF8))
                {
                    // parse CSV mapping file
                    string[] mapping = Parser.Split(line);
                    string from = mapping[0];

                    // skip unmapped Items
                    if (mapping.Length < 2)
                    {
                        Unmapped.Add(from);
                        continue;
                    }

                    string to = mapping[1];

                    // skip Items mapped to "DELETE"
                    if (to == SKIP)
                    {
                        Skip.Add(from);
                        continue;
                    }

                    // Throw if duplicate mappings for from
                    if (Mapping.ContainsKey(from))
                    {
                        throw new Exception(string.Format("Duplicate Item mapping: \"{0}\"", from));
                    }

                    // map "from" to Item object
                    Item item = new Item(mapping);
                    Mapping[from] = item;
                }
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
                    writer.WriteLine(string.Format("\"{0}\"", item));
                }
            }
        }
    }
}
