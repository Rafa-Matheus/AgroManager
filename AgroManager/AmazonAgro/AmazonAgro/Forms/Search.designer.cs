namespace AmazonAgro
{
    partial class Search
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Search));
            this.inputTbx = new System.Windows.Forms.TextBox();
            this.list = new System.Windows.Forms.ListView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.okBtn = new AmazonAgro.CustomButton();
            this.SuspendLayout();
            // 
            // inputTbx
            // 
            this.inputTbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputTbx.BackColor = System.Drawing.Color.Black;
            this.inputTbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inputTbx.ForeColor = System.Drawing.Color.White;
            this.inputTbx.Location = new System.Drawing.Point(12, 109);
            this.inputTbx.Name = "inputTbx";
            this.inputTbx.Size = new System.Drawing.Size(448, 20);
            this.inputTbx.TabIndex = 1;
            // 
            // list
            // 
            this.list.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.list.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.list.FullRowSelect = true;
            this.list.GridLines = true;
            this.list.Location = new System.Drawing.Point(12, 135);
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(448, 134);
            this.list.TabIndex = 2;
            this.list.UseCompatibleStateImageBehavior = false;
            this.list.View = System.Windows.Forms.View.Details;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(168)))), ((int)(((byte)(59)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(474, 92);
            this.panel2.TabIndex = 0;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.paint);
            // 
            // okBtn
            // 
            this.okBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(168)))), ((int)(((byte)(59)))));
            this.okBtn.FlatAppearance.BorderSize = 0;
            this.okBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okBtn.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.okBtn.ForeColor = System.Drawing.Color.White;
            this.okBtn.Location = new System.Drawing.Point(387, 287);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 3;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = false;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(474, 322);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.list);
            this.Controls.Add(this.inputTbx);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Search";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputTbx;
        private System.Windows.Forms.ListView list;
        private System.Windows.Forms.Panel panel2;
        private CustomButton okBtn;
    }
}