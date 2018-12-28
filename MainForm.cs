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


        // Properties
        private string ReportPath
        {
            set
            {
                lblReportPath.Text = value;
                web.Url = new Uri(value);
                btnOpenReport.Enabled = true;
            }
        }


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

        private void mnuReloadMappings_Click(object sender, EventArgs e)
        {
            Sales = null;
            lblSales.Text = lblReportPath.Text = string.Empty;
            lstUnmappedCustomers.Items.Clear();
            lstUnmappedItems.Items.Clear();
            web.Url = null;
            LoadMappings();
        }

        private void mnuImportSales_Click(object sender, EventArgs e)
        {
            datFrom.MinDate = datTo.MinDate = DateTimePicker.MinDateTime;
            datFrom.MaxDate = datTo.MaxDate = DateTimePicker.MaxDateTime;
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

            // set Date Range
            cmbDateRange.SelectedItem = "All";
            datFrom.MinDate = datTo.MinDate = Sales.MinDate;
            datFrom.MaxDate = datTo.MaxDate = Sales.MaxDate;
            datFrom.Value = Sales.MinDate;
            datTo.Value = Sales.MaxDate;
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
        /// cmbDateRange selection
        /// </summary>
        private void cmbDateRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            datFrom.Enabled = datTo.Enabled = (string)cmbDateRange.SelectedItem == "Custom";

            try
            {
                switch (cmbDateRange.SelectedItem)
                {
                    case "All":
                        datFrom.Value = Sales.MinDate;
                        datTo.Value = Sales.MaxDate;
                        break;
                    case "YTD":
                        datFrom.Value = new DateTime(DateTime.Now.Year, 1, 1);
                        datTo.Value = DateTime.Now;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid Date Range for the imported Sales");
                cmbDateRange.SelectedItem = "All";
            }
        }

        /// <summary>
        /// Generate Report
        /// </summary>
        private void btnGeneratReport_Click(object sender, EventArgs e)
        {
            Report report = new Report(Sales, radCustomer.Checked, chkDetailed.Checked, datFrom.Value, datTo.Value);
            ReportPath = report.Path;
        }

        /// <summary>
        /// Open Report in Browser
        /// </summary>
        private void btnOpenReport_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(lblReportPath.Text);
        }
    }
}
