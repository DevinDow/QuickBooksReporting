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
                List<LineItem> credits = new List<LineItem>();
                List<string> skipped = new List<string>();
                foreach (string line in File.ReadLines(ofd.FileName, Encoding.UTF8))
                {
                    string[] fields = line.Split(',');
                    LineItem lineItem = new LineItem(fields);
                    if (lineItem.type == "Invoice")
                    {
                        invoices.Add(lineItem);
                    }
                    else if (lineItem.type == "Credit Memo")
                    {
                        credits.Add(lineItem);
                    }
                    else
                    {
                        skipped.Add(line);
                    }
                }

                lblInvoices.Text = string.Format("{0:n0} Invoices", invoices.Count);
                lstInvoices.Items.AddRange(invoices.ToArray());

                lblCredits.Text = string.Format("{0:n0} Credits", credits.Count);
                lstCredits.Items.AddRange(credits.ToArray());

                lblSkipped.Text = string.Format("{0:n0} Skipped", skipped.Count);
                lstSkipped.Items.AddRange(skipped.ToArray());
            }
        }
    }
}
