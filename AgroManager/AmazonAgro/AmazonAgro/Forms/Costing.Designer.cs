namespace AmazonAgro
{
    partial class Costing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Costing));
            this.costsLvw = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.productTbx = new System.Windows.Forms.TextBox();
            this.clientTbx = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.packsLvw = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.costsMsgLbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.topToolsBar = new AmazonAgro.TopToolsBar();
            this.findBtn = new AmazonAgro.CustomButton();
            this.label5 = new System.Windows.Forms.Label();
            this.prodCostTbx = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // costsLvw
            // 
            this.costsLvw.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.costsLvw.FullRowSelect = true;
            this.costsLvw.GridLines = true;
            this.costsLvw.Location = new System.Drawing.Point(12, 177);
            this.costsLvw.Name = "costsLvw";
            this.costsLvw.Size = new System.Drawing.Size(118, 283);
            this.costsLvw.TabIndex = 7;
            this.costsLvw.UseCompatibleStateImageBehavior = false;
            this.costsLvw.View = System.Windows.Forms.View.Details;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 473);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Produto:";
            // 
            // productTbx
            // 
            this.productTbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.productTbx.BackColor = System.Drawing.Color.Black;
            this.productTbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.productTbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productTbx.ForeColor = System.Drawing.Color.White;
            this.productTbx.Location = new System.Drawing.Point(63, 470);
            this.productTbx.Name = "productTbx";
            this.productTbx.Size = new System.Drawing.Size(287, 20);
            this.productTbx.TabIndex = 1;
            // 
            // clientTbx
            // 
            this.clientTbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.clientTbx.BackColor = System.Drawing.Color.Black;
            this.clientTbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.clientTbx.ForeColor = System.Drawing.Color.White;
            this.clientTbx.Location = new System.Drawing.Point(63, 496);
            this.clientTbx.Name = "clientTbx";
            this.clientTbx.Size = new System.Drawing.Size(206, 20);
            this.clientTbx.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 499);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Cliente:";
            // 
            // packsLvw
            // 
            this.packsLvw.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.packsLvw.FullRowSelect = true;
            this.packsLvw.GridLines = true;
            this.packsLvw.Location = new System.Drawing.Point(136, 177);
            this.packsLvw.Name = "packsLvw";
            this.packsLvw.Size = new System.Drawing.Size(766, 283);
            this.packsLvw.TabIndex = 15;
            this.packsLvw.UseCompatibleStateImageBehavior = false;
            this.packsLvw.View = System.Windows.Forms.View.Details;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(136, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Embalagens:";
            // 
            // costsMsgLbl
            // 
            this.costsMsgLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.costsMsgLbl.AutoSize = true;
            this.costsMsgLbl.ForeColor = System.Drawing.Color.White;
            this.costsMsgLbl.Location = new System.Drawing.Point(587, 470);
            this.costsMsgLbl.Name = "costsMsgLbl";
            this.costsMsgLbl.Size = new System.Drawing.Size(0, 13);
            this.costsMsgLbl.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Itens do Produto:";
            // 
            // topToolsBar
            // 
            this.topToolsBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.topToolsBar.ForeColor = System.Drawing.Color.White;
            this.topToolsBar.Location = new System.Drawing.Point(0, 0);
            this.topToolsBar.Name = "topToolsBar";
            this.topToolsBar.Size = new System.Drawing.Size(914, 140);
            this.topToolsBar.TabIndex = 21;
            // 
            // findBtn
            // 
            this.findBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.findBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(168)))), ((int)(((byte)(59)))));
            this.findBtn.FlatAppearance.BorderSize = 0;
            this.findBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.findBtn.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.findBtn.ForeColor = System.Drawing.Color.White;
            this.findBtn.Location = new System.Drawing.Point(275, 496);
            this.findBtn.Name = "findBtn";
            this.findBtn.Size = new System.Drawing.Size(75, 23);
            this.findBtn.TabIndex = 19;
            this.findBtn.Text = "Procurar...";
            this.findBtn.UseVisualStyleBackColor = false;
            this.findBtn.Click += new System.EventHandler(this.findBtn_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(356, 472);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Custo de Produção/Kg:";
            // 
            // prodCostTbx
            // 
            this.prodCostTbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.prodCostTbx.BackColor = System.Drawing.Color.Yellow;
            this.prodCostTbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.prodCostTbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prodCostTbx.ForeColor = System.Drawing.Color.Black;
            this.prodCostTbx.Location = new System.Drawing.Point(481, 470);
            this.prodCostTbx.Name = "prodCostTbx";
            this.prodCostTbx.Size = new System.Drawing.Size(100, 20);
            this.prodCostTbx.TabIndex = 23;
            this.prodCostTbx.Text = "0";
            this.prodCostTbx.TextChanged += new System.EventHandler(this.prod_cost_changed);
            // 
            // Costing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(914, 532);
            this.Controls.Add(this.prodCostTbx);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.topToolsBar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.findBtn);
            this.Controls.Add(this.costsMsgLbl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.packsLvw);
            this.Controls.Add(this.clientTbx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.productTbx);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.costsLvw);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(930, 570);
            this.Name = "Costing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Custeio";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView costsLvw;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox productTbx;
        private System.Windows.Forms.TextBox clientTbx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView packsLvw;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label costsMsgLbl;
        private CustomButton findBtn;
        private System.Windows.Forms.Label label4;
        private TopToolsBar topToolsBar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox prodCostTbx;
    }
}