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
        }


        // Methods

        /// <summary>
        /// prompts for path to mapping files then parses them
        /// </summary>
        private void LoadMappings()
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "Select folder for your mapping CSV files";
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuImportSalesCSV_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            ofd.RestoreDirectory = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Cursor.Current = Cursors.WaitCursor;

                // parse CSV
                DateTime start = DateTime.Now;
                stsInfo.Text = string.Format("Reading {0}", ofd.FileName);
                Sales.ParseCSV(ofd.FileName);
                stsInfo.Text = string.Format("{0} parsed in {1} seconds", ofd.FileName, DateTime.Now - start);
                Application.DoEvents(); // update the Status Bar before continuing
                Cursor.Current = Cursors.WaitCursor;

                fillLineItems();

                // fill Skipped lines
                lblSkipped.Text = string.Format("{0:n0} Skipped", Sales.Skipped.Count);
                lstSkipped.Items.AddRange(Sales.Skipped.ToArray());

                fillUnmappedNames();

                fillUnmappedItems();

                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// clears & refills lstInvoices & lstCredits
        /// </summary>
        private void fillLineItems()
        {
            // fill Invoices
            lstInvoices.Items.Clear();
            lblInvoices.Text = string.Format("{0:n0} Invoices", Sales.Invoices.Count);
            lstInvoices.Items.AddRange(Sales.Invoices.ToArray());

            // fill Credits
            lstCredits.Items.Clear();
            lblCredits.Text = string.Format("{0:n0} Credits", Sales.Credits.Count);
            lstCredits.Items.AddRange(Sales.Credits.ToArray());
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
