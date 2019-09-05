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
        // Constants
        private const string ALL = "All";
        private const string YTD = "YTD";
        private const string LY = "Last Year";
        private const string QTD = "QTD";
        private const string LQ = "Last Quarter";
        private const string MTD = "MTD";
        private const string LM = "Last Month";
        private const string CUSTOM = "Custom";


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

            cmbDateRange.Items.AddRange(new object[]
                {
                    ALL,
                    YTD,
                    QTD,
                    LY,
                    LQ,
                    CUSTOM
                });

            datFrom.Value = new DateTime(DateTime.Now.Year, 1, 1);
        }


        // Events
        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (!LoadMappings())
            {
                Application.Exit();
            }

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
            web.Url = null;
            ImportSales();
        }


        // Methods

        /// <summary>
        /// Parse mapping files
        /// </summary>
        private bool LoadMappings()
        {
            try
            {
                string path = Application.StartupPath;

                Customers.ParseMappingFile(path);

                Items.ParseMappingFile(path);

                lblMappings.Text = string.Format("Mappings: Parsed {0} Customer mappings and {1} Item mappings from \"{2}\".", Customers.Mapping.Count, Items.Mapping.Count, path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed to load Mappings", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Import all Sales LineItems CSVs in a folder
        /// </summary>
        private void ImportSales()
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed to import Sales", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

            int firstMonthOfQuarter;
            if (DateTime.Now.Month <= 3)
                firstMonthOfQuarter = 1;
            else if (DateTime.Now.Month <= 6)
                firstMonthOfQuarter = 4;
            else if (DateTime.Now.Month <= 9)
                firstMonthOfQuarter = 7;
            else
                firstMonthOfQuarter = 10;

            try
            {
                switch (cmbDateRange.SelectedItem)
                {
                    case ALL:
                        datFrom.Value = Sales.MinDate;
                        datTo.Value = Sales.MaxDate;
                        break;
                    case YTD:
                        datFrom.Value = new DateTime(DateTime.Now.Year, 1, 1);
                        datTo.Value = Sales.MaxDate;
                        break;
                    case LY:
                        datFrom.Value = new DateTime(DateTime.Now.Year, 1, 1).AddYears(-1);
                        datTo.Value = Sales.MaxDate;
                        break;
                    case QTD:
                        datFrom.Value = new DateTime(DateTime.Now.Year, firstMonthOfQuarter, 1);
                        datTo.Value = Sales.MaxDate;
                        break;
                    case LQ:
                        datFrom.Value = new DateTime(DateTime.Now.Year, firstMonthOfQuarter, 1).AddMonths(-3);
                        datTo.Value = Sales.MaxDate;
                        break;
                    case MTD:
                        datFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                        datTo.Value = Sales.MaxDate;
                        break;
                    case LM:
                        datFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-1);
                        datTo.Value = Sales.MaxDate;
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
            try
            {
                Report report = new Report(Sales, radCustomer.Checked, chkDetailed.Checked, datFrom.Value, datTo.Value);
                ReportPath = report.Path;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed to generate HTML report", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenerateCSV_Click(object sender, EventArgs e)
        {
            try
            {
                CSV csv = new CSV(Sales, radCustomer.Checked, chkDetailed.Checked, datFrom.Value, datTo.Value);
                lblReportPath.Text = csv.Path;
                web.Url = null;
                btnOpenReport.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed to generate CSV report", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
