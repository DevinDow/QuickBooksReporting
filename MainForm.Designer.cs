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
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1046, 24);
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
            this.lblMappings.Location = new System.Drawing.Point(12, 491);
            this.lblMappings.Name = "lblMappings";
            this.lblMappings.Size = new System.Drawing.Size(59, 13);
            this.lblMappings.TabIndex = 15;
            this.lblMappings.Text = "Mappings: ";
            // 
            // lblSales
            // 
            this.lblSales.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSales.AutoSize = true;
            this.lblSales.Location = new System.Drawing.Point(12, 508);
            this.lblSales.Name = "lblSales";
            this.lblSales.Size = new System.Drawing.Size(39, 13);
            this.lblSales.TabIndex = 16;
            this.lblSales.Text = "Sales: ";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 530);
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
    }
}

