namespace AmazonAgro
{
    partial class Overview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Overview));
            this.findFolderBtn = new AmazonAgro.CustomButton();
            this.folderPathTbx = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.productsLvw = new System.Windows.Forms.ListView();
            this.topToolsBar = new AmazonAgro.TopToolsBar();
            this.prodCostTbx = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // findFolderBtn
            // 
            this.findFolderBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.findFolderBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(168)))), ((int)(((byte)(59)))));
            this.findFolderBtn.FlatAppearance.BorderSize = 0;
            this.findFolderBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.findFolderBtn.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.findFolderBtn.ForeColor = System.Drawing.Color.White;
            this.findFolderBtn.Location = new System.Drawing.Point(272, 488);
            this.findFolderBtn.Name = "findFolderBtn";
            this.findFolderBtn.Size = new System.Drawing.Size(75, 23);
            this.findFolderBtn.TabIndex = 11;
            this.findFolderBtn.Text = "Procurar...";
            this.findFolderBtn.UseVisualStyleBackColor = false;
            this.findFolderBtn.Click += new System.EventHandler(this.findFolderBtn_Click);
            // 
            // folderPathTbx
            // 
            this.folderPathTbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.folderPathTbx.BackColor = System.Drawing.Color.Black;
            this.folderPathTbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.folderPathTbx.ForeColor = System.Drawing.Color.White;
            this.folderPathTbx.Location = new System.Drawing.Point(12, 490);
            this.folderPathTbx.Name = "folderPathTbx";
            this.folderPathTbx.Size = new System.Drawing.Size(254, 20);
            this.folderPathTbx.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 472);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Pasta dos Produtos:";
            // 
            // productsLvw
            // 
            this.productsLvw.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.productsLvw.FullRowSelect = true;
            this.productsLvw.GridLines = true;
            this.productsLvw.Location = new System.Drawing.Point(12, 146);
            this.productsLvw.Name = "productsLvw";
            this.productsLvw.Size = new System.Drawing.Size(710, 313);
            this.productsLvw.TabIndex = 12;
            this.productsLvw.UseCompatibleStateImageBehavior = false;
            this.productsLvw.View = System.Windows.Forms.View.Details;
            // 
            // topToolsBar
            // 
            this.topToolsBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.topToolsBar.ForeColor = System.Drawing.Color.White;
            this.topToolsBar.Location = new System.Drawing.Point(0, 0);
            this.topToolsBar.Name = "topToolsBar";
            this.topToolsBar.Size = new System.Drawing.Size(734, 140);
            this.topToolsBar.TabIndex = 22;
            // 
            // prodCostTbx
            // 
            this.prodCostTbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.prodCostTbx.BackColor = System.Drawing.Color.Yellow;
            this.prodCostTbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.prodCostTbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prodCostTbx.ForeColor = System.Drawing.Color.Black;
            this.prodCostTbx.Location = new System.Drawing.Point(478, 491);
            this.prodCostTbx.Name = "prodCostTbx";
            this.prodCostTbx.Size = new System.Drawing.Size(100, 20);
            this.prodCostTbx.TabIndex = 25;
            this.prodCostTbx.Text = "0";
            this.prodCostTbx.TextChanged += new System.EventHandler(this.prod_cost_changed);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(353, 493);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Custo de Produção/Kg:";
            // 
            // Overview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(734, 522);
            this.Controls.Add(this.prodCostTbx);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.topToolsBar);
            this.Controls.Add(this.productsLvw);
            this.Controls.Add(this.findFolderBtn);
            this.Controls.Add(this.folderPathTbx);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(750, 560);
            this.Name = "Overview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visão Geral";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomButton findFolderBtn;
        private System.Windows.Forms.TextBox folderPathTbx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView productsLvw;
        private TopToolsBar topToolsBar;
        private System.Windows.Forms.TextBox prodCostTbx;
        private System.Windows.Forms.Label label5;
    }
}