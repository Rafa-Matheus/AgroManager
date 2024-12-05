namespace AmazonAgro
{
    partial class Login
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">verdade se for necessário descartar os recursos gerenciados; caso contrário, falso.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte do Designer - não modifique
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.label1 = new System.Windows.Forms.Label();
            this.userTbx = new System.Windows.Forms.TextBox();
            this.passwordTbx = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.logoPbx = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.infoLbl = new System.Windows.Forms.Label();
            this.loginBtn = new AmazonAgro.CustomButton();
            ((System.ComponentModel.ISupportInitialize)(this.logoPbx)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuário:";
            // 
            // userTbx
            // 
            this.userTbx.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.userTbx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.userTbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userTbx.ForeColor = System.Drawing.Color.White;
            this.userTbx.Location = new System.Drawing.Point(16, 135);
            this.userTbx.Name = "userTbx";
            this.userTbx.Size = new System.Drawing.Size(428, 20);
            this.userTbx.TabIndex = 1;
            // 
            // passwordTbx
            // 
            this.passwordTbx.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.passwordTbx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.passwordTbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passwordTbx.ForeColor = System.Drawing.Color.White;
            this.passwordTbx.Location = new System.Drawing.Point(16, 197);
            this.passwordTbx.Name = "passwordTbx";
            this.passwordTbx.PasswordChar = '●';
            this.passwordTbx.Size = new System.Drawing.Size(428, 20);
            this.passwordTbx.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(13, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Senha:";
            // 
            // logoPbx
            // 
            this.logoPbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.logoPbx.BackColor = System.Drawing.Color.Transparent;
            this.logoPbx.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("logoPbx.BackgroundImage")));
            this.logoPbx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.logoPbx.Location = new System.Drawing.Point(420, 638);
            this.logoPbx.Name = "logoPbx";
            this.logoPbx.Size = new System.Drawing.Size(102, 57);
            this.logoPbx.TabIndex = 6;
            this.logoPbx.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.loginBtn);
            this.panel1.Controls.Add(this.passwordTbx);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.userTbx);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(38, 201);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(459, 304);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(168)))), ((int)(((byte)(59)))));
            this.panel2.Controls.Add(this.infoLbl);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(457, 92);
            this.panel2.TabIndex = 11;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.paint);
            // 
            // infoLbl
            // 
            this.infoLbl.AutoSize = true;
            this.infoLbl.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.infoLbl.Location = new System.Drawing.Point(102, 65);
            this.infoLbl.Name = "infoLbl";
            this.infoLbl.Size = new System.Drawing.Size(253, 13);
            this.infoLbl.TabIndex = 10;
            this.infoLbl.Text = "Por favor, digite o seu nome de usuário e senha";
            // 
            // loginBtn
            // 
            this.loginBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.loginBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(168)))), ((int)(((byte)(59)))));
            this.loginBtn.FlatAppearance.BorderSize = 0;
            this.loginBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginBtn.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.loginBtn.ForeColor = System.Drawing.Color.White;
            this.loginBtn.Location = new System.Drawing.Point(340, 223);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(104, 32);
            this.loginBtn.TabIndex = 9;
            this.loginBtn.Text = "Entrar";
            this.loginBtn.UseVisualStyleBackColor = false;
            this.loginBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(534, 707);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.logoPbx);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 930);
            this.MinimumSize = new System.Drawing.Size(550, 520);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AgroManager";
            ((System.ComponentModel.ISupportInitialize)(this.logoPbx)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox userTbx;
        private System.Windows.Forms.TextBox passwordTbx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox logoPbx;
        private System.Windows.Forms.Panel panel1;
        private CustomButton loginBtn;
        private System.Windows.Forms.Label infoLbl;
        private System.Windows.Forms.Panel panel2;



    }
}

