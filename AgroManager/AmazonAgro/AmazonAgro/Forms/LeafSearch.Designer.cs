namespace AmazonAgro
{
    partial class LeafSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LeafSearch));
            this.listLvw = new System.Windows.Forms.ListView();
            this.periodicPnl = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.folderPathTbx = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.itemsPnl = new System.Windows.Forms.FlowLayoutPanel();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.composePnl = new System.Windows.Forms.FlowLayoutPanel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.findFolderBtn = new AmazonAgro.CustomButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listLvw
            // 
            this.listLvw.Dock = System.Windows.Forms.DockStyle.Top;
            this.listLvw.FullRowSelect = true;
            this.listLvw.GridLines = true;
            this.listLvw.Location = new System.Drawing.Point(0, 0);
            this.listLvw.Name = "listLvw";
            this.listLvw.Size = new System.Drawing.Size(1260, 149);
            this.listLvw.TabIndex = 0;
            this.listLvw.UseCompatibleStateImageBehavior = false;
            this.listLvw.View = System.Windows.Forms.View.Details;
            // 
            // periodicPnl
            // 
            this.periodicPnl.AutoScroll = true;
            this.periodicPnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.periodicPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.periodicPnl.ForeColor = System.Drawing.Color.White;
            this.periodicPnl.Location = new System.Drawing.Point(0, 0);
            this.periodicPnl.Name = "periodicPnl";
            this.periodicPnl.Size = new System.Drawing.Size(1111, 250);
            this.periodicPnl.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 580);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Pasta dos Produtos:";
            // 
            // folderPathTbx
            // 
            this.folderPathTbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.folderPathTbx.BackColor = System.Drawing.Color.Black;
            this.folderPathTbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.folderPathTbx.ForeColor = System.Drawing.Color.White;
            this.folderPathTbx.Location = new System.Drawing.Point(15, 598);
            this.folderPathTbx.Name = "folderPathTbx";
            this.folderPathTbx.Size = new System.Drawing.Size(254, 20);
            this.folderPathTbx.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.itemsPnl);
            this.panel1.Controls.Add(this.splitter3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.listLvw);
            this.panel1.Location = new System.Drawing.Point(12, 61);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1260, 508);
            this.panel1.TabIndex = 7;
            // 
            // itemsPnl
            // 
            this.itemsPnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.itemsPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemsPnl.ForeColor = System.Drawing.Color.White;
            this.itemsPnl.Location = new System.Drawing.Point(1114, 152);
            this.itemsPnl.Name = "itemsPnl";
            this.itemsPnl.Size = new System.Drawing.Size(146, 356);
            this.itemsPnl.TabIndex = 4;
            this.itemsPnl.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.added);
            this.itemsPnl.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.removed);
            this.itemsPnl.Paint += new System.Windows.Forms.PaintEventHandler(this.items_paint);
            // 
            // splitter3
            // 
            this.splitter3.Location = new System.Drawing.Point(1111, 152);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(3, 356);
            this.splitter3.TabIndex = 7;
            this.splitter3.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.periodicPnl);
            this.panel2.Controls.Add(this.splitter2);
            this.panel2.Controls.Add(this.composePnl);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 152);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1111, 356);
            this.panel2.TabIndex = 6;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter2.Location = new System.Drawing.Point(0, 250);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(1111, 3);
            this.splitter2.TabIndex = 5;
            this.splitter2.TabStop = false;
            // 
            // composePnl
            // 
            this.composePnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.composePnl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.composePnl.Location = new System.Drawing.Point(0, 253);
            this.composePnl.Name = "composePnl";
            this.composePnl.Size = new System.Drawing.Size(1111, 103);
            this.composePnl.TabIndex = 4;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 149);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1260, 3);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // findFolderBtn
            // 
            this.findFolderBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.findFolderBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(168)))), ((int)(((byte)(59)))));
            this.findFolderBtn.FlatAppearance.BorderSize = 0;
            this.findFolderBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.findFolderBtn.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.findFolderBtn.ForeColor = System.Drawing.Color.White;
            this.findFolderBtn.Location = new System.Drawing.Point(275, 596);
            this.findFolderBtn.Name = "findFolderBtn";
            this.findFolderBtn.Size = new System.Drawing.Size(75, 23);
            this.findFolderBtn.TabIndex = 8;
            this.findFolderBtn.Text = "Procurar...";
            this.findFolderBtn.UseVisualStyleBackColor = false;
            this.findFolderBtn.Click += new System.EventHandler(this.findFolderBtn_Click);
            // 
            // LeafSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1284, 642);
            this.Controls.Add(this.findFolderBtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.folderPathTbx);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LeafSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesquisa de Produto";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.paint);
            this.Resize += new System.EventHandler(this.resize);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listLvw;
        private System.Windows.Forms.Panel periodicPnl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox folderPathTbx;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter1;
        private CustomButton findFolderBtn;
        private System.Windows.Forms.FlowLayoutPanel itemsPnl;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.FlowLayoutPanel composePnl;
    }
}