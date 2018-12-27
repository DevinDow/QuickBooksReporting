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
using System.Web.UI;
using System.Windows.Forms;

namespace QuickBooksReporting
{
    public partial class MainForm : Form
    {
        // Private Fields

        /// <summary>
        /// Sales object representing one CSV of Sales LineItems
        /// </summary>
        private Sales Sales;


        // Constructor
        public MainForm()
        {
            InitializeComponent();

            datFrom.Value = new DateTime(DateTime.Now.Year, 1, 1);
        }


        // Events
        private void MainForm_Shown(object sender, EventArgs e)
        {
            LoadMappings();

            ImportSales();
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

            Sales = new Sales(folderBrowserDialog.SelectedPath);

            lblSales.Text = string.Format("Sales: Parsed {0} Sales files from \"{1}\" : {2:n0} Invoices, {3:n0} Credits, {4:n0} Skipped", Sales.FileCount, folderBrowserDialog.SelectedPath, Sales.Invoices.Count, Sales.Credits.Count, Sales.Skipped.Count);

            // Show unmapped Customers & Items
            fillUnmappedCustomers();
            fillUnmappedItems();
        }

        /// <summary>
        /// fill lstUnmappedNames
        /// </summary>
        private void fillUnmappedCustomers()
        {
            string[] unmappedCustomers = Sales.UnmappedCustomers.ToArray();
            Array.Sort(unmappedCustomers);
            lstUnmappedCustomers.Items.Clear();
            lstUnmappedCustomers.Items.AddRange(unmappedCustomers);
        }

        /// <summary>
        /// fill lstUnmappedItems
        /// </summary>
        private void fillUnmappedItems()
        {
            string[] unmappedItems = Sales.UnmappedItems.ToArray();
            Array.Sort(unmappedItems);
            lstUnmappedItems.Items.Clear();
            lstUnmappedItems.Items.AddRange(unmappedItems);
        }

        /// <summary>
        /// Generate Report
        /// </summary>
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd HH-mm");
            string reportType = radCustomer.Checked ? "customer" : "item";
            string reportDetailed = chkDetailed.Checked ? "-detailed" : "";
            string filename = string.Format("{0} {1}{2}.html", date, reportType, reportDetailed);
            string path = Path.Combine(Sales.FolderPath, filename);

            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                using (HtmlTextWriter writer = new HtmlTextWriter(streamWriter))
                {
                    writer.WriteLine("Testing 1..2..3..");

                }
            }

            web.Url = new Uri(path);
        }
    }
}
