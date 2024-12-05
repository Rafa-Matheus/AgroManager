namespace EmbeddedExcel {
	partial class Form1 {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components=null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if(disposing&&(components!=null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.printBtn = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.excelWrapper1 = new EmbeddedExcel.ExcelWrapper();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.printBtn);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox1);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.excelWrapper1);
            this.splitContainer1.Size = new System.Drawing.Size(638, 494);
            this.splitContainer1.SplitterDistance = 175;
            this.splitContainer1.TabIndex = 1;
            // 
            // printBtn
            // 
            this.printBtn.Location = new System.Drawing.Point(46, 151);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(75, 23);
            this.printBtn.TabIndex = 2;
            this.printBtn.Text = "Imprimir";
            this.printBtn.UseVisualStyleBackColor = true;
            this.printBtn.Click += new System.EventHandler(this.printBtn_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(24, 74);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(121, 17);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "CommandBar visible";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(46, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Open file";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // excelWrapper1
            // 
            this.excelWrapper1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.excelWrapper1.Location = new System.Drawing.Point(0, 0);
            this.excelWrapper1.Name = "excelWrapper1";
            this.excelWrapper1.Size = new System.Drawing.Size(459, 494);
            this.excelWrapper1.TabIndex = 0;
            this.excelWrapper1.ToolBarVisible = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Excel Files | *.xls";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(46, 180);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Substituir";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 494);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private ExcelWrapper excelWrapper1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button printBtn;
        private System.Windows.Forms.Button button2;
	}
}

