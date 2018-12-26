using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickBooksReporting
{
    class Customers
    {
        // Constants
        public const string FILENAME = "Customers.csv";


        // Public Fields
        public static Dictionary<string, string> Mapping = new Dictionary<string, string>();


        // Methods

        /// <summary>
        /// parses Names.csv, filling Mapping dictionary
        /// </summary>
        /// <param name="folderPath"></param>
        /// <returns>FALSE if there are duplicate mappings</returns>
        public static void ParseMappingFile(string folderPath)
        {
            string path = Path.Combine(folderPath, FILENAME);

            foreach (string line in File.ReadLines(path, Encoding.UTF8))
            {
                // parse CSV mapping file
                string[] nameMapping = line.Split(',');
                string from = nameMapping[0];
                string to = nameMapping[1];
                {
                    throw new Exception(string.Format("Duplicate Customer mapping: \"{0}\"", from));
                }

                // map "from" to "to"
                Mapping[from] = to;
            }
        }
    }
}
