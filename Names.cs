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
        // Constants
        public const string filename = "Names.csv";


        // Public Fields
        public static Dictionary<string, string> Mapping = new Dictionary<string, string>();


        // Methods

        /// <summary>
        /// parses Names.csv, filling Mapping dictionary
        /// </summary>
        /// <param name="folderPath"></param>
        /// <returns>FALSE if there are duplicate mappings</returns>
        public static bool ParseMappingFile(string folderPath)
        {
            string path = Path.Combine(folderPath, filename);

            foreach (string line in File.ReadLines(path, Encoding.UTF8))
            {
                // parse CSV mapping file
                string[] nameMapping = line.Split(',');
                string from = nameMapping[0];
                string to = nameMapping[1];
                if (Mapping.ContainsKey(from))
                {
                    MessageBox.Show(string.Format("Duplicate Name mapping: \"{0}\"", from));
                    return false;
                }

                // map "from" to "to"
                Mapping[from] = to;
            }

            return true;
        }
    }
}
