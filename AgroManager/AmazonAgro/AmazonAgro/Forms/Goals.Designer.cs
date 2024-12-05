namespace AmazonAgro
{
    partial class Goals
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Goals));
            this.materialsPnl = new System.Windows.Forms.Panel();
            this.contentPnl = new System.Windows.Forms.FlowLayoutPanel();
            this.litersTbx = new System.Windows.Forms.TextBox();
            this.densityTbx = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.productTbx = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.kgLbl = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel3 = new System.Windows.Forms.Panel();
            this.itemsPnl = new System.Windows.Forms.FlowLayoutPanel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.label5 = new System.Windows.Forms.Label();
            this.topToolsBar = new AmazonAgro.TopToolsBar();
            this.findBtn = new AmazonAgro.CustomButton();
            this.clientTbx = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialsPnl
            // 
            this.materialsPnl.AutoScroll = true;
            this.materialsPnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.materialsPnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.materialsPnl.Location = new System.Drawing.Point(0, 0);
            this.materialsPnl.Name = "materialsPnl";
            this.materialsPnl.Size = new System.Drawing.Size(830, 191);
            this.materialsPnl.TabIndex = 0;
            // 
            // contentPnl
            // 
            this.contentPnl.AutoScroll = true;
            this.contentPnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contentPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPnl.Location = new System.Drawing.Point(0, 194);
            this.contentPnl.Name = "contentPnl";
            this.contentPnl.Size = new System.Drawing.Size(830, 177);
            this.contentPnl.TabIndex = 1;
            this.contentPnl.Paint += new System.Windows.Forms.PaintEventHandler(this.content_paint);
            // 
            // litersTbx
            // 
            this.litersTbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.litersTbx.BackColor = System.Drawing.Color.Black;
            this.litersTbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.litersTbx.ForeColor = System.Drawing.Color.White;
            this.litersTbx.Location = new System.Drawing.Point(279, 557);
            this.litersTbx.Name = "litersTbx";
            this.litersTbx.Size = new System.Drawing.Size(139, 20);
            this.litersTbx.TabIndex = 7;
            this.litersTbx.Text = "1000";
            this.litersTbx.TextChanged += new System.EventHandler(this.values_changed);
            // 
            // densityTbx
            // 
            this.densityTbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.densityTbx.BackColor = System.Drawing.Color.Black;
            this.densityTbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.densityTbx.ForeColor = System.Drawing.Color.White;
            this.densityTbx.Location = new System.Drawing.Point(74, 583);
            this.densityTbx.Name = "densityTbx";
            this.densityTbx.Size = new System.Drawing.Size(161, 20);
            this.densityTbx.TabIndex = 5;
            this.densityTbx.Text = "1";
            this.densityTbx.TextChanged += new System.EventHandler(this.values_changed);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 585);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Densidade:";
            // 
            // productTbx
            // 
            this.productTbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.productTbx.BackColor = System.Drawing.Color.Yellow;
            this.productTbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.productTbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productTbx.ForeColor = System.Drawing.Color.Black;
            this.productTbx.Location = new System.Drawing.Point(74, 557);
            this.productTbx.Name = "productTbx";
            this.productTbx.Size = new System.Drawing.Size(161, 20);
            this.productTbx.TabIndex = 3;
            this.productTbx.Text = "<Sem Nome>";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 559);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Produto:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(241, 560);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Litros:";
            // 
            // kgLbl
            // 
            this.kgLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kgLbl.AutoSize = true;
            this.kgLbl.ForeColor = System.Drawing.Color.White;
            this.kgLbl.Location = new System.Drawing.Point(241, 586);
            this.kgLbl.Name = "kgLbl";
            this.kgLbl.Size = new System.Drawing.Size(68, 13);
            this.kgLbl.TabIndex = 8;
            this.kgLbl.Text = "Kilos:    1000";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.contentPnl);
            this.panel2.Controls.Add(this.splitter1);
            this.panel2.Controls.Add(this.materialsPnl);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(830, 371);
            this.panel2.TabIndex = 24;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 191);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(830, 3);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.itemsPnl);
            this.panel3.Controls.Add(this.splitter2);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Location = new System.Drawing.Point(12, 180);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1053, 371);
            this.panel3.TabIndex = 25;
            // 
            // itemsPnl
            // 
            this.itemsPnl.AutoScroll = true;
            this.itemsPnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.itemsPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemsPnl.Location = new System.Drawing.Point(833, 0);
            this.itemsPnl.Name = "itemsPnl";
            this.itemsPnl.Size = new System.Drawing.Size(220, 371);
            this.itemsPnl.TabIndex = 0;
            this.itemsPnl.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.added);
            this.itemsPnl.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.removed);
            this.itemsPnl.Paint += new System.Windows.Forms.PaintEventHandler(this.items_paint);
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(830, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 371);
            this.splitter2.TabIndex = 25;
            this.splitter2.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Matérias Primas:";
            // 
            // topToolsBar
            // 
            this.topToolsBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.topToolsBar.Location = new System.Drawing.Point(0, 0);
            this.topToolsBar.Name = "topToolsBar";
            this.topToolsBar.Size = new System.Drawing.Size(1077, 140);
            this.topToolsBar.TabIndex = 0;
            // 
            // findBtn
            // 
            this.findBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.findBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(168)))), ((int)(((byte)(59)))));
            this.findBtn.FlatAppearance.BorderSize = 0;
            this.findBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.findBtn.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.findBtn.ForeColor = System.Drawing.Color.White;
            this.findBtn.Location = new System.Drawing.Point(241, 609);
            this.findBtn.Name = "findBtn";
            this.findBtn.Size = new System.Drawing.Size(75, 23);
            this.findBtn.TabIndex = 28;
            this.findBtn.Text = "Procurar...";
            this.findBtn.UseVisualStyleBackColor = false;
            this.findBtn.Click += new System.EventHandler(this.findBtn_Click);
            // 
            // clientTbx
            // 
            this.clientTbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.clientTbx.BackColor = System.Drawing.Color.Black;
            this.clientTbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.clientTbx.ForeColor = System.Drawing.Color.White;
            this.clientTbx.Location = new System.Drawing.Point(74, 609);
            this.clientTbx.Name = "clientTbx";
            this.clientTbx.Size = new System.Drawing.Size(161, 20);
            this.clientTbx.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 611);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Cliente:";
            // 
            // Goals
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1077, 641);
            this.Controls.Add(this.findBtn);
            this.Controls.Add(this.topToolsBar);
            this.Controls.Add(this.clientTbx);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.kgLbl);
            this.Controls.Add(this.productTbx);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.litersTbx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.densityTbx);
            this.Controls.Add(this.label3);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Goals";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Metas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel materialsPnl;
        private System.Windows.Forms.FlowLayoutPanel contentPnl;
        private System.Windows.Forms.TextBox litersTbx;
        private System.Windows.Forms.TextBox densityTbx;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox productTbx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label kgLbl;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Label label5;
        private TopToolsBar topToolsBar;
        private System.Windows.Forms.FlowLayoutPanel itemsPnl;
        private CustomButton findBtn;
        private System.Windows.Forms.TextBox clientTbx;
        private System.Windows.Forms.Label label4;
    }
}