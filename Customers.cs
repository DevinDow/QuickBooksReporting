﻿using System;
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
        public const string SKIP = "DELETE";


        // Public Fields
        public static string MappingFilePath;
        public static Dictionary<string, string> Mapping;
        public static List<string> Unmapped;
        public static List<string> Skip;


        // Methods

        /// <summary>
        /// parses Names.csv, filling Mapping dictionary
        /// </summary>
        /// <param name="folderPath"></param>
        public static void ParseMappingFile(string folderPath)
        {
            Mapping = new Dictionary<string, string>();
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

                    // skip unmapped Customers
                    if (mapping.Length < 2)
                    {
                        Unmapped.Add(from);
                        continue;
                    }

                    string to = mapping[1];

                    // skip Customers mapped to "DELETE"
                    if (to == SKIP)
                    {
                        Skip.Add(from);
                        continue;
                    }

                    // Throw if duplicate mappings for from
                    if (Mapping.ContainsKey(from))
                    {
                        throw new Exception(string.Format("Duplicate Customer mapping: \"{0}\"", from));
                    }

                    // map "from" to "to"
                    Mapping[from] = to;
                }
            }
        }

        /// <summary>
        /// adds an unmapped Customer to the List and appends it to the Mapping File
        /// </summary>
        /// <param name="customer"></param>
        public static void AppendUnmapped(string customer)
        {
            if (!Unmapped.Contains(customer))
            {
                // Add to Unmapped list
                Unmapped.Add(customer);

                // Append to Mapping File
                using (StreamWriter writer = File.AppendText(MappingFilePath))
                {
                    writer.WriteLine(string.Format("\"{0}\"", customer));
                }
            }
        }
    }
}
