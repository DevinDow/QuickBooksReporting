using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickBooksReporting
{
    public partial class MainForm : Form
    {
        // Private Fields

        /// <summary>
        /// Sales object representing one CSV of Sales LineItems
        /// </summary>
        private Sales Sales= new Sales();


        // Constructor
        public MainForm()
        {
            InitializeComponent();
        }


        // Events
        private void MainForm_Shown(object sender, EventArgs e)
        {
            LoadMappings();

            ImportSales();
        }


        // Methods

        /// <summary>
        /// prompts for path to mapping files then parses them
        /// </summary>
        private void LoadMappings()
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "Select folder for your MAPPING CSV files";
            folderBrowserDialog.SelectedPath = Application.StartupPath;
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
            {
                Application.Exit();
            }

            if (!Names.ParseMappingFile(folderBrowserDialog.SelectedPath))
            {
                Application.Exit();
            }

            if (!Items.ParseMappingFile(folderBrowserDialog.SelectedPath))
            {
                Application.Exit();
            }

            stsInfo.Text = string.Format("Parsed {0} Name mappings and {1} Item mappings from \"{2}\".", Names.Mapping.Count, Items.Mapping.Count, folderBrowserDialog.SelectedPath);
        }

        /// <summary>
        /// import a CSV of Sales LineItems
        /// </summary>
        private void ImportSales()
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "Select folder for your SALES CSV files";
            folderBrowserDialog.SelectedPath = Application.StartupPath;
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
            {
                Application.Exit();
            }

            string[] filenames = Directory.GetFiles(folderBrowserDialog.SelectedPath, "*.csv");
            foreach (string filename in filenames)
            {
                Sales.ParseCSV(filename);
            }

            stsInfo.Text = string.Format("Parsed {0} Sales files from \"{1}\"", filenames.Length, folderBrowserDialog.SelectedPath);

            fillUnmappedNames();

            fillUnmappedItems();
        }

        /// <summary>
        /// clears & refills lstUnmappedNames
        /// </summary>
        private void fillUnmappedNames()
        {
            string[] unmappedNames = Sales.UnmappedNames.Keys.ToArray();
            Array.Sort(unmappedNames);
            lstUnmappedNames.Items.Clear();
            lstUnmappedNames.Items.AddRange(unmappedNames);
        }

        /// <summary>
        /// clears & refills lstUnmappedItems
        /// </summary>
        private void fillUnmappedItems()
        {
            string[] unmappedItems = Sales.UnmappedItems.Keys.ToArray();
            Array.Sort(unmappedItems);
            lstUnmappedItems.Items.Clear();
            lstUnmappedItems.Items.AddRange(unmappedItems);
        }
    }
}
