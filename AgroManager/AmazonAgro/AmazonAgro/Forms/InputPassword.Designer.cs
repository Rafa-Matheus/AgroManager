namespace AmazonAgro
{
    partial class InputPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputPassword));
            this.passwordTbx = new System.Windows.Forms.TextBox();
            this.infoLbl = new System.Windows.Forms.Label();
            this.iconPbx = new System.Windows.Forms.PictureBox();
            this.okBtn = new AmazonAgro.CustomButton();
            ((System.ComponentModel.ISupportInitialize)(this.iconPbx)).BeginInit();
            this.SuspendLayout();
            // 
            // passwordTbx
            // 
            this.passwordTbx.BackColor = System.Drawing.Color.Black;
            this.passwordTbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passwordTbx.ForeColor = System.Drawing.Color.White;
            this.passwordTbx.Location = new System.Drawing.Point(101, 78);
            this.passwordTbx.Name = "passwordTbx";
            this.passwordTbx.PasswordChar = '●';
            this.passwordTbx.Size = new System.Drawing.Size(230, 20);
            this.passwordTbx.TabIndex = 0;
            // 
            // infoLbl
            // 
            this.infoLbl.AutoSize = true;
            this.infoLbl.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoLbl.ForeColor = System.Drawing.Color.White;
            this.infoLbl.Location = new System.Drawing.Point(98, 38);
            this.infoLbl.MaximumSize = new System.Drawing.Size(230, 0);
            this.infoLbl.Name = "infoLbl";
            this.infoLbl.Size = new System.Drawing.Size(0, 13);
            this.infoLbl.TabIndex = 2;
            // 
            // iconPbx
            // 
            this.iconPbx.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("iconPbx.BackgroundImage")));
            this.iconPbx.Location = new System.Drawing.Point(32, 38);
            this.iconPbx.Name = "iconPbx";
            this.iconPbx.Size = new System.Drawing.Size(60, 60);
            this.iconPbx.TabIndex = 3;
            this.iconPbx.TabStop = false;
            // 
            // okBtn
            // 
            this.okBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(168)))), ((int)(((byte)(59)))));
            this.okBtn.FlatAppearance.BorderSize = 0;
            this.okBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okBtn.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.okBtn.ForeColor = System.Drawing.Color.White;
            this.okBtn.Location = new System.Drawing.Point(267, 127);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 4;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = false;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // InputPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(354, 162);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.iconPbx);
            this.Controls.Add(this.infoLbl);
            this.Controls.Add(this.passwordTbx);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InputPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Senha";
            ((System.ComponentModel.ISupportInitialize)(this.iconPbx)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox passwordTbx;
        private System.Windows.Forms.Label infoLbl;
        private System.Windows.Forms.PictureBox iconPbx;
        private CustomButton okBtn;
    }
}