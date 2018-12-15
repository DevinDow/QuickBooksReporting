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
        public Form1()
        {
            InitializeComponent();
        }

        private void mnuImportSalesCSV_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            ofd.RestoreDirectory = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                List<LineItem> invoices = new List<LineItem>();
                List<LineItem> nonInvoices = new List<LineItem>();
                foreach (string line in File.ReadLines(ofd.FileName, Encoding.UTF8))
                {
                    string[] fields = line.Split(',');
                    LineItem lineItem = new LineItem(fields);
                    if (lineItem.type == "Invoice")
                    {
                        invoices.Add(lineItem);
                    }
                    else
                    {
                        nonInvoices.Add(lineItem);
                    }
                }
                MessageBox.Show(string.Format("Read {0} Invoices and {1} non-Invoices", invoices.Count, nonInvoices.Count));
            }
        }
    }
}
