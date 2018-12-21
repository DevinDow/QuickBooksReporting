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
            this.lblNames = new System.Windows.Forms.Label();
            this.lstUnmappedNames = new System.Windows.Forms.ListBox();
            this.lblItems = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.StatusStrip();
            this.stsInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.lstUnmappedItems = new System.Windows.Forms.ListBox();
            this.status.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(665, 24);
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
            // lblNames
            // 
            this.lblNames.AutoSize = true;
            this.lblNames.Location = new System.Drawing.Point(9, 27);
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
            this.lstUnmappedNames.Location = new System.Drawing.Point(12, 43);
            this.lstUnmappedNames.Name = "lstUnmappedNames";
            this.lstUnmappedNames.Size = new System.Drawing.Size(190, 125);
            this.lstUnmappedNames.TabIndex = 7;
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
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stsInfo});
            this.status.Location = new System.Drawing.Point(0, 508);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(665, 22);
            this.status.TabIndex = 11;
            // 
            // stsInfo
            // 
            this.stsInfo.Name = "stsInfo";
            this.stsInfo.Size = new System.Drawing.Size(0, 17);
            // 
            // lstUnmappedItems
            // 
            this.lstUnmappedItems.FormattingEnabled = true;
            this.lstUnmappedItems.HorizontalScrollbar = true;
            this.lstUnmappedItems.IntegralHeight = false;
            this.lstUnmappedItems.Location = new System.Drawing.Point(12, 195);
            this.lstUnmappedItems.Name = "lstUnmappedItems";
            this.lstUnmappedItems.Size = new System.Drawing.Size(190, 298);
            this.lstUnmappedItems.TabIndex = 14;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 530);
            this.Controls.Add(this.lstUnmappedItems);
            this.Controls.Add(this.status);
            this.Controls.Add(this.lblItems);
            this.Controls.Add(this.lblNames);
            this.Controls.Add(this.lstUnmappedNames);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QuickBooks Reporting";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.Label lblNonInvoices;
        private System.Windows.Forms.Label lblNames;
        private System.Windows.Forms.Label lblItems;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ToolStripStatusLabel stsInfo;
        private System.Windows.Forms.ListBox lstUnmappedNames;
        private System.Windows.Forms.ListBox lstUnmappedItems;
    }
}

