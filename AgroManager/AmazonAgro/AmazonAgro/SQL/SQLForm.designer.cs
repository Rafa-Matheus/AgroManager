namespace AmazonAgro
{
    partial class SQLForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SQLForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.itemsLvw = new System.Windows.Forms.ListView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.topToolsBar = new AmazonAgro.TopToolsBar();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1110, 301);
            this.panel1.TabIndex = 1;
            // 
            // itemsLvw
            // 
            this.itemsLvw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemsLvw.Location = new System.Drawing.Point(0, 304);
            this.itemsLvw.Name = "itemsLvw";
            this.itemsLvw.Size = new System.Drawing.Size(1110, 194);
            this.itemsLvw.TabIndex = 5;
            this.itemsLvw.UseCompatibleStateImageBehavior = false;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.itemsLvw);
            this.panel2.Controls.Add(this.splitter1);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Location = new System.Drawing.Point(12, 202);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1110, 498);
            this.panel2.TabIndex = 7;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 301);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1110, 3);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // topToolsBar
            // 
            this.topToolsBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.topToolsBar.ForeColor = System.Drawing.Color.White;
            this.topToolsBar.Location = new System.Drawing.Point(0, 0);
            this.topToolsBar.Name = "topToolsBar";
            this.topToolsBar.Size = new System.Drawing.Size(1134, 140);
            this.topToolsBar.TabIndex = 6;
            // 
            // SQLForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1134, 712);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.topToolsBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SQLForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.closing);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.paint);
            this.Resize += new System.EventHandler(this.resize);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView itemsLvw;
        private TopToolsBar topToolsBar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Splitter splitter1;

    }
}