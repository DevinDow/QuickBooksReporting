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
            try
            {
                LoadMappings();

                ImportSales();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception");
            }
        }


        // Methods

        /// <summary>
        /// Parse mapping files
        /// </summary>
        private void LoadMappings()
        {
            string path = Application.StartupPath;

            Customers.ParseMappingFile(path);

            Items.ParseMappingFile(path);

            lblMappings.Text = string.Format("Mappings: Parsed {0} Customer mappings and {1} Item mappings from \"{2}\".", Customers.Mapping.Count, Items.Mapping.Count, path);
        }

        /// <summary>
        /// Import all Sales LineItems CSVs in a folder
        /// </summary>
        private void ImportSales()
        {
            // Select Folder
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "Select folder for your SALES CSV files";
            folderBrowserDialog.SelectedPath = Application.StartupPath;
            folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
            {
                Application.Exit();
                return;
            }

            // Parse all Sales Files
            string[] filenames = Directory.GetFiles(folderBrowserDialog.SelectedPath, "*.csv");
            foreach (string filename in filenames)
            {
                Sales.ParseCSV(filename);
            }

            lblSales.Text = string.Format("Sales: Parsed {0} Sales files from \"{1}\" : {2:n0} Invoices, {3:n0} Credits, {4:n0} Skipped", filenames.Length, folderBrowserDialog.SelectedPath, Sales.Invoices.Count, Sales.Credits.Count, Sales.Skipped.Count);

            // Show unmapped Customers & Items
            fillUnmappedCustomers();
            fillUnmappedItems();
        }

        /// <summary>
        /// fill lstUnmappedNames
        /// </summary>
        private void fillUnmappedCustomers()
        {
            string[] unmappedNames = Customers.Unmapped.ToArray();
            Array.Sort(unmappedNames);
            lstUnmappedCustomers.Items.Clear();
            lstUnmappedCustomers.Items.AddRange(unmappedNames);
        }

        /// <summary>
        /// fill lstUnmappedItems
        /// </summary>
        private void fillUnmappedItems()
        {
            string[] unmappedItems = Items.Unmapped.ToArray();
            Array.Sort(unmappedItems);
            lstUnmappedItems.Items.Clear();
            lstUnmappedItems.Items.AddRange(unmappedItems);
        }
    }
}
