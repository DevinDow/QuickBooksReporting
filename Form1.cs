using System;
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
    public partial class Form1 : Form
    {
        // Private Fields
        private Sales Sales= new Sales();


        // Constructor
        public Form1()
        {
            InitializeComponent();
        }


        // Methods
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

                // fill Invoices
                lblInvoices.Text = string.Format("{0:n0} Invoices", Sales.Invoices.Count);
                lstInvoices.Items.AddRange(Sales.Invoices.ToArray());

                // fill Credits
                lblCredits.Text = string.Format("{0:n0} Credits", Sales.Credits.Count);
                lstCredits.Items.AddRange(Sales.Credits.ToArray());

                // fill Skipped
                lblSkipped.Text = string.Format("{0:n0} Skipped", Sales.Skipped.Count);
                lstSkipped.Items.AddRange(Sales.Skipped.ToArray());

                // fill unique Names
                lstNames.Items.AddRange(Sales.Names.Keys.ToArray());

                // fill unique Items
                lstItems.Items.AddRange(Sales.Items.Keys.ToArray());

                Cursor.Current = Cursors.Default;
            }
        }
    }
}
