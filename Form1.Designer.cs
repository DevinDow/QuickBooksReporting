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
            this.mnuNormalizeNames = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNormalizeItems = new System.Windows.Forms.ToolStripMenuItem();
            this.lstSkipped = new System.Windows.Forms.ListBox();
            this.lblSkipped = new System.Windows.Forms.Label();
            this.lblCredits = new System.Windows.Forms.Label();
            this.lstCredits = new System.Windows.Forms.ListBox();
            this.lblInvoices = new System.Windows.Forms.Label();
            this.lstInvoices = new System.Windows.Forms.ListBox();
            this.lblNonInvoices = new System.Windows.Forms.Label();
            this.lblNames = new System.Windows.Forms.Label();
            this.lstUnmappedNames = new System.Windows.Forms.ListBox();
            this.lblItems = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.StatusStrip();
            this.stsInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.lstMappedNames = new System.Windows.Forms.ListBox();
            this.lstUnmappedItems = new System.Windows.Forms.ListBox();
            this.lstMappedItems = new System.Windows.Forms.ListBox();
            this.lblMappedItems = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.status.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuImportSalesCSV,
            this.mnuNormalizeNames,
            this.mnuNormalizeItems});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1229, 24);
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
            // mnuNormalizeNames
            // 
            this.mnuNormalizeNames.Name = "mnuNormalizeNames";
            this.mnuNormalizeNames.Size = new System.Drawing.Size(113, 20);
            this.mnuNormalizeNames.Text = "Normalize &Names";
            this.mnuNormalizeNames.Click += new System.EventHandler(this.mnuNormalizeNames_Click);
            // 
            // mnuNormalizeItems
            // 
            this.mnuNormalizeItems.Name = "mnuNormalizeItems";
            this.mnuNormalizeItems.Size = new System.Drawing.Size(105, 20);
            this.mnuNormalizeItems.Text = "Normalize &Items";
            this.mnuNormalizeItems.Click += new System.EventHandler(this.mnuNormalizeItems_Click);
            // 
            // lstSkipped
            // 
            this.lstSkipped.FormattingEnabled = true;
            this.lstSkipped.HorizontalScrollbar = true;
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
            this.lstCredits.HorizontalScrollbar = true;
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
            this.lstInvoices.HorizontalScrollbar = true;
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
            this.lblNames.Size = new System.Drawing.Size(95, 13);
            this.lblNames.TabIndex = 8;
            this.lblNames.Text = "Unmapped Names";
            // 
            // lstUnmappedNames
            // 
            this.lstUnmappedNames.FormattingEnabled = true;
            this.lstUnmappedNames.HorizontalScrollbar = true;
            this.lstUnmappedNames.IntegralHeight = false;
            this.lstUnmappedNames.Location = new System.Drawing.Point(676, 48);
            this.lstUnmappedNames.Name = "lstUnmappedNames";
            this.lstUnmappedNames.Size = new System.Drawing.Size(190, 125);
            this.lstUnmappedNames.TabIndex = 7;
            // 
            // lblItems
            // 
            this.lblItems.AutoSize = true;
            this.lblItems.Location = new System.Drawing.Point(673, 184);
            this.lblItems.Name = "lblItems";
            this.lblItems.Size = new System.Drawing.Size(87, 13);
            this.lblItems.TabIndex = 10;
            this.lblItems.Text = "Unmapped Items";
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stsInfo});
            this.status.Location = new System.Drawing.Point(0, 508);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(1229, 22);
            this.status.TabIndex = 11;
            // 
            // stsInfo
            // 
            this.stsInfo.Name = "stsInfo";
            this.stsInfo.Size = new System.Drawing.Size(0, 17);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(869, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Mapped Names";
            // 
            // lstMappedNames
            // 
            this.lstMappedNames.FormattingEnabled = true;
            this.lstMappedNames.HorizontalScrollbar = true;
            this.lstMappedNames.IntegralHeight = false;
            this.lstMappedNames.Location = new System.Drawing.Point(872, 48);
            this.lstMappedNames.Name = "lstMappedNames";
            this.lstMappedNames.Size = new System.Drawing.Size(346, 125);
            this.lstMappedNames.TabIndex = 12;
            // 
            // lstUnmappedItems
            // 
            this.lstUnmappedItems.FormattingEnabled = true;
            this.lstUnmappedItems.HorizontalScrollbar = true;
            this.lstUnmappedItems.IntegralHeight = false;
            this.lstUnmappedItems.Location = new System.Drawing.Point(676, 200);
            this.lstUnmappedItems.Name = "lstUnmappedItems";
            this.lstUnmappedItems.Size = new System.Drawing.Size(190, 298);
            this.lstUnmappedItems.TabIndex = 14;
            // 
            // lstMappedItems
            // 
            this.lstMappedItems.FormattingEnabled = true;
            this.lstMappedItems.HorizontalScrollbar = true;
            this.lstMappedItems.IntegralHeight = false;
            this.lstMappedItems.Location = new System.Drawing.Point(872, 200);
            this.lstMappedItems.Name = "lstMappedItems";
            this.lstMappedItems.Size = new System.Drawing.Size(345, 298);
            this.lstMappedItems.TabIndex = 16;
            // 
            // lblMappedItems
            // 
            this.lblMappedItems.AutoSize = true;
            this.lblMappedItems.Location = new System.Drawing.Point(869, 184);
            this.lblMappedItems.Name = "lblMappedItems";
            this.lblMappedItems.Size = new System.Drawing.Size(74, 13);
            this.lblMappedItems.TabIndex = 15;
            this.lblMappedItems.Text = "Mapped Items";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1229, 530);
            this.Controls.Add(this.lstMappedItems);
            this.Controls.Add(this.lblMappedItems);
            this.Controls.Add(this.lstUnmappedItems);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstMappedNames);
            this.Controls.Add(this.status);
            this.Controls.Add(this.lblItems);
            this.Controls.Add(this.lblNames);
            this.Controls.Add(this.lstUnmappedNames);
            this.Controls.Add(this.lblInvoices);
            this.Controls.Add(this.lstInvoices);
            this.Controls.Add(this.lblCredits);
            this.Controls.Add(this.lstCredits);
            this.Controls.Add(this.lblSkipped);
            this.Controls.Add(this.lstSkipped);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "QuickBooks Reporting";
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
        private System.Windows.Forms.Label lblItems;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ToolStripStatusLabel stsInfo;
        private System.Windows.Forms.ToolStripMenuItem mnuNormalizeNames;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstMappedNames;
        private System.Windows.Forms.ListBox lstUnmappedNames;
        private System.Windows.Forms.ToolStripMenuItem mnuNormalizeItems;
        private System.Windows.Forms.ListBox lstUnmappedItems;
        private System.Windows.Forms.ListBox lstMappedItems;
        private System.Windows.Forms.Label lblMappedItems;
    }
}

