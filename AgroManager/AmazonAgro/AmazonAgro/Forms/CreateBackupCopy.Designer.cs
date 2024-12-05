namespace AmazonAgro
{
    partial class CreateBackupCopy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateBackupCopy));
            this.filesLbx = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.productsFolderTbx = new System.Windows.Forms.TextBox();
            this.targetFolderTbx = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.findProductFolderBtn = new AmazonAgro.CustomButton();
            this.findTargetFolderBtn = new AmazonAgro.CustomButton();
            this.createBtn = new AmazonAgro.CustomButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // filesLbx
            // 
            this.filesLbx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filesLbx.BackColor = System.Drawing.Color.Black;
            this.filesLbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.filesLbx.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filesLbx.ForeColor = System.Drawing.Color.White;
            this.filesLbx.FormattingEnabled = true;
            this.filesLbx.ItemHeight = 14;
            this.filesLbx.Location = new System.Drawing.Point(12, 153);
            this.filesLbx.Name = "filesLbx";
            this.filesLbx.Size = new System.Drawing.Size(530, 212);
            this.filesLbx.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(110, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pasta dos Produtos:";
            // 
            // productsFolderTbx
            // 
            this.productsFolderTbx.BackColor = System.Drawing.Color.Black;
            this.productsFolderTbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.productsFolderTbx.ForeColor = System.Drawing.Color.White;
            this.productsFolderTbx.Location = new System.Drawing.Point(113, 43);
            this.productsFolderTbx.Name = "productsFolderTbx";
            this.productsFolderTbx.Size = new System.Drawing.Size(340, 20);
            this.productsFolderTbx.TabIndex = 2;
            // 
            // targetFolderTbx
            // 
            this.targetFolderTbx.BackColor = System.Drawing.Color.Black;
            this.targetFolderTbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.targetFolderTbx.ForeColor = System.Drawing.Color.White;
            this.targetFolderTbx.Location = new System.Drawing.Point(113, 91);
            this.targetFolderTbx.Name = "targetFolderTbx";
            this.targetFolderTbx.Size = new System.Drawing.Size(340, 20);
            this.targetFolderTbx.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(110, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Destino do Arquivo de Cópia:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Arquivos adicionados:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(15, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(90, 90);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // findProductFolderBtn
            // 
            this.findProductFolderBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(168)))), ((int)(((byte)(59)))));
            this.findProductFolderBtn.FlatAppearance.BorderSize = 0;
            this.findProductFolderBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.findProductFolderBtn.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.findProductFolderBtn.ForeColor = System.Drawing.Color.White;
            this.findProductFolderBtn.Location = new System.Drawing.Point(459, 41);
            this.findProductFolderBtn.Name = "findProductFolderBtn";
            this.findProductFolderBtn.Size = new System.Drawing.Size(75, 23);
            this.findProductFolderBtn.TabIndex = 8;
            this.findProductFolderBtn.Text = "Procurar...";
            this.findProductFolderBtn.UseVisualStyleBackColor = false;
            this.findProductFolderBtn.Click += new System.EventHandler(this.findProductFolderBtn_Click);
            // 
            // findTargetFolderBtn
            // 
            this.findTargetFolderBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(168)))), ((int)(((byte)(59)))));
            this.findTargetFolderBtn.FlatAppearance.BorderSize = 0;
            this.findTargetFolderBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.findTargetFolderBtn.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.findTargetFolderBtn.ForeColor = System.Drawing.Color.White;
            this.findTargetFolderBtn.Location = new System.Drawing.Point(459, 89);
            this.findTargetFolderBtn.Name = "findTargetFolderBtn";
            this.findTargetFolderBtn.Size = new System.Drawing.Size(75, 23);
            this.findTargetFolderBtn.TabIndex = 9;
            this.findTargetFolderBtn.Text = "Procurar...";
            this.findTargetFolderBtn.UseVisualStyleBackColor = false;
            this.findTargetFolderBtn.Click += new System.EventHandler(this.findTargetFolderBtn_Click);
            // 
            // createBtn
            // 
            this.createBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.createBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(168)))), ((int)(((byte)(59)))));
            this.createBtn.FlatAppearance.BorderSize = 0;
            this.createBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createBtn.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.createBtn.ForeColor = System.Drawing.Color.White;
            this.createBtn.Location = new System.Drawing.Point(445, 397);
            this.createBtn.Name = "createBtn";
            this.createBtn.Size = new System.Drawing.Size(97, 23);
            this.createBtn.TabIndex = 10;
            this.createBtn.Text = "Criar Cópia";
            this.createBtn.UseVisualStyleBackColor = false;
            this.createBtn.Click += new System.EventHandler(this.createBtn_Click);
            // 
            // CreateBackupCopy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(554, 432);
            this.Controls.Add(this.createBtn);
            this.Controls.Add(this.findTargetFolderBtn);
            this.Controls.Add(this.findProductFolderBtn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.targetFolderTbx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.productsFolderTbx);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.filesLbx);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(570, 470);
            this.Name = "CreateBackupCopy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Criar Cópia de Segurança";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox filesLbx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox productsFolderTbx;
        private System.Windows.Forms.TextBox targetFolderTbx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private CustomButton findProductFolderBtn;
        private CustomButton findTargetFolderBtn;
        private CustomButton createBtn;
    }
}