namespace AmazonAgro
{
    partial class LeafAnalysis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LeafAnalysis));
            this.nameTbx = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.factorTbx = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.list1Lvw = new System.Windows.Forms.ListView();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.panel6 = new System.Windows.Forms.Panel();
            this.data1 = new System.Windows.Forms.DataGridView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.list2Lvw = new System.Windows.Forms.ListView();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel4 = new System.Windows.Forms.Panel();
            this.data2 = new System.Windows.Forms.DataGridView();
            this.panel8 = new System.Windows.Forms.Panel();
            this.contentPnl = new System.Windows.Forms.FlowLayoutPanel();
            this.splitter4 = new System.Windows.Forms.Splitter();
            this.contentTotalPnl = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.periodCbx = new System.Windows.Forms.ComboBox();
            this.topToolsBar = new AmazonAgro.TopToolsBar();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data2)).BeginInit();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // nameTbx
            // 
            this.nameTbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nameTbx.BackColor = System.Drawing.Color.Yellow;
            this.nameTbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nameTbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTbx.ForeColor = System.Drawing.Color.Black;
            this.nameTbx.Location = new System.Drawing.Point(135, 612);
            this.nameTbx.Name = "nameTbx";
            this.nameTbx.Size = new System.Drawing.Size(161, 20);
            this.nameTbx.TabIndex = 29;
            this.nameTbx.Text = "<Sem Nome>";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 614);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Cultura:";
            // 
            // factorTbx
            // 
            this.factorTbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.factorTbx.BackColor = System.Drawing.Color.Yellow;
            this.factorTbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.factorTbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.factorTbx.ForeColor = System.Drawing.Color.Black;
            this.factorTbx.Location = new System.Drawing.Point(135, 658);
            this.factorTbx.Name = "factorTbx";
            this.factorTbx.Size = new System.Drawing.Size(161, 20);
            this.factorTbx.TabIndex = 31;
            this.factorTbx.Text = "1";
            this.factorTbx.TextChanged += new System.EventHandler(this.factor_changed);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 660);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Fator de Conversão:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(12, 193);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(976, 413);
            this.panel1.TabIndex = 32;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Controls.Add(this.splitter3);
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(490, 413);
            this.panel3.TabIndex = 2;
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.list1Lvw);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 203);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(490, 210);
            this.panel7.TabIndex = 2;
            // 
            // list1Lvw
            // 
            this.list1Lvw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.list1Lvw.FullRowSelect = true;
            this.list1Lvw.GridLines = true;
            this.list1Lvw.Location = new System.Drawing.Point(0, 0);
            this.list1Lvw.Name = "list1Lvw";
            this.list1Lvw.Size = new System.Drawing.Size(488, 208);
            this.list1Lvw.TabIndex = 0;
            this.list1Lvw.UseCompatibleStateImageBehavior = false;
            this.list1Lvw.View = System.Windows.Forms.View.Details;
            // 
            // splitter3
            // 
            this.splitter3.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter3.Location = new System.Drawing.Point(0, 200);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(490, 3);
            this.splitter3.TabIndex = 1;
            this.splitter3.TabStop = false;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.data1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(490, 200);
            this.panel6.TabIndex = 0;
            // 
            // data1
            // 
            this.data1.BackgroundColor = System.Drawing.Color.Black;
            this.data1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.data1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.data1.Location = new System.Drawing.Point(0, 0);
            this.data1.Name = "data1";
            this.data1.Size = new System.Drawing.Size(488, 198);
            this.data1.TabIndex = 0;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(490, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 413);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.splitter2);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(493, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(483, 413);
            this.panel2.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.list2Lvw);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 203);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(483, 210);
            this.panel5.TabIndex = 2;
            // 
            // list2Lvw
            // 
            this.list2Lvw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.list2Lvw.FullRowSelect = true;
            this.list2Lvw.GridLines = true;
            this.list2Lvw.Location = new System.Drawing.Point(0, 0);
            this.list2Lvw.Name = "list2Lvw";
            this.list2Lvw.Size = new System.Drawing.Size(481, 208);
            this.list2Lvw.TabIndex = 0;
            this.list2Lvw.UseCompatibleStateImageBehavior = false;
            this.list2Lvw.View = System.Windows.Forms.View.Details;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(0, 200);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(483, 3);
            this.splitter2.TabIndex = 1;
            this.splitter2.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.data2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(483, 200);
            this.panel4.TabIndex = 0;
            // 
            // data2
            // 
            this.data2.BackgroundColor = System.Drawing.Color.Black;
            this.data2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.data2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.data2.Location = new System.Drawing.Point(0, 0);
            this.data2.Name = "data2";
            this.data2.Size = new System.Drawing.Size(481, 198);
            this.data2.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel8.Controls.Add(this.contentPnl);
            this.panel8.Controls.Add(this.panel9);
            this.panel8.Controls.Add(this.splitter4);
            this.panel8.Controls.Add(this.contentTotalPnl);
            this.panel8.Location = new System.Drawing.Point(994, 193);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(468, 413);
            this.panel8.TabIndex = 34;
            // 
            // contentPnl
            // 
            this.contentPnl.AutoScroll = true;
            this.contentPnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contentPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPnl.ForeColor = System.Drawing.Color.White;
            this.contentPnl.Location = new System.Drawing.Point(0, 0);
            this.contentPnl.Name = "contentPnl";
            this.contentPnl.Size = new System.Drawing.Size(468, 219);
            this.contentPnl.TabIndex = 2;
            // 
            // splitter4
            // 
            this.splitter4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter4.Location = new System.Drawing.Point(0, 260);
            this.splitter4.Name = "splitter4";
            this.splitter4.Size = new System.Drawing.Size(468, 3);
            this.splitter4.TabIndex = 4;
            this.splitter4.TabStop = false;
            // 
            // contentTotalPnl
            // 
            this.contentTotalPnl.AutoScroll = true;
            this.contentTotalPnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contentTotalPnl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.contentTotalPnl.Location = new System.Drawing.Point(0, 263);
            this.contentTotalPnl.Name = "contentTotalPnl";
            this.contentTotalPnl.Size = new System.Drawing.Size(468, 150);
            this.contentTotalPnl.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 637);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Perído das Aplicações:";
            // 
            // periodCbx
            // 
            this.periodCbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.periodCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.periodCbx.FormattingEnabled = true;
            this.periodCbx.Items.AddRange(new object[] {
            "Diário",
            "Semanal",
            "Quinzenal",
            "Mensal",
            "Semestral",
            "Anual"});
            this.periodCbx.Location = new System.Drawing.Point(135, 634);
            this.periodCbx.Name = "periodCbx";
            this.periodCbx.Size = new System.Drawing.Size(161, 21);
            this.periodCbx.TabIndex = 36;
            // 
            // topToolsBar
            // 
            this.topToolsBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.topToolsBar.ForeColor = System.Drawing.Color.White;
            this.topToolsBar.Location = new System.Drawing.Point(0, 0);
            this.topToolsBar.Name = "topToolsBar";
            this.topToolsBar.Size = new System.Drawing.Size(1474, 140);
            this.topToolsBar.TabIndex = 33;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.label3);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel9.Location = new System.Drawing.Point(0, 219);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(468, 41);
            this.panel9.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "Recomendação Kg/Ha:";
            // 
            // LeafAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1474, 692);
            this.Controls.Add(this.periodCbx);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.topToolsBar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.factorTbx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameTbx);
            this.Controls.Add(this.label4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LeafAnalysis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recomendações (Análise Folha/Solo)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.paint);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.data1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.data2)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameTbx;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox factorTbx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ListView list1Lvw;
        private System.Windows.Forms.DataGridView data1;
        private System.Windows.Forms.ListView list2Lvw;
        private System.Windows.Forms.DataGridView data2;
        private TopToolsBar topToolsBar;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.FlowLayoutPanel contentPnl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox periodCbx;
        private System.Windows.Forms.Splitter splitter4;
        private System.Windows.Forms.FlowLayoutPanel contentTotalPnl;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label3;
    }
}