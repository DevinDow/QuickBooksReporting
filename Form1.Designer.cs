namespace QuickBooksReporting
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuImportSalesCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.lstSkipped = new System.Windows.Forms.ListBox();
            this.lblSkipped = new System.Windows.Forms.Label();
            this.lblCredits = new System.Windows.Forms.Label();
            this.lstCredits = new System.Windows.Forms.ListBox();
            this.lblInvoices = new System.Windows.Forms.Label();
            this.lstInvoices = new System.Windows.Forms.ListBox();
            this.lblNonInvoices = new System.Windows.Forms.Label();
            this.lblNames = new System.Windows.Forms.Label();
            this.lstNames = new System.Windows.Forms.ListBox();
            this.lblItems = new System.Windows.Forms.Label();
            this.lstItems = new System.Windows.Forms.ListBox();
            this.status = new System.Windows.Forms.StatusStrip();
            this.stsInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.status.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuImportSalesCSV});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1026, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuImportSalesCSV
            // 
            this.mnuImportSalesCSV.Name = "mnuImportSalesCSV";
            this.mnuImportSalesCSV.Size = new System.Drawing.Size(108, 20);
            this.mnuImportSalesCSV.Text = "Import &Sales CSV";
            this.mnuImportSalesCSV.Click += new System.EventHandler(this.mnuImportSalesCSV_Click);
            // 
            // lstSkipped
            // 
            this.lstSkipped.FormattingEnabled = true;
            this.lstSkipped.IntegralHeight = false;
            this.lstSkipped.Location = new System.Drawing.Point(12, 419);
            this.lstSkipped.Name = "lstSkipped";
            this.lstSkipped.Size = new System.Drawing.Size(658, 79);
            this.lstSkipped.TabIndex = 1;
            // 
            // lblSkipped
            // 
            this.lblSkipped.AutoSize = true;
            this.lblSkipped.Location = new System.Drawing.Point(9, 403);
            this.lblSkipped.Name = "lblSkipped";
            this.lblSkipped.Size = new System.Drawing.Size(46, 13);
            this.lblSkipped.TabIndex = 2;
            this.lblSkipped.Text = "Skipped";
            // 
            // lblCredits
            // 
            this.lblCredits.AutoSize = true;
            this.lblCredits.Location = new System.Drawing.Point(9, 276);
            this.lblCredits.Name = "lblCredits";
            this.lblCredits.Size = new System.Drawing.Size(39, 13);
            this.lblCredits.TabIndex = 4;
            this.lblCredits.Text = "Credits";
            // 
            // lstCredits
            // 
            this.lstCredits.FormattingEnabled = true;
            this.lstCredits.IntegralHeight = false;
            this.lstCredits.Location = new System.Drawing.Point(12, 292);
            this.lstCredits.Name = "lstCredits";
            this.lstCredits.Size = new System.Drawing.Size(658, 108);
            this.lstCredits.TabIndex = 3;
            // 
            // lblInvoices
            // 
            this.lblInvoices.AutoSize = true;
            this.lblInvoices.Location = new System.Drawing.Point(9, 32);
            this.lblInvoices.Name = "lblInvoices";
            this.lblInvoices.Size = new System.Drawing.Size(47, 13);
            this.lblInvoices.TabIndex = 6;
            this.lblInvoices.Text = "Invoices";
            // 
            // lstInvoices
            // 
            this.lstInvoices.FormattingEnabled = true;
            this.lstInvoices.IntegralHeight = false;
            this.lstInvoices.Location = new System.Drawing.Point(12, 48);
            this.lstInvoices.Name = "lstInvoices";
            this.lstInvoices.Size = new System.Drawing.Size(658, 225);
            this.lstInvoices.TabIndex = 5;
            // 
            // lblNonInvoices
            // 
            this.lblNonInvoices.AutoSize = true;
            this.lblNonInvoices.Location = new System.Drawing.Point(9, 310);
            this.lblNonInvoices.Name = "lblNonInvoices";
            this.lblNonInvoices.Size = new System.Drawing.Size(68, 13);
            this.lblNonInvoices.TabIndex = 2;
            this.lblNonInvoices.Text = "non-Invoices";
            // 
            // lblNames
            // 
            this.lblNames.AutoSize = true;
            this.lblNames.Location = new System.Drawing.Point(673, 32);
            this.lblNames.Name = "lblNames";
            this.lblNames.Size = new System.Drawing.Size(77, 13);
            this.lblNames.TabIndex = 8;
            this.lblNames.Text = "Unique Names";
            // 
            // lstNames
            // 
            this.lstNames.FormattingEnabled = true;
            this.lstNames.IntegralHeight = false;
            this.lstNames.Location = new System.Drawing.Point(676, 48);
            this.lstNames.Name = "lstNames";
            this.lstNames.Size = new System.Drawing.Size(338, 125);
            this.lstNames.TabIndex = 7;
            // 
            // lblItems
            // 
            this.lblItems.AutoSize = true;
            this.lblItems.Location = new System.Drawing.Point(673, 184);
            this.lblItems.Name = "lblItems";
            this.lblItems.Size = new System.Drawing.Size(69, 13);
            this.lblItems.TabIndex = 10;
            this.lblItems.Text = "Unique Items";
            // 
            // lstItems
            // 
            this.lstItems.FormattingEnabled = true;
            this.lstItems.IntegralHeight = false;
            this.lstItems.Location = new System.Drawing.Point(676, 200);
            this.lstItems.Name = "lstItems";
            this.lstItems.Size = new System.Drawing.Size(338, 125);
            this.lstItems.TabIndex = 9;
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stsInfo});
            this.status.Location = new System.Drawing.Point(0, 508);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(1026, 22);
            this.status.TabIndex = 11;
            // 
            // stsInfo
            // 
            this.stsInfo.Name = "stsInfo";
            this.stsInfo.Size = new System.Drawing.Size(0, 17);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 530);
            this.Controls.Add(this.status);
            this.Controls.Add(this.lblItems);
            this.Controls.Add(this.lstItems);
            this.Controls.Add(this.lblNames);
            this.Controls.Add(this.lstNames);
            this.Controls.Add(this.lblInvoices);
            this.Controls.Add(this.lstInvoices);
            this.Controls.Add(this.lblCredits);
            this.Controls.Add(this.lstCredits);
            this.Controls.Add(this.lblSkipped);
            this.Controls.Add(this.lstSkipped);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuImportSalesCSV;
        private System.Windows.Forms.ListBox lstSkipped;
        private System.Windows.Forms.Label lblNonInvoices;
        private System.Windows.Forms.Label lblCredits;
        private System.Windows.Forms.ListBox lstCredits;
        private System.Windows.Forms.Label lblInvoices;
        private System.Windows.Forms.ListBox lstInvoices;
        private System.Windows.Forms.Label lblSkipped;
        private System.Windows.Forms.Label lblNames;
        private System.Windows.Forms.ListBox lstNames;
        private System.Windows.Forms.Label lblItems;
        private System.Windows.Forms.ListBox lstItems;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ToolStripStatusLabel stsInfo;
    }
}

