﻿namespace QuickBooksReporting
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
            this.btnGenerate = new System.Windows.Forms.Button();
            this.chkDetailed = new System.Windows.Forms.CheckBox();
            this.radItem = new System.Windows.Forms.RadioButton();
            this.radCustomer = new System.Windows.Forms.RadioButton();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
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
            this.lblUnmappedCustomers.TabIndex = 8;
            this.lblUnmappedCustomers.Text = "Unmapped Customers";
            // 
            // lstUnmappedCustomers
            // 
            this.lstUnmappedCustomers.Location = new System.Drawing.Point(12, 42);
            this.lstUnmappedCustomers.Name = "lstUnmappedCustomers";
            this.lstUnmappedCustomers.Size = new System.Drawing.Size(190, 134);
            this.lstUnmappedCustomers.TabIndex = 17;
            // 
            // lblItems
            // 
            this.lblItems.AutoSize = true;
            this.lblItems.Location = new System.Drawing.Point(9, 179);
            this.lblItems.Name = "lblItems";
            this.lblItems.Size = new System.Drawing.Size(87, 13);
            this.lblItems.TabIndex = 10;
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
            this.lstUnmappedItems.TabIndex = 14;
            // 
            // lblMappings
            // 
            this.lblMappings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMappings.AutoSize = true;
            this.lblMappings.Location = new System.Drawing.Point(12, 432);
            this.lblMappings.Name = "lblMappings";
            this.lblMappings.Size = new System.Drawing.Size(59, 13);
            this.lblMappings.TabIndex = 15;
            this.lblMappings.Text = "Mappings: ";
            // 
            // lblSales
            // 
            this.lblSales.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSales.AutoSize = true;
            this.lblSales.Location = new System.Drawing.Point(12, 449);
            this.lblSales.Name = "lblSales";
            this.lblSales.Size = new System.Drawing.Size(39, 13);
            this.lblSales.TabIndex = 16;
            this.lblSales.Text = "Sales: ";
            // 
            // grpReport
            // 
            this.grpReport.Controls.Add(this.btnGenerate);
            this.grpReport.Controls.Add(this.chkDetailed);
            this.grpReport.Controls.Add(this.radItem);
            this.grpReport.Controls.Add(this.radCustomer);
            this.grpReport.Controls.Add(this.lblTo);
            this.grpReport.Controls.Add(this.lblFrom);
            this.grpReport.Controls.Add(this.dateTimePicker2);
            this.grpReport.Controls.Add(this.datFrom);
            this.grpReport.Location = new System.Drawing.Point(228, 42);
            this.grpReport.Name = "grpReport";
            this.grpReport.Size = new System.Drawing.Size(309, 168);
            this.grpReport.TabIndex = 18;
            this.grpReport.TabStop = false;
            this.grpReport.Text = "Report";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(9, 132);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 7;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // chkDetailed
            // 
            this.chkDetailed.AutoSize = true;
            this.chkDetailed.Location = new System.Drawing.Point(10, 103);
            this.chkDetailed.Name = "chkDetailed";
            this.chkDetailed.Size = new System.Drawing.Size(65, 17);
            this.chkDetailed.TabIndex = 6;
            this.chkDetailed.Text = "Detailed";
            this.chkDetailed.UseVisualStyleBackColor = true;
            // 
            // radItem
            // 
            this.radItem.AutoSize = true;
            this.radItem.Location = new System.Drawing.Point(85, 80);
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
            this.radCustomer.Location = new System.Drawing.Point(10, 80);
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
            this.lblTo.Location = new System.Drawing.Point(7, 51);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(23, 13);
            this.lblTo.TabIndex = 3;
            this.lblTo.Text = "To:";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(6, 25);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(33, 13);
            this.lblFrom.TabIndex = 2;
            this.lblFrom.Text = "From:";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(103, 45);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 1;
            // 
            // datFrom
            // 
            this.datFrom.Location = new System.Drawing.Point(103, 19);
            this.datFrom.Name = "datFrom";
            this.datFrom.Size = new System.Drawing.Size(200, 20);
            this.datFrom.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 471);
            this.Controls.Add(this.grpReport);
            this.Controls.Add(this.lblSales);
            this.Controls.Add(this.lblMappings);
            this.Controls.Add(this.lstUnmappedItems);
            this.Controls.Add(this.lblItems);
            this.Controls.Add(this.lblUnmappedCustomers);
            this.Controls.Add(this.lstUnmappedCustomers);
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
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker datFrom;
        private System.Windows.Forms.CheckBox chkDetailed;
        private System.Windows.Forms.Button btnGenerate;
    }
}

