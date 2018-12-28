namespace QuickBooksReporting
{
    partial class MainForm
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
            this.menu = new System.Windows.Forms.MenuStrip();
            this.lblNonInvoices = new System.Windows.Forms.Label();
            this.lblUnmappedCustomers = new System.Windows.Forms.Label();
            this.lstUnmappedCustomers = new System.Windows.Forms.ListBox();
            this.lblItems = new System.Windows.Forms.Label();
            this.lstUnmappedItems = new System.Windows.Forms.ListBox();
            this.lblMappings = new System.Windows.Forms.Label();
            this.lblSales = new System.Windows.Forms.Label();
            this.grpReport = new System.Windows.Forms.GroupBox();
            this.cmbDateRange = new System.Windows.Forms.ComboBox();
            this.lblDateRange = new System.Windows.Forms.Label();
            this.web = new System.Windows.Forms.WebBrowser();
            this.btnOpenReport = new System.Windows.Forms.Button();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.lblReportPath = new System.Windows.Forms.Label();
            this.chkDetailed = new System.Windows.Forms.CheckBox();
            this.radItem = new System.Windows.Forms.RadioButton();
            this.radCustomer = new System.Windows.Forms.RadioButton();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.datTo = new System.Windows.Forms.DateTimePicker();
            this.datFrom = new System.Windows.Forms.DateTimePicker();
            this.grpReport.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(802, 24);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
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
            // lblUnmappedCustomers
            // 
            this.lblUnmappedCustomers.AutoSize = true;
            this.lblUnmappedCustomers.Location = new System.Drawing.Point(9, 27);
            this.lblUnmappedCustomers.Name = "lblUnmappedCustomers";
            this.lblUnmappedCustomers.Size = new System.Drawing.Size(111, 13);
            this.lblUnmappedCustomers.TabIndex = 1;
            this.lblUnmappedCustomers.Text = "Unmapped Customers";
            // 
            // lstUnmappedCustomers
            // 
            this.lstUnmappedCustomers.Location = new System.Drawing.Point(12, 42);
            this.lstUnmappedCustomers.Name = "lstUnmappedCustomers";
            this.lstUnmappedCustomers.Size = new System.Drawing.Size(190, 134);
            this.lstUnmappedCustomers.TabIndex = 2;
            // 
            // lblItems
            // 
            this.lblItems.AutoSize = true;
            this.lblItems.Location = new System.Drawing.Point(9, 179);
            this.lblItems.Name = "lblItems";
            this.lblItems.Size = new System.Drawing.Size(87, 13);
            this.lblItems.TabIndex = 3;
            this.lblItems.Text = "Unmapped Items";
            // 
            // lstUnmappedItems
            // 
            this.lstUnmappedItems.FormattingEnabled = true;
            this.lstUnmappedItems.HorizontalScrollbar = true;
            this.lstUnmappedItems.IntegralHeight = false;
            this.lstUnmappedItems.Location = new System.Drawing.Point(12, 195);
            this.lstUnmappedItems.Name = "lstUnmappedItems";
            this.lstUnmappedItems.Size = new System.Drawing.Size(190, 223);
            this.lstUnmappedItems.TabIndex = 4;
            // 
            // lblMappings
            // 
            this.lblMappings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMappings.AutoSize = true;
            this.lblMappings.Location = new System.Drawing.Point(12, 432);
            this.lblMappings.Name = "lblMappings";
            this.lblMappings.Size = new System.Drawing.Size(59, 13);
            this.lblMappings.TabIndex = 5;
            this.lblMappings.Text = "Mappings: ";
            // 
            // lblSales
            // 
            this.lblSales.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSales.AutoSize = true;
            this.lblSales.Location = new System.Drawing.Point(12, 449);
            this.lblSales.Name = "lblSales";
            this.lblSales.Size = new System.Drawing.Size(39, 13);
            this.lblSales.TabIndex = 6;
            this.lblSales.Text = "Sales: ";
            // 
            // grpReport
            // 
            this.grpReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpReport.Controls.Add(this.cmbDateRange);
            this.grpReport.Controls.Add(this.lblDateRange);
            this.grpReport.Controls.Add(this.web);
            this.grpReport.Controls.Add(this.btnOpenReport);
            this.grpReport.Controls.Add(this.btnGenerateReport);
            this.grpReport.Controls.Add(this.lblReportPath);
            this.grpReport.Controls.Add(this.chkDetailed);
            this.grpReport.Controls.Add(this.radItem);
            this.grpReport.Controls.Add(this.radCustomer);
            this.grpReport.Controls.Add(this.lblTo);
            this.grpReport.Controls.Add(this.lblFrom);
            this.grpReport.Controls.Add(this.datTo);
            this.grpReport.Controls.Add(this.datFrom);
            this.grpReport.Location = new System.Drawing.Point(228, 42);
            this.grpReport.Name = "grpReport";
            this.grpReport.Size = new System.Drawing.Size(562, 388);
            this.grpReport.TabIndex = 7;
            this.grpReport.TabStop = false;
            this.grpReport.Text = "Report";
            // 
            // cmbDateRange
            // 
            this.cmbDateRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDateRange.FormattingEnabled = true;
            this.cmbDateRange.Items.AddRange(new object[] {
            "All",
            "YTD",
            "Custom"});
            this.cmbDateRange.Location = new System.Drawing.Point(81, 17);
            this.cmbDateRange.Name = "cmbDateRange";
            this.cmbDateRange.Size = new System.Drawing.Size(121, 21);
            this.cmbDateRange.TabIndex = 12;
            this.cmbDateRange.SelectedIndexChanged += new System.EventHandler(this.cmbDateRange_SelectedIndexChanged);
            // 
            // lblDateRange
            // 
            this.lblDateRange.AutoSize = true;
            this.lblDateRange.Location = new System.Drawing.Point(7, 20);
            this.lblDateRange.Name = "lblDateRange";
            this.lblDateRange.Size = new System.Drawing.Size(68, 13);
            this.lblDateRange.TabIndex = 11;
            this.lblDateRange.Text = "Date Range:";
            // 
            // web
            // 
            this.web.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.web.Location = new System.Drawing.Point(6, 117);
            this.web.MinimumSize = new System.Drawing.Size(20, 20);
            this.web.Name = "web";
            this.web.Size = new System.Drawing.Size(550, 265);
            this.web.TabIndex = 10;
            // 
            // btnOpenReport
            // 
            this.btnOpenReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenReport.Enabled = false;
            this.btnOpenReport.Location = new System.Drawing.Point(451, 88);
            this.btnOpenReport.Name = "btnOpenReport";
            this.btnOpenReport.Size = new System.Drawing.Size(105, 23);
            this.btnOpenReport.TabIndex = 9;
            this.btnOpenReport.Text = "Open in Browser";
            this.btnOpenReport.UseVisualStyleBackColor = true;
            this.btnOpenReport.Click += new System.EventHandler(this.btnOpenReport_Click);
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.Location = new System.Drawing.Point(363, 22);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(102, 23);
            this.btnGenerateReport.TabIndex = 7;
            this.btnGenerateReport.Text = "Generate Report";
            this.btnGenerateReport.UseVisualStyleBackColor = true;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGeneratReport_Click);
            // 
            // lblReportPath
            // 
            this.lblReportPath.AutoSize = true;
            this.lblReportPath.Location = new System.Drawing.Point(7, 98);
            this.lblReportPath.Name = "lblReportPath";
            this.lblReportPath.Size = new System.Drawing.Size(81, 13);
            this.lblReportPath.TabIndex = 8;
            this.lblReportPath.Text = "Report filename";
            // 
            // chkDetailed
            // 
            this.chkDetailed.AutoSize = true;
            this.chkDetailed.Location = new System.Drawing.Point(269, 68);
            this.chkDetailed.Name = "chkDetailed";
            this.chkDetailed.Size = new System.Drawing.Size(65, 17);
            this.chkDetailed.TabIndex = 6;
            this.chkDetailed.Text = "Detailed";
            this.chkDetailed.UseVisualStyleBackColor = true;
            // 
            // radItem
            // 
            this.radItem.AutoSize = true;
            this.radItem.Location = new System.Drawing.Point(269, 45);
            this.radItem.Name = "radItem";
            this.radItem.Size = new System.Drawing.Size(45, 17);
            this.radItem.TabIndex = 5;
            this.radItem.TabStop = true;
            this.radItem.Text = "Item";
            this.radItem.UseVisualStyleBackColor = true;
            // 
            // radCustomer
            // 
            this.radCustomer.AutoSize = true;
            this.radCustomer.Checked = true;
            this.radCustomer.Location = new System.Drawing.Point(269, 22);
            this.radCustomer.Name = "radCustomer";
            this.radCustomer.Size = new System.Drawing.Size(69, 17);
            this.radCustomer.TabIndex = 4;
            this.radCustomer.TabStop = true;
            this.radCustomer.Text = "Customer";
            this.radCustomer.UseVisualStyleBackColor = true;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(7, 74);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(23, 13);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "To:";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(6, 48);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(33, 13);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "From:";
            // 
            // datTo
            // 
            this.datTo.Enabled = false;
            this.datTo.Location = new System.Drawing.Point(45, 70);
            this.datTo.Name = "datTo";
            this.datTo.Size = new System.Drawing.Size(200, 20);
            this.datTo.TabIndex = 3;
            // 
            // datFrom
            // 
            this.datFrom.Enabled = false;
            this.datFrom.Location = new System.Drawing.Point(45, 44);
            this.datFrom.Name = "datFrom";
            this.datFrom.Size = new System.Drawing.Size(200, 20);
            this.datFrom.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 471);
            this.Controls.Add(this.lstUnmappedItems);
            this.Controls.Add(this.lblItems);
            this.Controls.Add(this.lblUnmappedCustomers);
            this.Controls.Add(this.lstUnmappedCustomers);
            this.Controls.Add(this.grpReport);
            this.Controls.Add(this.lblSales);
            this.Controls.Add(this.lblMappings);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QuickBooks Reporting";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.grpReport.ResumeLayout(false);
            this.grpReport.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.Label lblNonInvoices;
        private System.Windows.Forms.Label lblUnmappedCustomers;
        private System.Windows.Forms.Label lblItems;
        private System.Windows.Forms.ListBox lstUnmappedCustomers;
        private System.Windows.Forms.ListBox lstUnmappedItems;
        private System.Windows.Forms.Label lblMappings;
        private System.Windows.Forms.Label lblSales;
        private System.Windows.Forms.GroupBox grpReport;
        private System.Windows.Forms.RadioButton radItem;
        private System.Windows.Forms.RadioButton radCustomer;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker datTo;
        private System.Windows.Forms.DateTimePicker datFrom;
        private System.Windows.Forms.CheckBox chkDetailed;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.WebBrowser web;
        private System.Windows.Forms.Button btnOpenReport;
        private System.Windows.Forms.Label lblReportPath;
        private System.Windows.Forms.ComboBox cmbDateRange;
        private System.Windows.Forms.Label lblDateRange;
    }
}

