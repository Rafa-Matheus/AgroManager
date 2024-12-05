namespace AmazonAgro
{
    partial class PostgreSQLSetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PostgreSQLSetup));
            this.label1 = new System.Windows.Forms.Label();
            this.serverTbx = new System.Windows.Forms.TextBox();
            this.portTbx = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.databaseTbx = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.userTbx = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.passwordTbx = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.testBtn = new AmazonAgro.CustomButton();
            this.okBtn = new AmazonAgro.CustomButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(15, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Servidor:";
            // 
            // serverTbx
            // 
            this.serverTbx.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.serverTbx.BackColor = System.Drawing.Color.Black;
            this.serverTbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.serverTbx.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverTbx.ForeColor = System.Drawing.Color.White;
            this.serverTbx.Location = new System.Drawing.Point(19, 95);
            this.serverTbx.Name = "serverTbx";
            this.serverTbx.Size = new System.Drawing.Size(276, 22);
            this.serverTbx.TabIndex = 2;
            // 
            // portTbx
            // 
            this.portTbx.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.portTbx.BackColor = System.Drawing.Color.Black;
            this.portTbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.portTbx.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portTbx.ForeColor = System.Drawing.Color.White;
            this.portTbx.Location = new System.Drawing.Point(19, 136);
            this.portTbx.Name = "portTbx";
            this.portTbx.Size = new System.Drawing.Size(276, 22);
            this.portTbx.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(15, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Porta:";
            // 
            // databaseTbx
            // 
            this.databaseTbx.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.databaseTbx.BackColor = System.Drawing.Color.Black;
            this.databaseTbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.databaseTbx.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.databaseTbx.ForeColor = System.Drawing.Color.White;
            this.databaseTbx.Location = new System.Drawing.Point(19, 177);
            this.databaseTbx.Name = "databaseTbx";
            this.databaseTbx.Size = new System.Drawing.Size(276, 22);
            this.databaseTbx.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(15, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Banco de Dados:";
            // 
            // userTbx
            // 
            this.userTbx.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.userTbx.BackColor = System.Drawing.Color.Black;
            this.userTbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userTbx.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userTbx.ForeColor = System.Drawing.Color.White;
            this.userTbx.Location = new System.Drawing.Point(19, 218);
            this.userTbx.Name = "userTbx";
            this.userTbx.Size = new System.Drawing.Size(276, 22);
            this.userTbx.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(15, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Usuário:";
            // 
            // passwordTbx
            // 
            this.passwordTbx.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.passwordTbx.BackColor = System.Drawing.Color.Black;
            this.passwordTbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passwordTbx.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTbx.ForeColor = System.Drawing.Color.White;
            this.passwordTbx.Location = new System.Drawing.Point(19, 259);
            this.passwordTbx.Name = "passwordTbx";
            this.passwordTbx.PasswordChar = '●';
            this.passwordTbx.Size = new System.Drawing.Size(276, 22);
            this.passwordTbx.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(15, 243);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Senha:";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(83, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(148, 21);
            this.label6.TabIndex = 0;
            this.label6.Text = "Configurar Servidor";
            // 
            // testBtn
            // 
            this.testBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.testBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(168)))), ((int)(((byte)(59)))));
            this.testBtn.FlatAppearance.BorderSize = 0;
            this.testBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.testBtn.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.testBtn.ForeColor = System.Drawing.Color.White;
            this.testBtn.Location = new System.Drawing.Point(12, 327);
            this.testBtn.Name = "testBtn";
            this.testBtn.Size = new System.Drawing.Size(75, 23);
            this.testBtn.TabIndex = 11;
            this.testBtn.Text = "Testar";
            this.testBtn.UseVisualStyleBackColor = false;
            this.testBtn.Click += new System.EventHandler(this.OnClick_testBtn);
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(168)))), ((int)(((byte)(59)))));
            this.okBtn.FlatAppearance.BorderSize = 0;
            this.okBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okBtn.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.okBtn.ForeColor = System.Drawing.Color.White;
            this.okBtn.Location = new System.Drawing.Point(227, 327);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 12;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = false;
            this.okBtn.Click += new System.EventHandler(this.OnClick_okBtn);
            // 
            // SQLSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(314, 362);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.testBtn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.passwordTbx);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.userTbx);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.databaseTbx);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.portTbx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.serverTbx);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(330, 400);
            this.Name = "SQLSetup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurar Servidor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox serverTbx;
        private System.Windows.Forms.TextBox portTbx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox databaseTbx;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox userTbx;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox passwordTbx;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private CustomButton testBtn;
        private CustomButton okBtn;
    }
}