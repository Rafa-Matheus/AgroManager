namespace howto_print_listview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ppdListView = new System.Windows.Forms.PrintPreviewDialog();
            this.pdocListView = new System.Drawing.Printing.PrintDocument();
            this.lvwBooks = new System.Windows.Forms.ListView();
            this.btnPreview = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ppdListView
            // 
            this.ppdListView.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.ppdListView.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.ppdListView.ClientSize = new System.Drawing.Size(400, 300);
            this.ppdListView.Document = this.pdocListView;
            this.ppdListView.Enabled = true;
            this.ppdListView.Icon = ((System.Drawing.Icon)(resources.GetObject("ppdListView.Icon")));
            this.ppdListView.Name = "ppdListView";
            this.ppdListView.Visible = false;
            // 
            // pdocListView
            // 
            this.pdocListView.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdocListView_PrintPage);
            // 
            // lvwBooks
            // 
            this.lvwBooks.AllowColumnReorder = true;
            this.lvwBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwBooks.FullRowSelect = true;
            this.lvwBooks.Location = new System.Drawing.Point(12, 10);
            this.lvwBooks.Name = "lvwBooks";
            this.lvwBooks.Size = new System.Drawing.Size(260, 210);
            this.lvwBooks.TabIndex = 6;
            this.lvwBooks.UseCompatibleStateImageBehavior = false;
            this.lvwBooks.View = System.Windows.Forms.View.Details;
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPreview.Location = new System.Drawing.Point(105, 226);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 5;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.btnPreview;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lvwBooks);
            this.Controls.Add(this.btnPreview);
            this.Name = "Form1";
            this.Text = "howto_print_listview";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PrintPreviewDialog ppdListView;
        private System.Drawing.Printing.PrintDocument pdocListView;
        internal System.Windows.Forms.ListView lvwBooks;
        private System.Windows.Forms.Button btnPreview;
    }
}

